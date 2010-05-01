using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDIndexCollection : IList<ushort>
    {
    }

    public class PMDIndexCollection : List<ushort>, IPMDIndexCollection
    {
    }
}
