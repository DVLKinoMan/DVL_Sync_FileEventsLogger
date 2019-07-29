using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DVL_Sync_FileEventsLogger.Models
{
    //public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    //{
    //    protected override JsonConverter ResolveContractConverter(Type objectType)
    //    {
    //        if (typeof(Base).IsAssignableFrom(objectType) && !objectType.IsAbstract)
    //            return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
    //        return base.ResolveContractConverter(objectType);
    //    }
    //}

    public class OperationEventConverter : JsonConverter
    {
        //static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType) => objectType == typeof(OperationEvent);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            switch (jo["EventType"].Value<int>())
            {
                case 0:
                    return JsonConvert.DeserializeObject<CreateOperationEvent>(jo.ToString());//, SpecifiedSubclassConversion);
                case 1:
                    return JsonConvert.DeserializeObject<EditOperationEvent>(jo.ToString());//, SpecifiedSubclassConversion);
                case 2:
                    return JsonConvert.DeserializeObject<DeleteOperationEvent>(jo.ToString());//, SpecifiedSubclassConversion);
                case 3:
                    return JsonConvert.DeserializeObject<RenameOperationEvent>(jo.ToString());//, SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => serializer.Serialize(writer, value, typeof(OperationEvent));
    }
}
