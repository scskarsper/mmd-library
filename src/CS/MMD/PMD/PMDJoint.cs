using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDJoint
    {
        string                          Name            { get; set; }   // char[20]
        int                             Object1         { get; set; }
        int                             Object2         { get; set; }
        GenVector3                      Position        { get; set; }
        GenVector3                      Rotation        { get; set; }
        GenVector3                      MoveLimitMin    { get; set; }
        GenVector3                      MoveLimitMax    { get; set; }
        GenVector3                      RotLimitMin     { get; set; }
        GenVector3                      RotLimitMax     { get; set; }
        GenVector3                      MoveSpring      { get; set; }
        GenVector3                      RotSpring       { get; set; }
    }

    public class PMDJoint : IPMDJoint
    {
        public string                   Name            { get; set; }
        public int                      Object1         { get; set; }
        public int                      Object2         { get; set; }
        public GenVector3               Position        { get; set; }
        public GenVector3               Rotation        { get; set; }
        public GenVector3               MoveLimitMin    { get; set; }
        public GenVector3               MoveLimitMax    { get; set; }
        public GenVector3               RotLimitMin     { get; set; }
        public GenVector3               RotLimitMax     { get; set; }
        public GenVector3               MoveSpring      { get; set; }
        public GenVector3               RotSpring       { get; set; }
    }

    public interface IPMDJointCollection : IList<IPMDJoint>
    {
    }

    public class PMDJointCollection : List<IPMDJoint>, IPMDJointCollection
    {
    }
}
