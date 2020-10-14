using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Implementation
{
    class testClass
    {
        public static List<string> processData(IEnumerable<string> lines)
        {
            static int ConvertToInt(string obj)
            {
                int.TryParse(obj, out var intVal);
                return intVal;
            }
            var splittedLines = lines.Select(obj => obj.Split(','));
            splittedLines.ToList().ForEach(obj => obj.ToList().ForEach(o=> o.Trim()));
            var discountedRows = splittedLines.GroupBy(obj => obj[3]).SelectMany(obj =>
            obj.Where(obj1 =>
                            obj1[3] == obj.Key &&
                            ConvertToInt(obj1[4]) < obj.Max(obj => ConvertToInt(obj[4]))).
                  Select(a => a)).Distinct().ToList();
            var finalRows = discountedRows.GroupBy(obj => obj[3]).SelectMany(
                obj => obj.Where(obj1 => obj1[3] == obj.Key && ConvertToInt(obj1[4]) == obj.Min(obj => ConvertToInt(obj[4]))).
                  Select(a => a[0])).Distinct().ToList();
            return finalRows;
        }
    }
}
