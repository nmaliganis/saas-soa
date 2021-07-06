using Newtonsoft.Json;

namespace ms.common.infrastructure.Serializers
{
  public class JSONsSerializer : IJsonSerializer
  {
    public T DeserializeObject<T>(string json)
    {
      return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
      {
        TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
      });
    }

    public string SerializeObject(object item)
    {
      return JsonConvert.SerializeObject(item, new JsonSerializerSettings {Formatting = Formatting.None});
    }
  }
}