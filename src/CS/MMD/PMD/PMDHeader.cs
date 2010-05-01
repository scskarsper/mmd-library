using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDHeader
    {
        string                          Magic           { get; set; }   // char[3]
        float                           Version         { get; set; }   // float
        string                          Name            { get; set; }   // char[20]
        string                          Comment         { get; set; }   // char[256];
    }

    public class PMDHeader : IPMDHeader
    {
        public string                   Magic           { get; set; }
        public float                    Version         { get; set; }
        public string                   Name            { get; set; }
        public string                   Comment         { get; set; }

        public PMDHeader()
        {
            Magic       = "PMD";
            Version     = 1.0f;
        }
    }
}
