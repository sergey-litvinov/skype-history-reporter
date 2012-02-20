using System;
using System.Data;
using System.Data.SqlTypes;

namespace SkypeHistory.DB.Sqlite
{
    public static class DataReaderExtensions
    {
        public static T GetObject<T>(this IDataReader reader, string columnName)
            where T : class
        {
            int index = reader.GetColumnIndex(columnName);
            if (reader.IsDBNull(index))
                return null;
            return (T)reader.GetValue(index);
        }

        public static T GetValueObject<T>(this IDataReader reader, string columnName)
            where T : struct
        {
            int index = reader.GetColumnIndex(columnName);
            if (reader.IsDBNull(index))
                throw new SqlNullValueException();
            return (T)reader.GetValue(index);
        }

        public static T? GetNullableObject<T>(this IDataReader reader, string columnName)
            where T : struct
        {
            int index = reader.GetColumnIndex(columnName);
            if (reader.IsDBNull(index))
                return null;
            return (T)reader.GetValue(index);
        }

        public static int GetColumnIndex(this IDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName);
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }
    }
}