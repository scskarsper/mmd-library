using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDVertex
    {
        GenVector3              Position        { get; set; }   // float[3]
        GenVector3              Normal          { get; set; }   // float[3]
        GenVector2              Texcoord        { get; set; }   // float[3]
        short                   Bone1           { get; set; }   // short
        short                   Bone2           { get; set; }   // short
        short                   Weight          { get; set; }   // short
    }

    public class PMDVertex : IPMDVertex
    {
        public GenVector3       Position        { get; set; }
        public GenVector3       Normal          { get; set; }
        public GenVector2       Texcoord        { get; set; }
        public short            Bone1           { get; set; }
        public short            Bone2           { get; set; }
        public short            Weight          { get; set; }
    }

    public interface IPMDVertexCollection : IList<IPMDVertex>
    {
    }

    public class PMDVertexCollection : List<IPMDVertex>, IPMDVertexCollection
    {
    }
}
