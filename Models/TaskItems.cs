using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TaskSituation Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public enum TaskSituation
    {
        Pending,
        InProgress,
        Completed,
    }

}