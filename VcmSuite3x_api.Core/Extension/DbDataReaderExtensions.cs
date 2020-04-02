using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace VcmSuite3x_api.Core.Extension
{
    /// <summary>
    /// Extensões para DbDataReader.
    /// </summary>
    /// <remarks>
    /// Para uso em persistência de classes POCO usando diretamente ADO.NET.
    /// </remarks>
    public static class DbDataReaderExtensions
    {
        /// <summary>
        /// Obtém o valor da coluna como Boolean ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Boolean? GetBooleanOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetBoolean(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Byte ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Byte? GetByteOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetByte(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como DateTime ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static DateTime? GetDateTimeOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetDateTime(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Decimal ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Decimal? GetDecimalOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetDecimal(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Double ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Double? GetDoubleOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetDouble(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Int16 ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Int16? GetInt16OrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetInt16(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Int32 ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        public static Int32? GetInt32OrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetInt32(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Int64 ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Int64? GetInt64OrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetInt64(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como Single ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static Single? GetSingleOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetFloat(ordinal);
            }

            return null;
        }

        /// <summary>
        /// Obtém o valor da coluna como String ou nulo.
        /// </summary>
        /// <param name="rdr">DataReader com a coluna a ser lida.</param>
        /// <param name="ordinal">Posição da coluna.</param>
        /// <returns>Valor da coluna ou nulo.</returns>
        /// <exception cref="System.InvalidCastException" />
        public static String GetStringOrNull(this DbDataReader rdr, Int32 ordinal)
        {
            if (!rdr.IsDBNull(ordinal))
            {
                return rdr.GetString(ordinal);
            }

            return null;
        }
    }
}
