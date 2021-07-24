using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestData data = new TestData
            {
                Name = "Mehmet Ugur",
                Surname = "Atmaca"
            };

            var crudResult = Insert(data, "First");
            if (crudResult.HasLastErrorMessage)
            {
                Console.WriteLine($"Somethings Went Wrong ! - {crudResult.LastErrorMessage}");
            }
            else
            {
                Console.WriteLine($"Successfly !");
            }


            //var query = new QueryDocument { { "Name", "Mehmet" } };
            //var result = collection.FindAs<TestData>(sorgu).FirstOrDefault();
            //Console.WriteLine(result.Name);
        }


        public static WriteConcernResult Insert<T>(T data,string collection)
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("AtmacaTest");
            var _collection = db.GetCollection(collection);
            var result = _collection.Insert(data);
            return result;
        }

        public class TestData
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
