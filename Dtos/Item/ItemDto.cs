using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TaskManagerAPI.Dtos.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TaskSituation Status { get; set; }
    }
}
