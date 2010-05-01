using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public struct PMMIPL
    {
        public byte X0, X1, Y0, Y1;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", X0, X1, Y0, Y1);
        }
    }

    public interface IPMMKey
    {
        uint                            Frame           { get; set; }
        uint                            BeforeIndex     { get; set; }
        uint                            AfterIndex      { get; set; }
    }

    public class PMMKey : IPMMKey
    {
        public uint                     Frame           { get; set; }
        public uint                     BeforeIndex     { get; set; }
        public uint                     AfterIndex      { get; set; }
    }
}
