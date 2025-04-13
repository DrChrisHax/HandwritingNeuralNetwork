using HandwritingNeuralNetwork.SQLAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;

namespace HandwritingNeuralNetwork.Models
{
    public abstract class model_base : INotifyPropertyChanged
    {
        protected readonly string _connectionString = $"Server=localhost\\HWNN;Database=HWNN;User Id=sa;Password=abc123!@#;";

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        protected model_base() { }
        protected model_base(int id) 
        {
            string tableName = GetType().Name;
            string primaryKeyColumn = $"ID_{tableName}";
            string sql = $"SELECT * FROM {tableName} WHERE {primaryKeyColumn} = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LoadPropertiesFromReader(reader);
                        }
                        else
                        {
                            // If no record is found, set the primary key property to -1.
                            var pkProperty = PrimaryKeyProperty();
                            if (pkProperty != null && pkProperty.CanWrite)
                            {
                                pkProperty.SetValue(this, -1);
                            }
                        }
                    }
                }
            }
        }

        public void LoadRecordWhere(string sWhere)
        {
            // Determine the table name from the current type.
            string tableName = GetType().Name;
            string sql = $"SELECT * FROM {tableName} WHERE {sWhere}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LoadPropertiesFromReader(reader);
                        }
                        else
                        {
                            // If no record is found, set the primary key property to -1.
                            var pkProperty = PrimaryKeyProperty();
                            if (pkProperty != null && pkProperty.CanWrite)
                            {
                                pkProperty.SetValue(this, -1);
                            }
                        }
                    }
                }
            }
        }

        public bool AddRecord()
        {
            string sql = new SQLGenerator(this).GetSQLInsertStatement();
            int newId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out newId) && newId > 0)
                        {
                            //Update the primary key property with the new ID.
                            var pkProperty = PrimaryKeyProperty();
                            if (pkProperty != null && pkProperty.CanWrite)
                            {
                                pkProperty.SetValue(this, newId);
                            }
                            return true;
                        }
                        else
                        {
                            //If no valid ID is returned, set the PK property to -1.
                            var pkProperty = PrimaryKeyProperty();
                            if (pkProperty != null && pkProperty.CanWrite)
                            {
                                pkProperty.SetValue(this, -1);
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }
        }

        public bool UpdateRecord()
        {
            string sql = new SQLGenerator(this).GetSQLUpdateStatement();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }
        }

        public DataTable ExecuteSQLAsDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        private void LoadPropertiesFromReader(SqlDataReader reader)
        {
            // Get all public instance properties.
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                if (!reader.HasColumn(property.Name))
                {
                    throw new Exception(
                        $"Column '{property.Name}' does not exist in the table '{EntityName()}'.");
                }

                if (property.CanWrite)
                {
                    object value = reader[property.Name];
                    if (value is DBNull)
                    {
                        value = null;
                    }
                    property.SetValue(this, value);
                }
            }
        }

        public PropertyInfo PrimaryKeyProperty()
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                string lowerName = prop.Name.ToLower();
                if (lowerName.StartsWith("id_") || lowerName.EndsWith("id"))
                {
                    return prop;
                }
            }
            return null;
        }

        public PropertyInfo PropertyByName(string name)
        {
            var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.FirstOrDefault(p =>
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public List<PropertyInfo> Model_DataPropertiesWithoutPKOrRefs()
        {
            List<PropertyInfo> output = new List<PropertyInfo>();
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                if (p.CanWrite && !p.Name.ToLower().StartsWith("ref_") && !p.Equals(this.PrimaryKeyProperty()))
                {
                    output.Add(p);
                }
            }
            return output;
        }

        public virtual string EntityName()
        {
            string className = GetType().Name;
            const string modelSuffix = "_Model";
            if (className.EndsWith(modelSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return className.Substring(0, className.Length - modelSuffix.Length);
            }
            return className;
        }
    }

    #region Data Reader Extensions

    public static class SqlDataReaderExtensions
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
    

    
}
