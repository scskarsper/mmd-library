using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDToonCollection : IList<string>
    {
    }

    public class PMDToonCollection : List<string>, IPMDToonCollection
    {
    }
}
