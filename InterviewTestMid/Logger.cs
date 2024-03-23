using System.Diagnostics;

namespace InterviewTestMid
{
    internal class Logger : ILogger
    {
        public void WriteLogMessage(string LogMessage)
        {
            if (string.IsNullOrEmpty(LogMessage))
                throw new ArgumentException("Log message not provided", "LogMessage");

            Debug.WriteLine(LogMessage);
        }
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
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (string log in logMessages)
            {
                writer.WriteLine($"{DateTime.Now},{log}");
            }
        }
    }
}
