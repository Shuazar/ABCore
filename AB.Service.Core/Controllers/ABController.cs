using AB.Service.Core.Models;
using AB.Service.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB.Service.Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ABController : ControllerBase
	{
		private readonly JsonSerializerSettings serializerSettings;

		public ABController()
		{
			serializerSettings = new JsonSerializerSettings();
			serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
		[HttpPost("CreateRequests")]		
		public IActionResult CreateRequest(PostmenCollection query)
		{
			var result = new RequestService().CreateRequest(query);
			var jsonObj = JsonConvert.SerializeObject(result, serializerSettings);
			return Ok(jsonObj);
		}
		
		[HttpGet("Test")]
		public IActionResult GetTestMessage()
		{
			return Ok("Privet");
		}
		[HttpGet("all")]
		public IActionResult GetAllRequests()
		{
			var reqService = new RequestService();
			var documents = reqService.GetPostmenCollection().Result;
			var jsonObj = JsonConvert.SerializeObject(documents, serializerSettings);
			return Ok(jsonObj);
		}
	}
}
