using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid
{
    public interface ILogger
    {
        public void WriteToCsv(List<string> logMessages);
        public void WriteLogMessage(string LogMessage);
        public void WriteErrorMessage(Exception Ex);
    }
}
