﻿using Newtonsoft.Json;

namespace RememberTheMilkApi.Objects
{
    [JsonObject("taskseries")]
    public class RtmApiTaskObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public RtmApiTaskObject()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}