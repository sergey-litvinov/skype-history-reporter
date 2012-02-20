using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.Unity;
using SkypeHistory.Interfaces;

namespace SkypeHistory.DB.Sqlite
{
    internal class BaseSqliteRepository
    {
    	private static readonly DbProviderFactory factory = System.Data.SQLite.SQLiteFactory.Instance;
			//DbProviderFactories.GetFactory("System.Data.SQLite");

        [Dependency]
        public IProfileHolder ProfileHolder { get; set; }

        private string BuildDBPath()
        {			
            if (ProfileHolder.Current == null)
            {
                throw new InvalidOperationException("Profile isn't selected");
            }
            return string.Format("Data Source={0}\\main.db;Version=3;", ProfileHolder.Current.Location);
        }

        public DbConnection CreateConnection()
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = BuildDBPath();
            return connection;
        }

        protected DbParameter CreateParameter<T>(string name, T value)
        {
            var p = factory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }


        public T ExecuteReaderItem<T>(string query, Action<DbDataReader,T> handler)
            where T : new()
        {
            T item = default(T);
            using (var connection = CreateConnection())
            {
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = new T();
                        handler(reader, item);
                    }
                }
                connection.Close();
            }
            return item;
        }

        public IEnumerable<T> ExecuteReaderItems<T>(string query, Action<DbDataReader, T> handler, params DbParameter[] parameters)
            where T : new()
        {
            List<T> items = new List<T>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = new T();
                        handler(reader, item);
                        items.Add(item);
                    }
                }
                connection.Close();
            }
            return items;
        }
    }
}