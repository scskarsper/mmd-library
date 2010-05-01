using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDBoneFrame
    {
        string                          Name            { get; set; }   // char[50]
        IList<PMDBoneTarget>            Targets         { get; set; }
    }

    public class PMDBoneFrame : IPMDBoneFrame
    {
        public string                   Name            { get; set; }   // char[20]
        public IList<PMDBoneTarget>     Targets         { get; set; }

        public PMDBoneFrame()
        {
            Targets = new List<PMDBoneTarget>();
        }
    }

    public struct PMDBoneTarget
    {
        public short                    Bone;
        public byte                     Frame;
    }

    public interface IPMDBoneFrameCollection : IList<IPMDBoneFrame>
    {
    }

    public class PMDBoneFrameCollection : List<IPMDBoneFrame>, IPMDBoneFrameCollection
    {
    }
}
