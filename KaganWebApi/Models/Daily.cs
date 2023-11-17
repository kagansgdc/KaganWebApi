using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace KaganWebApi.Models
{
    public class Daily
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }
        [BsonElement("Name")]
        public string? name { get; set; }
        public string? description { get; set; }
        public string? day { get; set; }

    }
}
