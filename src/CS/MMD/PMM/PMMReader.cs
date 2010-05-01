using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MikuMiku.PMM
{
    public class PMMReader : FileReader
    {
        public const string MAGIC   = "Polygon Movie maker 0001";
        public string   BaseDirectory   { get; set; }
        public IPMMData Current         { get; private set; }

        public PMMReader(Stream s)
            : base(s)
        {
            if(s is FileStream)
                BaseDirectory   = Path.GetDirectoryName(((FileStream)s).Name);
        }

        public IPMMData Read()
        {
            var value               = new PMMData();
            Current                 = value;
            value.Header            = ReadHeader();
            value.ModelNames        = ReadCollection<List<string>,           string>       (value.Header.ModelCount, () => { return ReadString(20); });
            value.Models            = ReadCollection<PMMModelCollection,     IPMMModel>    (value.Header.ModelCount, ReadModel);
            value.CameraData        = new PMMCameraData();
            value.LightData         = new PMMLightData();
            value.CameraData.InitKey= ReadCameraInitKey();
            value.CameraData.Keys   = ReadCollection<PMMCameraKeyCollection, IPMMCameraKey>(Reader.ReadInt32(), ReadCameraKey);
            value.CameraData.State  = ReadCameraState();
            value.LightData.InitKey = ReadLightInitKey();
            value.LightData.Keys    = ReadCollection<PMMLightKeyCollection,  IPMMLightKey> (Reader.ReadInt32(), ReadLightKey);
            value.LightData.State   = ReadLightState();
            value.AcsData           = ReadAcsData();
            value.FrameWindow       = ReadFrameWindow();
            value.Wav               = ReadWav();
            value.Avi               = ReadAvi();
            value.Bmp               = ReadBmp();
            value.ViewInfo          = ReadViewInfo();
            
            return value;
        }

        private IPMMHeader ReadHeader()
        {
            DebugPrintOffset("ReadHeader");
            var value               = new PMMHeader();
            value.Magic             = ReadString(30);
            value.ViewWidth         = Reader.ReadInt32();
            value.ViewHeight        = Reader.ReadInt32();
            value.FrameWidth        = Reader.ReadInt32();
            value.ViewAngle         = Reader.ReadSingle();
            value.Flags             = Reader.ReadBytes(6);
	        value.ModelNo           = Reader.ReadByte();
	        value.ModelCount        = Reader.ReadByte();

            return value;
        }

        public IPMMModel ReadModel()
        {
            DebugPrintOffset("ReadModel");
            var value               = new PMMModel(Current);
            value.ModelIndex        = Reader.ReadByte();
            value.Name              = ReadString(20);
            value.File              = ReadString(256);
            value.ModelID           = Reader.ReadByte();
            value.Display           = Reader.ReadByte();
	        value.SelectedBones     = Reader.ReadUInt32();
	        value.SelectedFaces     = ReadCollection<List<uint>, uint>(4,                 Reader.ReadUInt32).ToArray();
            value.FrameDisplay      = ReadCollection<List<byte>, byte>(Reader.ReadByte(), Reader.ReadByte);
            value.FrameUpNo         = Reader.ReadInt32();
            value.LastFrame         = Reader.ReadInt32();
            var pmdfile             = Path.Combine(BaseDirectory, Path.GetFileName(value.File));
            var pmd                 = PMD.PMDData.FromFile(pmdfile);
            value.BoneData          = new PMMBoneData(value);
            value.FaceData          = new PMMFaceData(value);
            value.IkData            = new PMMIkData(value);
            value.BoneData.InitKeys = ReadCollection<PMMBoneInitKeyCollection, IPMMBoneInitKey>(pmd.Bones.Count,    ReadBoneInitKey);
            value.BoneData.Keys     = ReadCollection<PMMBoneKeyCollection,     IPMMBoneKey>    (Reader.ReadInt32(), ReadBoneKey);
            value.FaceData.InitKeys = ReadCollection<PMMFaceInitKeyCollection, IPMMFaceInitKey>(pmd.Faces.Count,    ReadFaceInitKey);
            value.FaceData.Keys     = ReadCollection<PMMFaceKeyCollection,     IPMMFaceKey>    (Reader.ReadInt32(), ReadFaceKey);
            value.IkData  .InitKey  = ReadIkInitKey(pmd.Iks.Count);
            value.IkData  .Keys     = ReadCollection<PMMIkKeyCollection,       IPMMIkKey>      (Reader.ReadInt32(), () => { return ReadIkKey(pmd.Iks.Count); });
            value.BoneData.States   = ReadCollection<PMMBoneStateCollection,   IPMMBoneState>  (pmd.Bones.Count,    ReadBoneState);
            value.FaceData.States   = ReadCollection<List<float>,              float>          (pmd.Faces.Count,    Reader.ReadSingle);
            value.IkData  .States   = ReadCollection<List<byte>,               byte>           (pmd.Iks.Count,      Reader.ReadByte);

            return value;
        }

        private PMMIPL          ReadIPL()
        {
            var value           = new PMMIPL();
            value.X0            = Reader.ReadByte();
            value.X1            = Reader.ReadByte();
            value.Y0            = Reader.ReadByte();
            value.Y1            = Reader.ReadByte();

            return value;
        }

        private IPMMBoneInitKey ReadBoneInitKey()
        {
          //DebugPrintOffset("ReadBoneInitKey");
            var value           = new PMMBoneInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.IplR          = ReadIPL();
            value.IplX          = ReadIPL();
            value.IplY          = ReadIPL();
            value.IplZ          = ReadIPL();
            value.Translation   = ReadVector3();
            value.Rotation      = ReadVector4();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMBoneKey     ReadBoneKey()
        {
          //DebugPrintOffset("ReadBoneKey");
            var value           = new PMMBoneKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.IplR          = ReadIPL();
            value.IplX          = ReadIPL();
            value.IplY          = ReadIPL();
            value.IplZ          = ReadIPL();
            value.Translation   = ReadVector3();
            value.Rotation      = ReadVector4();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMFaceInitKey ReadFaceInitKey()
        {
          //DebugPrintOffset("ReadFaceInitKey");
            var value           = new PMMFaceInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.SkinValue     = Reader.ReadSingle();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMFaceKey     ReadFaceKey()
        {
          //DebugPrintOffset("ReadFaceKey");
            var value           = new PMMFaceKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.SkinValue     = Reader.ReadSingle();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMIkInitKey   ReadIkInitKey(int ikcount)
        {
          //DebugPrintOffset("ReadIkInitKey");
            var value           = new PMMIkInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Display       = Reader.ReadByte();
            value.IKs           = Reader.ReadBytes(ikcount);
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMIkKey       ReadIkKey(int ikcount)
        {
          //DebugPrintOffset("ReadIkKey");
            var value           = new PMMIkKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Display       = Reader.ReadByte();
            value.IKs           = Reader.ReadBytes(ikcount);
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMBoneState   ReadBoneState()
        {
          //DebugPrintOffset("ReadBoneState");
            var value           = new PMMBoneState();
            value.Translation   = ReadVector3();
            value.Rotation      = ReadVector4();
            value.RotationX     = Reader.ReadSingle();
            value.Moved         = Reader.ReadByte();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMCameraInitKey ReadCameraInitKey()
        {
          //DebugPrintOffset("ReadCameraInitKey");
            var value           = new PMMCameraInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Distance      = Reader.ReadUInt32();
            value.Position      = ReadVector3();
            value.Angle         = ReadVector3();
            value.IPL_X         = ReadIPL();
            value.IPL_Y         = ReadIPL();
            value.IPL_Z         = ReadIPL();
            value.IPL_R         = ReadIPL();
            value.IPL_Distance  = ReadIPL();
            value.IPL_Parse     = ReadIPL();
            value.IsOrth        = Reader.ReadByte();
	        value.ParseAngle    = Reader.ReadUInt32();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMCameraKey ReadCameraKey()
        {
          //DebugPrintOffset("ReadCameraKey");
            var value           = new PMMCameraKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Distance      = Reader.ReadUInt32();
            value.Position      = ReadVector3();
            value.Angle         = ReadVector3();
            value.IPL_X         = ReadIPL();
            value.IPL_Y         = ReadIPL();
            value.IPL_Z         = ReadIPL();
            value.IPL_R         = ReadIPL();
            value.IPL_Distance  = ReadIPL();
            value.IPL_Parse     = ReadIPL();
            value.IsOrth        = Reader.ReadByte();
	        value.ParseAngle    = Reader.ReadUInt32();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMCameraState ReadCameraState()
        {
          //DebugPrintOffset("ReadCameraState");
            var value           = new PMMCameraState();
            value.Position      = ReadVector3();
            value.ViewPosition  = ReadVector3();
            value.Angle         = ReadVector3();
            value.IsParse       = Reader.ReadByte();

            return value;
        }

        private IPMMLightInitKey ReadLightInitKey()
        {
          //DebugPrintOffset("ReadLightInitKey");
            var value           = new PMMLightInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Color         = ReadVector3();
	        value.Direction     = ReadVector3();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMLightKey ReadLightKey()
        {
          //DebugPrintOffset("ReadLightKey");
            var value           = new PMMLightKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
            value.Color         = ReadVector3();
	        value.Direction     = ReadVector3();
            value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMLightState ReadLightState()
        {
          //DebugPrintOffset("ReadLightState");
            var value           = new PMMLightState();
            value.Color         = ReadVector3();
	        value.Direction     = ReadVector3();

            return value;
        }

        private IPMMAcsData ReadAcsData()
        {
            DebugPrintOffset("ReadAcsData");
            var value           = new PMMAcsData();
            value.AcsNo         = Reader.ReadByte();
	        value.AcsFrameUpNo  = Reader.ReadUInt32();
	        value.AcsCount      = Reader.ReadByte();
            value.WindowNames   = ReadCollection<List<string>,     string> (value.AcsCount, () => { return ReadString(100); });
            value.Acses         = ReadCollection<PMMAcsCollection, IPMMAcs>(value.AcsCount, ReadAcs);

            return value;
        }

        private IPMMAcs ReadAcs()
        {
          //DebugPrintOffset("ReadAcs");
            var value           = new PMMAcs();
            value.Index         = Reader.ReadByte();
            value.Name          = ReadString(100);
	        value.File          = ReadString(256);
	        value.ID            = Reader.ReadByte();
            value.InitKey       = ReadAcsInitKey();
            value.Keys          = ReadCollection<PMMAcsKeyCollection, IPMMAcsKey>(Reader.ReadInt32(), ReadAcsKey);
            value.State         = ReadAcsState();

            return value;
        }

        private IPMMAcsInitKey ReadAcsInitKey()
        {
          //DebugPrintOffset("ReadAcsInitKey");
            var value           = new PMMAcsInitKey();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
	        value.Display       = Reader.ReadByte();
	        value.Model         = Reader.ReadUInt32();
            value.Bone          = Reader.ReadUInt32();
	        value.Position      = ReadVector3();
	        value.Angle         = ReadVector3();
	        value.Size          = Reader.ReadUInt32();
	        value.Shadow        = Reader.ReadByte();
	        value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMAcsKey ReadAcsKey()
        {
          //DebugPrintOffset("ReadAcsKey");
            var value           = new PMMAcsKey();
            value.DataIndex     = Reader.ReadUInt32();
            value.Frame         = Reader.ReadUInt32();
            value.BeforeIndex   = Reader.ReadUInt32();
            value.AfterIndex    = Reader.ReadUInt32();
	        value.Display       = Reader.ReadByte();
	        value.Model         = Reader.ReadUInt32();
            value.Bone          = Reader.ReadUInt32();
	        value.Position      = ReadVector3();
	        value.Angle         = ReadVector3();
	        value.Size          = Reader.ReadUInt32();
	        value.Shadow        = Reader.ReadByte();
	        value.Selected      = Reader.ReadByte();

            return value;
        }

        private IPMMAcsState ReadAcsState()
        {
          //DebugPrintOffset("ReadAcsState");
            var value           = new PMMAcsState();
	        value.Display       = Reader.ReadByte();
	        value.Model         = Reader.ReadUInt32();
            value.Bone          = Reader.ReadUInt32();
	        value.Angle         = ReadVector3();
            value.Size          = Reader.ReadUInt32();
	        value.Position      = ReadVector3();
	        value.Shadow        = Reader.ReadByte();

            return value;
        }

        private IPMMFrameWindow ReadFrameWindow()
        {
          //DebugPrintOffset("ReadFrameWindow");
            var value           = new PMMFrameWindow();
            value.FrameWidnowCount      = Reader.ReadUInt32();
            value.FrameWidnowPosition   = Reader.ReadUInt32();
            value.FrameWidnowLast       = Reader.ReadUInt32();
            value.BoneWindowFace        = Reader.ReadUInt32();
            value.PlayWindow_TraceModel = Reader.ReadByte();
            value.PlayWindow_Loop       = Reader.ReadByte();
            value.PlayWindow_FrameStart = Reader.ReadByte();
            value.PlayWindow_FrameStop  = Reader.ReadByte();
            value.PlayWindow_St         = Reader.ReadUInt32();
            value.PlayWindow_Ed         = Reader.ReadUInt32();

            return value;
        }

        private IPMMWav ReadWav()
        {
          //DebugPrintOffset("ReadWav");
            var value           = new PMMWav();
            value.Enable        = Reader.ReadByte();
            value.File          = ReadString(256);

            return value;
        }

        private IPMMAvi ReadAvi()
        {
          //DebugPrintOffset("ReadAvi");
            var value           = new PMMAvi();
            value.Position      = ReadVector3();
            value.File          = ReadString(256);
            value.AviDisp       = Reader.ReadUInt32();

            return value;
        }

        private IPMMBmp ReadBmp()
        {
          //DebugPrintOffset("ReadBmp");
            var value           = new PMMBmp();
            value.Position      = ReadVector3();
            value.File          = ReadString(256);
            value.BmpDisp       = Reader.ReadByte();
            
            return value;
        }

        private IPMMViewInfo ReadViewInfo()
        {
          //DebugPrintOffset("ReadViewInfo");
            var value           = new PMMViewInfo();
	        value.DisplayInfo   = Reader.ReadByte();
            value.DisplayGrid   = Reader.ReadByte();
            value.DisplayShadow = Reader.ReadByte();
	        value.FPS           = Reader.ReadSingle();
	        value.CaptureMode   = Reader.ReadUInt32();

            return value;
        }
    }
}
