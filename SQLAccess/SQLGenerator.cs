using HandwritingNeuralNetwork.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandwritingNeuralNetwork.SQLAccess
{
    public class SQLGenerator
    {
        private model_base _mdl;

        public SQLGenerator(model_base mdl)
        {
            _mdl = mdl;
        }

        public string GetSQLInsertStatement()
        {
            string sColumns = string.Empty;
            string sValues = string.Empty;
            List<PropertyInfo> lstProps = _mdl.Model_DataPropertiesWithoutPKOrRefs();

            foreach (PropertyInfo p in lstProps)
            {
                sColumns = AppendCommaSeperatedString(sColumns, $"[{p.Name}]");
                sValues = AppendCommaSeperatedString(sValues, PropertyToValidValue(_mdl, p));
            }
            return $"INSERT INTO {_mdl.EntityName()} ({sColumns}) VALUES ({sValues}); SELECT SCOPE_IDENTITY();";
        }

        public string GetSQLUpdateStatement()
        {
            string sClause = string.Empty;
            List<PropertyInfo> lstProps = _mdl.Model_DataPropertiesWithoutPKOrRefs();
            foreach(PropertyInfo p in lstProps)
            {
                sClause = AppendCommaSeperatedString(sClause, $"[{p.Name}] = {PropertyToValidValue(_mdl, p)}");
            }

            return $"UPDATE {_mdl.EntityName()} SET {sClause} WHERE {_mdl.EntityName()}.{_mdl.PrimaryKeyProperty().Name} = " +
                   $"{PropertyToValidValue(_mdl, _mdl.PrimaryKeyProperty())}";
        }

        private string AppendCommaSeperatedString(string val, string append)
        {
            if(val.Length == 0)
            {
                return append;
            } else
            {
                return val + ", " + append;
            }
        }

        private string PropertyToValidValue(Object model, PropertyInfo pi)
        {
            string strValue = string.Empty;
            object oValue = pi.GetValue(model, null);
            Type tp = pi.PropertyType;
            string sFormat = string.Empty;

            if (tp.Equals(typeof(string)) || tp.Equals(typeof(char)))
            {
                if (oValue != null)
                {
                    strValue = string.Format("'{0}'", oValue.ToString().Replace("'", "''"));
                }
                else
                {
                    strValue = "NULL";
                }
            }
            else if (tp.Equals(typeof(DateTime)))
            {
                if (oValue != null && !((DateTime)oValue).Equals(new DateTime()))
                {
                    // Manage for SQL datetime limits.
                    DateTime dateValue = (DateTime)oValue;
                    if (dateValue < Shared.Types.SQLMinDate())
                        dateValue = Shared.Types.SQLMinDate();
                    if (dateValue > Shared.Types.SQLMaxDate())
                        dateValue = Shared.Types.SQLMaxDate();


                     sFormat = "yyyyMMdd HH:mm:ss";
                     strValue = "'" + dateValue.ToString(sFormat) + "'";

                }
                else
                {
                    strValue = "NULL";
                }
            }
            else if (tp.Equals(typeof(decimal)))
            {
                strValue = oValue != null ? ((decimal)oValue).ToString(CultureInfo.InvariantCulture) : "NULL";
            }
            else if (tp.Equals(typeof(double)))
            {
                strValue = oValue != null ? ((double)oValue).ToString(CultureInfo.InvariantCulture) : "NULL";
            }
            else if (tp.Equals(typeof(float))) // Single in VB
            {
                strValue = oValue != null ? ((float)oValue).ToString(CultureInfo.InvariantCulture) : "NULL";
            }
            else if (tp.Equals(typeof(long)) || tp.Equals(typeof(int)) ||
                     tp.Equals(typeof(short)) || tp.Equals(typeof(byte)) ||
                     tp.Equals(typeof(sbyte)) || tp.Equals(typeof(ushort)) ||
                     tp.Equals(typeof(uint)) || tp.Equals(typeof(ulong)))
            {
                strValue = oValue.ToString();
            }
            else if (tp.Equals(typeof(bool)))
            {
                if (oValue != null)
                {
                    strValue = ((bool)oValue) ? "1" : "0";
                }
                else
                {
                    strValue = "NULL";
                }
            }
            else if (tp.Equals(typeof(byte[])) || tp.GetTypeInfo().Name == "Byte[]")
            {
                if (oValue != null)
                {
                    byte[] byteArray = (byte[])oValue;
                    int length = byteArray.Length;
                    StringBuilder sb = new StringBuilder((length * 3) - 1);
                    sb.Append("0x"); // We need this

                    if (byteArray.Length <= 5120) // 5120 bytes (5 KB)
                    {
                        sb.Append(BitConverter.ToString(byteArray));
                    }
                    else
                    {
                        sb = BuildStringFromLargeByteArray((byte[])oValue, sb);
                    }
                    strValue = sb.ToString().Trim().Replace("-", "");
                }
                else
                {
                    strValue = "NULL";
                }
            }
            else if (tp.Equals(typeof(Guid)))
            {
                if (oValue != null)
                {
                    strValue = string.Format("'{0}'", oValue.ToString());
                }
                else
                {
                    strValue = "NULL";
                }
            }
            else
            {
                throw new Exception("Type " + tp.Name + " cannot be passed to the database");
            }

            return strValue;
        }

        private StringBuilder BuildStringFromLargeByteArray(byte[] byts, StringBuilder sb)
        {
            int pos = 0;
            while (pos < byts.Length - 1000)
            {
                sb.Append(BitConverter.ToString(byts, pos, 1000));
                pos += 1000;
            }
            sb.Append(BitConverter.ToString(byts, pos, byts.Length - pos));
            return sb;
        }
    }
}
