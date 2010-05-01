using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku.PMD
{
    public interface IPMDMaterial
    {
        GenColor4                       Diffuse         { get; set; }   // float[4]
        float                           Shininess       { get; set; }   // float
        GenColor3                       Specular        { get; set; }   // float[3]
        GenColor3                       Emissive        { get; set; }   // float[3]
        byte                            ToonNo          { get; set; }   // byte
        byte                            Edge            { get; set; }   // byte
        int                             IndexCount      { get; set; }   // int
        string                          Texture         { get; set; }   // char[20]
    }

    public class PMDMaterial : IPMDMaterial
    {
        public GenColor4                Diffuse         { get; set; }
        public float                    Shininess       { get; set; }
        public GenColor3                Specular        { get; set; }
        public GenColor3                Emissive        { get; set; }
        public byte                     ToonNo          { get; set; }
        public byte                     Edge            { get; set; }
        public int                      IndexCount      { get; set; }
        public string                   Texture         { get; set; }
    }

    public interface IPMDMaterialCollection : IList<IPMDMaterial>
    {
    }

    public class PMDMaterialCollection : List<IPMDMaterial>, IPMDMaterialCollection
    {
    }
}
