using System;
using System.Collections.Generic;
using System.Text;

namespace VcmSuite3x.Application.ViewModel
{
    public interface ISelectableEntityViewModel<TEntity>
         where TEntity : class
    {
        IEnumerable<TEntity> Available { get; set; }

        IEnumerable<TEntity> Selected { get; set; }

        Int32[] Posted { get; set; }

    }

    public abstract class SelectableEntityViewModel<TEntity> : ISelectableEntityViewModel<TEntity>
          where TEntity : class
    {
        protected SelectableEntityViewModel()
        {
            Posted = new Int32[0];
        }

        public IEnumerable<TEntity> Available { get; set; }

        public IEnumerable<TEntity> Selected { get; set; }

        public Int32[] Posted { get; set; }
    }

    public sealed class SelectableEntityViewModel : SelectableEntityViewModel<object>
    {
        public SelectableEntityViewModel()
            : base() { }
    }
}
