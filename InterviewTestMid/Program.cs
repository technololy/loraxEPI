using InterviewTestMid.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace InterviewTestMid
{
    internal class Program
    {
        private readonly ILogger _logger;
        public Program(ILogger logger)
        {
            DoWork();
            _logger = logger;
        }
        private void DoWork()
        {
            _logger.WriteLogMessage("Doing some JSON tasks...");

            //Do JSON tasks here.
            var sampleData = File.ReadAllText("Data/SampleData.json");
            var sampleJsonData = JsonSerializer.Deserialize<SampleJsonData>(sampleData);
            var foilListData = sampleJsonData?.SampleData?.Where(x => x.PartDesc == "FOIL");
            if (foilListData == null)
            {
                return;
            }
            foreach (var item in foilListData)
            {
              _logger.WriteToCsv(item.Materials.Select(x => x.Material.LookDesc).ToList());
            }

            var partWeightSection = foilListData.FirstOrDefault();
            if (partWeightSection != null)
            {
                partWeightSection.PartWeight.Value = 22;
            }
            _logger.WriteLogMessage("Finished doing some JSON tasks.");
        }
    }
}