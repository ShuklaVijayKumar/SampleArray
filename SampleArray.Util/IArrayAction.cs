using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArray.Util
{
    public interface IArrayAction
    {
        Result JoinAndSort(SortOrder sortOrder, params string[][] arrays);
    }
}
