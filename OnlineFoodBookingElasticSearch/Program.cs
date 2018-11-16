using Nest;
using OnlineFoodBookingElasticSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBookingElasticSearch
{
    class Program
    {
        public static Uri EsNode;
        public static ConnectionSettings EsConfig;
        public static ElasticClient EsClient;
        static void Main(string[] args)
        {
            EsNode = new Uri("http://localhost:9200/");
            EsConfig = new ConnectionSettings(EsNode);
            EsClient = new ElasticClient(EsConfig);

            var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

            var indexConfig = new IndexState
            {
                Settings = settings
            };

            if (!EsClient.IndexExists("onlinefoodbooking").Exists)
            {
                EsClient.CreateIndex("onlinefoodbooking", c => c
                .InitializeUsing(indexConfig)
                .Mappings(m => m.Map<FoodMenu>(mp => mp.AutoMap())));
            }
            OnlineFoodBookingElasticEntities ctx = new OnlineFoodBookingElasticEntities();

            foreach (var item in ctx.FoodMenus)
            {
                FoodMenu studentEsObj = new FoodMenu
                {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = item.Price,

                };
                var response = EsClient.IndexAsync<FoodMenu>(studentEsObj, i => i
                                                 .Index("onlinefoodbooking")
                                                 .Type(TypeName.From<FoodMenu>())
                                                 .Id(item.FoodId)
                                                 .Refresh(Elasticsearch.Net.Refresh.True));
            }

        }

    }
}
