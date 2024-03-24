using InterviewTestMid.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Xml;
using System.Text.Json.Serialization.Metadata;
using System.Text;

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
            SaveSerializedModifiedToJsonFile();
            _logger.WriteLogMessage("Finished doing some JSON tasks.");
        }

        private void SaveSerializedModifiedToJsonFile()
        {
            var partToSerialize = JsonSerializer.Serialize(SampleModifiedData);
            var fileName = "Data/SampleModifiedData.json";
            if (File.Exists(fileName))
            {
                return;
            }
            File.WriteAllText(fileName,partToSerialize);
        }

        private void ModifyPartWeight()
        {
            var sampleModifiedData = SampleFoilData?.FirstOrDefault();
            if (sampleModifiedData != null)
            {
                var serializedSampleModifiedData = JsonSerializer.Serialize(sampleModifiedData);
                SampleModifiedData = JsonSerializer.Deserialize<SampleDataModel>(serializedSampleModifiedData);
            }
            if (SampleModifiedData != null)
            {
                SampleModifiedData.PartWeight.Value = 222;
            }
        }

        private void LogMaterialSection()
        {
            if (SampleFoilData == null)
            {
                return;
            }
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