using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDFace
    {
        string                          Name            { get; set; }   // char[20]
      //int                             Count           { get; set; }   // int
        byte                            Type            { get; set; }   // byte
        IList<PMDFaceVertex>            Vertices        { get; set; }
    }

    public class PMDFace : IPMDFace
    {
        public string                   Name            { get; set; }   // char[20]
      //public int                      Count           { get; set; }   // int
        public byte                     Type            { get; set; }   // byte
        public IList<PMDFaceVertex>     Vertices        { get; set; }

        public PMDFace()
        {
            Vertices    = new List<PMDFaceVertex>();
        }
    }

    public struct PMDFaceVertex
    {
        public int                      Index;
        public GenVector3               Position;
    }

    public interface IPMDFaceCollection : IList<IPMDFace>
    {
    }

    public class PMDFaceCollection : List<IPMDFace>, IPMDFaceCollection
    {
    }
}
