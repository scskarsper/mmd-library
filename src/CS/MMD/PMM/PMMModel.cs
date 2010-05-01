using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public interface IPMMModel
    {
        IPMMData                        Owner           { get; }
        PMD.IPMDData                    PMD             { get; set; }
	    byte                            ModelIndex      { get; set; }   // BYTE
	    string                          Name            { get; set; }   // char[20]
	    string                          File            { get; set; }   // char[256]
        byte                            ModelID         { get; set; }   // byte
        byte                            Display         { get; set; }   // byte
        uint                            SelectedBones   { get; set; }   // uint
        uint[]                          SelectedFaces   { get; set; }   // uint[4]
      //int                             FrameCount      { get; set; }   // int
        IList<byte>                     FrameDisplay    { get; set; }   // byte[FrameCount]
        int                             FrameUpNo       { get; set; }   // int
        int                             LastFrame       { get; set; }   // int
        IPMMBoneData                    BoneData        { get; set; }
        IPMMFaceData                    FaceData        { get; set; }
        IPMMIkData                      IkData          { get; set; }
    }

    public class PMMModel : IPMMModel
    {
        public IPMMData                 Owner           { get; private set; }
        public PMD.IPMDData             PMD             { get; set; }
	    public byte                     ModelIndex      { get; set; }
	    public string                   Name            { get; set; }
	    public string                   File            { get; set; }
        public byte                     ModelID         { get; set; }
        public byte                     Display         { get; set; }
        public uint                     SelectedBones   { get; set; }
        public uint[]                   SelectedFaces   { get; set; }
      //public int                      FrameCount      { get; set; }
        public IList<byte>              FrameDisplay    { get; set; }
        public int                      FrameUpNo       { get; set; }
        public int                      LastFrame       { get; set; }
        public IPMMBoneData             BoneData        { get; set; }
        public IPMMFaceData             FaceData        { get; set; }
        public IPMMIkData               IkData          { get; set; }

        public PMMModel(IPMMData owner)
        {
            Owner   = owner;
        }
    }

    public interface IPMMModelCollection : IList<IPMMModel>
    {
    }

    public class PMMModelCollection : List<IPMMModel>, IPMMModelCollection
    {
    }
}
