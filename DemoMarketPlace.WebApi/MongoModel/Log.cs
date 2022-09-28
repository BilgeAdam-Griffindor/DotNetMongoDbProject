using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace DemoMarketPlace.WebApi.MongoModel
{
    [BsonIgnoreExtraElements]
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("base_user_id")]
        public int BaseUserId { get; set; }
        [BsonElement("table_name")]
        public string TableName { get; set; }
        [BsonElement("affected_id")]
        public int AffectedId { get; set; }
        [BsonElement("log_level")]
        public string LogLevel { get; set; }
        [BsonElement("operation_type")]
        public string OperationType { get; set; }
        [BsonElement("created_date")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("log_detail")]
        public string LogDetail { get; set; }

    }
}
