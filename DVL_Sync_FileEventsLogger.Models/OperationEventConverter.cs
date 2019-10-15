using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace DVL_Sync_FileEventsLogger.Models
{
    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(OperationEvent).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class OperationEventConverter : JsonConverter
    {
        static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings()
            {ContractResolver = new BaseSpecifiedConcreteClassConverter()};

        public override bool CanConvert(Type objectType) => objectType == typeof(OperationEvent);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer) => GetFromJObject(JObject.Load(reader));

        private static object GetFromJObject(JObject jo) => jo["EventType"].Value<int>() switch
        {
            0 => (object)JsonConvert.DeserializeObject<CreateOperationEvent>(jo.ToString(),
                SpecifiedSubclassConversion),
            1 => JsonConvert.DeserializeObject<EditOperationEvent>(jo.ToString(), SpecifiedSubclassConversion),
            2 => JsonConvert.DeserializeObject<DeleteOperationEvent>(jo.ToString(), SpecifiedSubclassConversion),
            3 => JsonConvert.DeserializeObject<RenameOperationEvent>(jo.ToString(), SpecifiedSubclassConversion),
            _ => throw new NotImplementedException()
        };
        //public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case RenameOperationEvent renameOp:
                    writer.WriteRaw(
                        JsonConvert.SerializeObject((FakeRenameOperationEvent) renameOp));
                    break;
                case OperationEvent op:
                    writer.WriteRaw(JsonConvert.SerializeObject((FakeOperationEvent) op));
                    break;
                default: throw new Exception();
            }
        }
    }


    public class FakeOperationEvent
    {
        public EventType EventType { get; set; }

        public string FileName => Path.GetFileName(FilePath);

        public FileType FileType { get; set; }

        public DateTime RaisedTime { get; set; }
        public string FilePath { get; set; }

        public override string ToString() =>
            $"EventType: {EventType} FileName: {FileName} FileType: {FileType} RaisedTime: {RaisedTime} FilePath: {FilePath}";
    }

    public class FakeRenameOperationEvent : FakeOperationEvent
    {
        public string OldFilePath { get; set; }
        public string OldFileName => Path.GetFileName(OldFilePath);

        public override string ToString() => $"{base.ToString()} OldFileName: {OldFileName} OldFilePath: {OldFilePath}";
    }
}
