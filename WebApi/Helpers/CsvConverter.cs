using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebApi.Helpers
{
    public static class CsvConverter
    {
        public static string ToCsv<T>(IEnumerable<T> items)
        {
            //Getting names of instances in list
            Type itemsType = typeof(T);
            var itemsFieldNames = itemsType.GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(x => x.Name);

            StringBuilder csvString = new StringBuilder();
            foreach (var item in items)
            {
            csvString.AppendLine(string.Join(", ",itemsFieldNames.Select(x => x.GetValue(item, null))));
            }
            return csvString.ToString();
        }
    }
}