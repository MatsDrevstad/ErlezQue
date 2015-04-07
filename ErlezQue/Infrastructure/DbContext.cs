using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Infrastructure
{

    public class DbContext
    {
        private SqlConnection _connection;

        public DbContext(string str = "Bill")
        {
            _connection = new SqlConnection(ConnectionString(str));
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        private string ConnectionString(string str)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ErlezQue.Properties.Settings.BillAdo"].ToString();
            if (str == "Bull")
                connStr = ConfigurationManager.ConnectionStrings["ErlezQue.Properties.Settings.BullAdo"].ToString();

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);

            sb.ApplicationName = str;
            sb.ConnectTimeout = 30;

            return sb.ToString();
        }

        public IEnumerable<T> GetAll<T>(string view = "")
        {
            var type = typeof(T);

            var command = _connection.CreateCommand();
            command.CommandText = string.IsNullOrEmpty(view) ? "SELECT * FROM " + type.Name : command.CommandText = "SELECT * FROM [" + view + "]";
            _connection.Open();
            var dataReader = command.ExecuteReader();
            var list = new List<T>();
            while (dataReader.Read())
            {
                var instance = (T)Activator.CreateInstance(type);
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    ExcludeNull<T>(dataReader, instance, propertyInfo);
                }
                list.Add(instance);
            }
            _connection.Close();
            return list;
        }

        public IEnumerable<T> GetById<T>(string id)
        {
            var type = typeof(T);

            var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + type.Name + " WHERE Id = " + id;
            _connection.Open();
            var dataReader = command.ExecuteReader();
            var list = new List<T>();
            while (dataReader.Read())
            {
                var instance = (T)Activator.CreateInstance(type);
                foreach (var propertyInfo in type.GetProperties())
                {
                    ExcludeNull<T>(dataReader, instance, propertyInfo);
                }
                list.Add(instance);
            }
            _connection.Close();
            return list;
        }

        private static void ExcludeNull<T>(SqlDataReader dataReader, T instance, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.Equals(typeof(string)))
            {
                if (dataReader[propertyInfo.Name].ToString().Equals(string.Empty))
                { propertyInfo.SetValue(instance, string.Empty); }
                else
                { propertyInfo.SetValue(instance, dataReader[propertyInfo.Name]); }
            }
            else if (propertyInfo.PropertyType.Equals(typeof(int)))
            {
                if (dataReader[propertyInfo.Name].ToString().Equals(string.Empty))
                { propertyInfo.SetValue(instance, 0); }
                else
                { propertyInfo.SetValue(instance, dataReader[propertyInfo.Name]); }
            }
            else
            {
                propertyInfo.SetValue(instance, dataReader[propertyInfo.Name]);
            }
        }
    }
}
    
    
    
