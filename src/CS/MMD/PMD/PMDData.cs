using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDData
    {
        string                          FileName        { get; set; }
        IPMDHeader                      Header          { get; set; }
        IPMDVertexCollection            Vertices        { get; set; }
        IPMDIndexCollection             Indices         { get; set; }
        IPMDMaterialCollection          Materials       { get; set; }
        IPMDBoneCollection              Bones           { get; set; }
        IPMDIkCollection                Iks             { get; set; }
        IPMDFaceCollection              Faces           { get; set; }
        IPMDFaceFrameCollection         FaceFrames      { get; set; }
        IPMDBoneFrameCollection         BoneFrames      { get; set; }
        IPMDEnglish                     English         { get; set; }
        IPMDToonCollection              Toons           { get; set; }
        IPMDPhysicsCollection           Physicses       { get; set; }
        IPMDJointCollection             Joints          { get; set; }

        void Dump();
    }

    public class PMDData : IPMDData
    {
        public string                   FileName        { get; set; }
        public IPMDHeader               Header          { get; set; }
        public IPMDVertexCollection     Vertices        { get; set; }
        public IPMDIndexCollection      Indices         { get; set; }
        public IPMDMaterialCollection   Materials       { get; set; }
        public IPMDBoneCollection       Bones           { get; set; }
        public IPMDIkCollection         Iks             { get; set; }
        public IPMDFaceCollection       Faces           { get; set; }
        public IPMDFaceFrameCollection  FaceFrames      { get; set; }
        public IPMDBoneFrameCollection  BoneFrames      { get; set; }
        public IPMDEnglish              English         { get; set; }
        public IPMDToonCollection       Toons           { get; set; }
        public IPMDPhysicsCollection    Physicses       { get; set; }
        public IPMDJointCollection      Joints          { get; set; }

        public PMDData()
        {
            Header          = new PMDHeader               ();
            Vertices        = new PMDVertexCollection     ();
            Indices         = new PMDIndexCollection      ();
            Materials       = new PMDMaterialCollection   ();
            Bones           = new PMDBoneCollection       ();
            Iks             = new PMDIkCollection         ();
            Faces           = new PMDFaceCollection       ();
            FaceFrames      = new PMDFaceFrameCollection  ();
            BoneFrames      = new PMDBoneFrameCollection  ();
            English         = new PMDEnglish              ();
            Toons           = new PMDToonCollection       ();
            Physicses       = new PMDPhysicsCollection    ();
            Joints          = new PMDJointCollection      ();
        }

        public void Dump()
        {
        }

        public static IPMDData FromFile(string file)
        {
            using(var s= File.OpenRead(file))
            {
                var data        = FromStream(s);
                data.FileName   = file;
                return data;
            }
        }

        public static IPMDData FromStream(Stream s)
        {
            using(var r= new PMDReader(s))
                return r.Read();
        }
    }
}
