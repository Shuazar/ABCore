using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB.Service.Core.Models
{
        public class Script
        {
            public List<string> exec { get; set; }
            public string type { get; set; }
        }

        public class Event
        {
            public string listen { get; set; }
            public Script script { get; set; }
        }

        public class Header
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class Urlencoded
        {
            public string key { get; set; }
            public string value { get; set; }
            public string type { get; set; }
        }

        public class Body
        {
            public string mode { get; set; }
            public List<Urlencoded> urlencoded { get; set; }
        }

        public class Query
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class Url
        {
            public string raw { get; set; }
            public string protocol { get; set; }
            public List<string> host { get; set; }
            public List<string> path { get; set; }
            public List<Query> query { get; set; }
        }

        public class Request
        {
            public string method { get; set; }
            public List<Header> header { get; set; }
            public Body body { get; set; }
            public Url url { get; set; }
        }

        public class Item
        {
            public string name { get; set; }
            public List<Event> Event { get; set; }
            public Request request { get; set; }
            public List<string> response { get; set; }
        }

        public class PostmenCollection
        {
            public List<Item> item { get; set; }
        }

    

    public class MongoRequestModel
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public List<Event> Event { get; set; }
        public Request request { get; set; }
        public List<object> response { get; set; }
    }
}

