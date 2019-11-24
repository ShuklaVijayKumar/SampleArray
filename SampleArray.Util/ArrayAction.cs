using System.Linq;
using System.Collections.Generic;
using System;

namespace SampleArray.Util
{
    public class ArrayAction : IArrayAction
    {
        public Result JoinAndSort(SortOrder  sortOrder, params string[][] arrays)
        {
            var result = new Result();

            var uniqueValues = new List<string>();
            var duplicateValues = new List<string>();

            foreach (string[] array in arrays)
            {
                foreach (string item in array)
                {
                    if (!uniqueValues.Contains(item, StringComparer.OrdinalIgnoreCase))
                        uniqueValues.Add(item);
                    else
                    {
                        if (!duplicateValues.Contains(item))
                            duplicateValues.Add(item);
                    }
                }
            }


            result.UniqueArray = ((sortOrder == SortOrder.AtoZ ? uniqueValues.OrderBy(x => x) : uniqueValues.OrderByDescending(x => x)).ToArray());
            result.DuplicateValues = duplicateValues.ToArray();

            return result;
        }
    }
}
