using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Dtos.Item
{
    public class UpdateItemRequestDto
    {
        [Required(ErrorMessage = "É obrigatório preencher o nome da tarefa")]
        [MaxLength(20, ErrorMessage = "O nome da tarefa não pode ter mais de 12 caracteres")]
        public string Name { get; set; }
        [MaxLength(60, ErrorMessage = "A descrição da tarefa não pode ter mais de 40 caracteres")]
        public string? Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TaskSituation Status { get; set; }
    }
}