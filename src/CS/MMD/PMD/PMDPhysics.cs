using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDPhysics
    {
        string                          Name            { get; set; }   // char[20]
        short                           Bone            { get; set; }
        byte                            Group           { get; set; }
        ushort                          Collision       { get; set; }
        byte                            Shape           { get; set; }
        GenVector3                      Size            { get; set; }
        GenVector3                      Position        { get; set; }
        GenVector3                      Rotation        { get; set; }
        float                           Mass            { get; set; }
        float                           MoveAttenuation { get; set; }
        float                           RotAttenuation  { get; set; }
        float                           Repulsion	    { get; set; }
        float                           Friction        { get; set; }
        byte                            Type            { get; set; }
    }

    public class PMDPhysics : IPMDPhysics
    {
        public string                   Name            { get; set; }
        public short                    Bone            { get; set; }
        public byte                     Group           { get; set; }
        public ushort                   Collision       { get; set; }
        public byte                     Shape           { get; set; }
        public GenVector3               Size            { get; set; }
        public GenVector3               Position        { get; set; }
        public GenVector3               Rotation        { get; set; }
        public float                    Mass            { get; set; }
        public float                    MoveAttenuation { get; set; }
        public float                    RotAttenuation  { get; set; }
        public float                    Repulsion	    { get; set; }
        public float                    Friction        { get; set; }
        public byte                     Type            { get; set; }
    }

    public interface IPMDPhysicsCollection : IList<IPMDPhysics>
    {
    }

    public class PMDPhysicsCollection : List<IPMDPhysics>, IPMDPhysicsCollection
    {
    }
    /*
    1F 00   Bone
    00      Group
    FF FF   Collision
    01      Shape

    00 00 80 3F width
    00 00 C0 3F
    CD CC CC 3E
    
    00 00 00 00 pos
    00 00 C0 3F
    00 00 00 00
    
    00 00 00 00 rot
    00 00 00 00
    00 00 00 00
    
    00 00 80 3F
    00 00 00 00
    00 00 00 00
    00 00 00 00
    00 00 00 00
    
    00  Type 0:Bone 1:Physics 2:Bone(Constraints)
    */
}
