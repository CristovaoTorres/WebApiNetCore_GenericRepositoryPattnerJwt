using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Models;

namespace VcmSuite3x_api.Extensions
{
    public static class ExtensionsMethod
    {
        public static IEnumerable<ListSelectItems> ToSelectList<T>(this IEnumerable<T> items,
            Func<T, string> text, Func<T, string> value = null, Func<T, Boolean> selected = null)
        {
            return items.Select(p => new ListSelectItems
            {
                Text = text.Invoke(p),
                Value = (value == null ? text.Invoke(p) : value.Invoke(p)),
                Selected = selected == null ? false : selected.Invoke(p)
            });
        }

        public class ListSelectItems
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        public static ValidationResponse GenerateValidation(this ModelStateDictionary dictionary)
        {
            var output = new List<string>();

            foreach (var dictionaryValue in dictionary.Values)
            {
                foreach (var error in dictionaryValue.Errors)
                {
                    output.Add(error.ErrorMessage);
                }
            }

            return new ValidationResponse
            {
                Errors = output
            };
        }

        public static Expression<Func<T, bool>> strToFunc<T>(string propName, string opr, string value, Expression<Func<T, bool>> expr = null)
        {
            Expression<Func<T, bool>> func = null;
            try
            {
                var type = typeof(T);
                var prop = type.GetProperty(propName);
                ParameterExpression tpe = Expression.Parameter(typeof(T));
                Expression left = Expression.Property(tpe, prop);
                Expression right = Expression.Convert(ToExprConstant(prop, value), prop.PropertyType);
                Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>>(ApplyFilter(opr, left, right), tpe);
                if (expr != null)
                    innerExpr = innerExpr.And(expr);
                func = innerExpr;
            }
            catch (Exception ex)
            {
            }

            return func;
        }
        private static Expression ToExprConstant(PropertyInfo prop, string value)
        {
            object val = null;

            try
            {
                switch (prop.Name)
                {
                    case "System.Guid":
                        val = Guid.NewGuid();
                        break;
                    default:
                        {
                            val = Convert.ChangeType(value, prop.PropertyType);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }

            return Expression.Constant(val);
        }
        private static BinaryExpression ApplyFilter(string opr, Expression left, Expression right)
        {
            BinaryExpression InnerLambda = null;
            switch (opr)
            {
                case "==":
                case "=":
                    InnerLambda = Expression.Equal(left, right);
                    break;
                case "<":
                    InnerLambda = Expression.LessThan(left, right);
                    break;
                case ">":
                    InnerLambda = Expression.GreaterThan(left, right);
                    break;
                case ">=":
                    InnerLambda = Expression.GreaterThanOrEqual(left, right);
                    break;
                case "<=":
                    InnerLambda = Expression.LessThanOrEqual(left, right);
                    break;
                case "!=":
                    InnerLambda = Expression.NotEqual(left, right);
                    break;
                case "&&":
                    InnerLambda = Expression.And(left, right);
                    break;
                case "||":
                    InnerLambda = Expression.Or(left, right);
                    break;
            }
            return InnerLambda;
        }

        public static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

    }
}
