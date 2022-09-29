using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DemoMarketPlace.WebApi.MongoModel
{
    [BsonIgnoreExtraElements]
    public class Addresses
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("address_id")]
        public int AddressId { get; set; }
        
        [BsonElement("address_name")]
        public string AddressName { get; set; }
        [BsonElement("topaddress_id")]
        public int? TopAddressId { get; set; }
        [BsonElement("addresstype_id")]
        public int AddressType { get; set; }
       
    }
}
