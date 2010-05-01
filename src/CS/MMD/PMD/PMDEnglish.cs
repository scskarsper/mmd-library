using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDEnglish
    {
        bool                            Enable          { get; set; }   // char
        string                          Name            { get; set; }   // char[20]
        string                          Comment         { get; set; }   // char[256]
        IList<string>                   BoneNames       { get; set; }   // char[20]
        IList<string>                   FaceNames       { get; set; }   // char[20]
        IList<string>                   BoneFrameNames  { get; set; }   // char[50]
    }

    public class PMDEnglish : IPMDEnglish
    {
        public bool                     Enable          { get; set; }
        public string                   Name            { get; set; }
        public string                   Comment         { get; set; }
        public IList<string>            BoneNames       { get; set; }
        public IList<string>            FaceNames       { get; set; }
        public IList<string>            BoneFrameNames  { get; set; }

        public PMDEnglish()
        {
            BoneNames       = new List<string>();
            FaceNames       = new List<string>();
            BoneFrameNames  = new List<string>();
        }
    }
}
