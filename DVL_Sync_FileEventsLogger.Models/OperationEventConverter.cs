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
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType) => objectType == typeof(OperationEvent);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            switch (jo["EventType"].Value<int>())
            {
                case 0:
                    return JsonConvert.DeserializeObject<CreateOperationEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case 1:
                    return JsonConvert.DeserializeObject<EditOperationEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case 2:
                    return JsonConvert.DeserializeObject<DeleteOperationEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case 3:
                    return JsonConvert.DeserializeObject<RenameOperationEvent>(jo.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        //public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is RenameOperationEvent renameOp)
            {
                string serialized = JsonConvert.SerializeObject((FakeRenameOperationEvent)renameOp);
                writer.WriteRaw(serialized);
            }
            else if (value is OperationEvent op)
            {
                string serialized = JsonConvert.SerializeObject((FakeOperationEvent)op);
                writer.WriteRaw(serialized);
            }
            //serializer.Serialize(writer, value, typeof(OperationEvent));
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
