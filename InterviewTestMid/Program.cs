using InterviewTestMid.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Xml;
using System.Text.Json.Serialization.Metadata;

namespace InterviewTestMid
{
    public class Program
    {
        private readonly ILogger _logger;

        #region public fields
        public IEnumerable<SampleDataModel>? SampleFoilData { get; private set; }
        public SampleDataModel? SampleModifiedData { get; private set; }
        #endregion
        public Program(ILogger logger)
        {
            _logger = logger;
            DoWork();
        }
        private void DoWork()
        {
            _logger.WriteLogMessage("Doing some JSON tasks...");

            //Do JSON tasks here.
            GetFoilData();
            if (SampleFoilData == null)
            {
                return;
            }
            LogMaterialSection();

            ModifyPartWeight();
            SaveSerializedModifiedToJson();
            _logger.WriteLogMessage("Finished doing some JSON tasks.");
        }

        private void SaveSerializedModifiedToJson()
        {
            var partToSerialize = JsonSerializer.Serialize(SampleModifiedData);

            File.WriteAllText("Data/SampleModifiedData.json", partToSerialize);
        }

        private void ModifyPartWeight()
        {
            SampleModifiedData = SampleFoilData?.FirstOrDefault();
            if (SampleModifiedData != null)
            {
                SampleModifiedData.PartWeight.Value = 222;
            }
        }

        private void LogMaterialSection()
        {
            foreach (var item in SampleFoilData)
            {
                _logger.WriteToCsv(item.Materials.Select(x => x.Material.LookDesc).ToList());
            }
        }

        private void GetFoilData()
        {
            var sampleData = File.ReadAllText("Data/SampleData.json");
            var sampleJsonData = JsonSerializer.Deserialize<SampleDataModel[]>(sampleData);
            SampleFoilData = sampleJsonData?.Where(x => x.PartDesc == "FOIL");
        }
    }
}