using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

public static class Db2Linq
{
    public static T ConvertToEntity<T>(this DataRow tableRow)
        where T: new()
    {
        // Create a new type of the entity I want
        Type t = typeof(T);
        T returnObject = new T();

        foreach (DataColumn col in tableRow.Table.Columns)
        {
            string colName = col.ColumnName;

            // Look for the object's property with the columns name, ignore case
            PropertyInfo pInfo = t.GetProperty(colName.ToLower(),
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // did we find the property ?
            if (pInfo != null)
            {
                object val = tableRow[colName];
                if (colName.ToLower() == "amount4")
                {
                    val = tableRow[colName];
                }
                // is this a Nullable<> type
                bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null || val is System.DBNull);
                if (IsNullable)
                {
                    if (val is System.DBNull)
                    {
                        val = null;
                    }
                    else
                    {
                        // Convert the db type into the T we have in our Nullable<T> type
                        val = Convert.ChangeType
                        (val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                    }
                }
                else
                {
                    // Convert the db type into the type of the property in our entity
                    try
                    {
                        val = Convert.ChangeType(val, pInfo.PropertyType);
                    }
                    catch (Exception ex)
                    {
                        //ex;
                    }
                }
                // Set the value of the property with the value from the db
                pInfo.SetValue(returnObject, val, null);
            }
        }

        // return the entity object with values
        return returnObject;
    }

    public static List<T> ConvertToList<T>(this DataTable table)
        where T: new()
    {
        Type t = typeof(T);

        // Create a list of the entities we want to return
        List<T> returnObject = new List<T>();

        // Iterate through the DataTable's rows
        foreach (DataRow dr in table.Rows)
        {
            // Convert each row into an entity object and add to the list
            try
            {
                T newRow = dr.ConvertToEntity<T>();
                returnObject.Add(newRow);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //returnObject.Add(newRow);
        }

        // Return the finished list
        return returnObject;
    }

    public static DataTable ConvertToDataTable(this object obj)
    {
        // Retrieve the entities property info of all the properties
        PropertyInfo[] pInfos = obj.GetType().GetProperties();

        // Create the new DataTable
        var table = new DataTable();
        try
        {

            // Iterate on all the entities' properties
            foreach (PropertyInfo pInfo in pInfos)
            {
                // Create a column in the DataTable for the property
                table.Columns.Add(pInfo.Name, pInfo.GetType());
            }

            // Create a new row of values for this entity
            DataRow row = table.NewRow();
            // Iterate again on all the entities' properties
            foreach (PropertyInfo pInfo in pInfos)
            {
                // Copy the entities' property value into the DataRow
                row[pInfo.Name] = pInfo.GetValue(obj, null);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        // Return the finished DataTable
        return table;
    }

    public static IEnumerable<ValueName> GetItems<TEnum>()
        where TEnum: struct, IConvertible, IComparable, IFormattable
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("TEnum must be an Enumeration type");

        var res = from e in Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                                          select new ValueName()
                  { Value = Convert.ToInt32(e), Name = e.ToString()
                  };

        return res;
    }
}

public struct ValueName
{
    public int Value { get; set; }

    public string Name { get; set; }
}

