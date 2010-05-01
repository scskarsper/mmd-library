using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDFaceFrameCollection : IList<short>
    {
    }

    public class PMDFaceFrameCollection : List<short>, IPMDFaceFrameCollection
    {
    }
}
