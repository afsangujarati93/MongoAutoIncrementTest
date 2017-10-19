using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System.Data.Linq;

namespace MongoAutoIncrement
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new MongoClient("mongodb://localhost/testIncrement?authSource=admin");
            //MongoServer msServer = client.GetServer();
            //MongoDatabase mdbDatabase = msServer.GetDatabase("testIncrement");
            //var vrCollection = mdbDatabase.GetCollection("testIncColl");


            var client = new MongoClient("mongodb://localhost/testIncrement?authSource=admin");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("myDatabase");
            var counterCol = db.GetCollection("counters");

            var result = counterCol.FindAndModify(new FindAndModifyArgs()
            {
                Query = Query.EQ("orderId", "orderId"),
                Update = Update.Inc("orderId", 1),
                VersionReturned = FindAndModifyDocumentVersion.Modified,
                Upsert = true, //Create if the document does not exists
            });
        }
    }

    public class Counter
    {
        public string Id { get; set; }
        public int Value { get; set; }
    }
}
