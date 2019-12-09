using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mvcPet.Data
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessComponent
    {
        protected const string CONNECTION_NAME = "DefaultConnection";

        static DataAccessComponent()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }

        protected int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        protected static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }

        protected static Int16 GetInt16Value(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return dr.GetInt16(i);
            else
                return default(Int16);
        }

        protected static DateTime GetDateTimeValue(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return dr.GetDateTime(i);
            else
                return default(DateTime);
        }

        protected static T GetEnumValue<T>(IDataReader dr, string columnName)
        {
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)Enum.Parse(typeof(T), dr.GetString(i));
            else
                return default(T);
        }

        protected string FormatFilterStatement(string filter)
        {
            return Regex.Replace(filter, "^(AND|OR)", string.Empty);
        }
    }
}

