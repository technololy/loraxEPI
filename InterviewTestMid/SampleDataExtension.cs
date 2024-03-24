using InterviewTestMid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid
{
    public static class SampleDataExtension
    {
        public static int CountNumberOfMetaObjects(this Meta meta)
        {
            var count = 0;
            if (meta != null)
            {
                if (meta.PartOpacity != null)
                {
                    count++;
                }
                if (meta.PartClassification != null)
                {
                    count++;
                }
                if (meta.PartColour != null)
                {
                    count++;
                }
                if (meta.PartMasterType != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
