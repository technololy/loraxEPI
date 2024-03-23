using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid
{
    internal class SpecialLogger : ILogger
    {
        public void WriteErrorMessage(Exception Ex)
        {
            if (Ex == null)
                throw new ArgumentException("Exception not provided", "Ex");

            Debug.WriteLine($"Error recieved: {Ex.Message}");
            Debug.WriteLine($"{Ex.StackTrace}");
        }

        public void WriteToCsv(List<string> logMessages)
        {
            if (logMessages == null)
                throw new ArgumentException("data not provided", nameof(logMessages));

            string filePath = "logMessages.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string log in logMessages)
                {
                    writer.WriteLine($"{DateTime.Now},{log}");
                }
            }
        }

        public void WriteLogMessage(string logMessage)
        {
            if (string.IsNullOrEmpty(logMessage))
                throw new ArgumentException("Log message not provided", "LogMessage");

            Debug.WriteLine($"{DateTime.Now}: {logMessage}");
        }
    }
}
