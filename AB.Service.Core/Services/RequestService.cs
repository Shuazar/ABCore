using AB.Service.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB.Service.Core.Services
{
	public class RequestService
	{
		MongoDbHandler mongo;
		public RequestService()
		{
			mongo = new MongoDbHandler();
		}
		public PostmenCollection CreateRequest(PostmenCollection query)
		{
			foreach (var item in query.item)
			{				
				mongo.CreateRequests(item);
			}
			return query;
		}

		public async Task<List<MongoRequestModel>> GetPostmenCollection()
		{
			return await Task.Run(() =>
			{
				var list = mongo.GetCollection().Find(_ => true).ToListAsync<MongoRequestModel>();
				return list;
			});

		}
		
		

	}
}
