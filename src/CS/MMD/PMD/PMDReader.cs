using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public class PMDReader : FileReader
    {
        public PMDData          Current         { get; private set; }

        public PMDReader(Stream s)
            : base(s)
        {
        }

        public IPMDData Read()
        {
            var value               = new PMDData();
            Current                 = value;
            value.Header            = ReadHeader();
            value.Vertices          = ReadCollection<PMDVertexCollection,    IPMDVertex>   (Reader.ReadInt32(), ReadVertex);
            value.Indices           = ReadCollection<PMDIndexCollection,     ushort>       (Reader.ReadInt32(), Reader.ReadUInt16);
            value.Materials         = ReadCollection<PMDMaterialCollection,  IPMDMaterial> (Reader.ReadInt32(), ReadMaterial);
            value.Bones             = ReadCollection<PMDBoneCollection,      IPMDBone>     (Reader.ReadInt16(), ReadBone);
            value.Iks               = ReadCollection<PMDIkCollection,        IPMDIk>       (Reader.ReadInt16(), ReadIk);
            value.Faces             = ReadCollection<PMDFaceCollection,      IPMDFace>     (Reader.ReadInt16(), ReadFace);
            value.FaceFrames        = ReadCollection<PMDFaceFrameCollection, short>        (Reader.ReadByte(),  Reader.ReadInt16);
            value.BoneFrames        = ReadCollection<PMDBoneFrameCollection, IPMDBoneFrame>(Reader.ReadByte(),  ReadBoneFrame);
            var targets             = ReadCollection<List<PMDBoneTarget>,    PMDBoneTarget>(Reader.ReadInt32(), ReadBoneTarget);
            value.English           = ReadEnglish();
            value.Toons             = ReadCollection<PMDToonCollection,      string>       (10,                 () => { return ReadString(100); });

            if(BaseStream.Position == BaseStream.Length)
                return value;

            value.Physicses         = ReadCollection<PMDPhysicsCollection,   IPMDPhysics>  (Reader.ReadInt32(), ReadPhysics);
            value.Joints            = ReadCollection<PMDJointCollection,     IPMDJoint>    (Reader.ReadInt32(), ReadJoint);

            foreach(var i in targets)
                value.BoneFrames[i.Frame-1].Targets.Add(i);

            return value;
        }

        private IPMDHeader ReadHeader()
        {
          //DebugPrintOffset("ReadHeader");
            var value               = new PMDHeader();
            value.Magic             = ReadString(3);
            value.Version           = Reader.ReadSingle();
            value.Name              = ReadString(20);
            value.Comment           = ReadString(256);

            return value;
        }

        private IPMDVertex ReadVertex()
        {
          //DebugPrintOffset("ReadVertex");
            var value               = new PMDVertex();
            value.Position          = ReadVector3();
            value.Normal            = ReadVector3();
            value.Texcoord          = ReadVector2();
            value.Bone1             = Reader.ReadInt16();
            value.Bone2             = Reader.ReadInt16();
            value.Weight            = Reader.ReadInt16();

            return value;
        }

        private IPMDMaterial ReadMaterial()
        {
          //DebugPrintOffset("ReadMaterial");
            var value               = new PMDMaterial();
            value.Diffuse           = ReadColor4();
            value.Shininess         = Reader.ReadSingle();
            value.Specular          = ReadColor3();
            value.Emissive          = ReadColor3();
            value.ToonNo            = Reader.ReadByte();
            value.Edge              = Reader.ReadByte();
            value.IndexCount        = Reader.ReadInt32();
            value.Texture           = ReadString(20);

            return value;
        }

        private IPMDBone ReadBone()
        {
          //DebugPrintOffset("ReadBone");
            var value               = new PMDBone();
            value.Name              = ReadString(20);
            value.Parent            = Reader.ReadInt16();
            value.Child             = Reader.ReadInt16();
            value.Type              = Reader.ReadInt16();
            value.IKBone            = Reader.ReadByte();
            value.Position          = ReadVector3();

            return value;
        }

        private IPMDIk ReadIk()
        {
          //DebugPrintOffset("ReadIk");
            var value               = new PMDIk();
            value.Ik                = Reader.ReadInt16();
            value.Target            = Reader.ReadInt16();
            var count               = Reader.ReadByte();
            value.Value1            = Reader.ReadInt16();
            value.Value2            = Reader.ReadSingle();

            for(int i= 0; i < count; ++i)
                value.Effects.Add(Reader.ReadInt16());

            return value;
        }

        private IPMDFace ReadFace()
        {
          //DebugPrintOffset("ReadFace");
            var value               = new PMDFace();
            value.Name              = ReadString(20);
            var count               = Reader.ReadInt32();
            value.Type              = Reader.ReadByte();

            for(int i= 0; i < count; ++i)
                value.Vertices.Add(ReadFaceVertex());

            return value;
        }

        private PMDFaceVertex ReadFaceVertex()
        {
          //DebugPrintOffset("ReadFaceVertex");
            var value               = new PMDFaceVertex();
            value.Index             = Reader.ReadInt32();
            value.Position          = ReadVector3();

            return value;
        }

        private IPMDBoneFrame ReadBoneFrame()
        {
          //DebugPrintOffset("ReadBoneFrame");
            var value               = new PMDBoneFrame();
            value.Name              = ReadString(50);

            return value;
        }

        private PMDBoneTarget ReadBoneTarget()
        {
          //DebugPrintOffset("ReadBoneTarget");
            var value               = new PMDBoneTarget();
            value.Bone              = Reader.ReadInt16();
            value.Frame             = Reader.ReadByte();

            return value;
        }

        private IPMDEnglish ReadEnglish()
        {
          //DebugPrintOffset("ReadEnglish");
            var value               = new PMDEnglish();
            var eng                 = Reader.ReadByte();

            if(eng == 0)
                return value;

            int bonecount           = Current.Bones.Count;
            int facecount           = Current.Faces.Count;
            int boneframecount      = Current.BoneFrames.Count;
            value.Enable            = true;
            value.Name              = ReadString(20);
            value.Comment           = ReadString(256);
            value.BoneNames         = ReadCollection<List<string>, string>      (bonecount-1,    () => { return ReadString(20); });
            value.FaceNames         = ReadCollection<List<string>, string>      (facecount,      () => { return ReadString(20); });
            value.BoneFrameNames    = ReadCollection<List<string>, string>      (boneframecount, () => { return ReadString(50); });
 
            return value;
        }

        private IPMDPhysics ReadPhysics()
        {
          //DebugPrintOffset("ReadPhysics");
            var value               = new PMDPhysics();
            value.Name              = ReadString(20);
            value.Bone              = Reader.ReadInt16();
            value.Group             = Reader.ReadByte();
            value.Collision         = Reader.ReadUInt16();
            value.Shape             = Reader.ReadByte();
            value.Size              = ReadVector3();
            value.Position          = ReadVector3();
            value.Rotation          = ReadVector3();
            value.Mass              = Reader.ReadSingle();
            value.MoveAttenuation   = Reader.ReadSingle();
            value.RotAttenuation    = Reader.ReadSingle();
            value.Repulsion	        = Reader.ReadSingle();
            value.Friction          = Reader.ReadSingle();
            value.Type              = Reader.ReadByte();

            return value;
        }

        private IPMDJoint ReadJoint()
        {
          //DebugPrintOffset("ReadJoint");
            var value               = new PMDJoint();
            value.Name              = ReadString(20);
            value.Object1           = Reader.ReadInt32();
            value.Object2           = Reader.ReadInt32();
            value.Position          = ReadVector3();
            value.Rotation          = ReadVector3();
            value.MoveLimitMin      = ReadVector3();
            value.MoveLimitMax      = ReadVector3();
            value.RotLimitMin       = ReadVector3();
            value.RotLimitMax       = ReadVector3();
            value.MoveSpring        = ReadVector3();
            value.RotSpring         = ReadVector3();

            return value;
        }
    }
}
