using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    public interface IDataConvertable
    {
        byte[] ToByteArray();
    }

    internal class EntityTableConverter
    {

        public static DataTable ToDataTable(IEnumerable<IDataConvertable> items)
        {
            var list = items?.ToList() ?? new List<IDataConvertable>();
            var table = new DataTable();

            if (list.Count == 0)
                return table;

            Type itemType = list[0].GetType();
            PropertyInfo[] props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                Type columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, columnType);
            }

            foreach (var item in list)
            {
                DataRow row = table.NewRow();

                foreach (var prop in props)
                {
                    object value = prop.GetValue(item);

                    if (value == null)
                        row[prop.Name] = DBNull.Value;
                    else if (value is byte[] bytes)
                        row[prop.Name] = BitConverter.ToString(bytes);
                    else
                        row[prop.Name] = value;
                }

                table.Rows.Add(row);
            }

            return table;
        }
        public static DataTable ToDataTable(IEnumerable<IDbEntity> items)
        {
            var list = items?.ToList() ?? new List<IDbEntity>();
            var table = new DataTable();

            if (list.Count == 0)
                return table;

            Type itemType = list[0].GetType();
            PropertyInfo[] props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                Type columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, columnType);
            }

            foreach (var item in list)
            {
                DataRow row = table.NewRow();

                foreach (var prop in props)
                {
                    object value = prop.GetValue(item);

                    if (value == null)
                        row[prop.Name] = DBNull.Value;
                    else if (value is byte[] bytes)
                        row[prop.Name] = BitConverter.ToString(bytes);
                    else
                        row[prop.Name] = value;
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
