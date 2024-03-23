using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid.Data
{

    public class SampleJsonData
    {
        public SampleDataModel[]? SampleData { get; set; }
    }

    public class SampleDataModel
    {
        public int PartId { get; set; }
        public string PartNbr { get; set; }
        public string PartDesc { get; set; }
        public Meta Meta { get; set; }
        public Partweight PartWeight { get; set; }
        public bool ConversionsApplied { get; set; }
        public Material[] Materials { get; set; }
    }

    public class Meta
    {
        public Partclassification PartClassification { get; set; }
        public Partmastertype PartMasterType { get; set; }
        public Partcolour PartColour { get; set; }
        public Partopacity PartOpacity { get; set; }
    }

    public class Partclassification
    {
        public int LookId { get; set; }
        public string LookNbr { get; set; }
        public string LookDesc { get; set; }
        public string LookExtra { get; set; }
    }

    public class Partmastertype
    {
        public int LookId { get; set; }
        public string LookNbr { get; set; }
        public string LookDesc { get; set; }
    }

    public class Partcolour
    {
        public int LookId { get; set; }
        public string LookNbr { get; set; }
        public string LookDesc { get; set; }
    }

    public class Partopacity
    {
        public int LookId { get; set; }
        public string LookNbr { get; set; }
        public string LookDesc { get; set; }
    }

    public class Partweight
    {
        public int UoM { get; set; }
        public float Value { get; set; }
    }

    public class Material
    {
        public Material1 Material { get; set; }
        public float Percentage { get; set; }
        public bool MatrIsBarrier { get; set; }
        public bool MatrIsDensifier { get; set; }
        public bool MatrIsOpacifier { get; set; }
    }

    public class Material1
    {
        public int LookId { get; set; }
        public string LookNbr { get; set; }
        public string LookDesc { get; set; }
    }


}
