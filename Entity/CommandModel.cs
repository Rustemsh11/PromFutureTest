using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class CommandModel
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        /// <summary>
        /// Название команды.
        /// </summary>
        [JsonPropertyName("name")]
        public  string Name { get; init; }
        /// <summary>
        /// Название первого параметра.
        /// </summary>
        [JsonPropertyName("parameter_name1")]
        public string? FirstParameterName { get; init; }

        /// <summary>
        /// Название второго параметра.
        /// </summary>
        [JsonPropertyName("parameter_name2")]
        public string? SecondParameterName { get; init; }

        /// <summary>
        /// Название третьего параметра.
        /// </summary>
        [JsonPropertyName("parameter_name3")]
        public string? ThirdParameterName { get; init; }

        /// <summary>
        /// Стандартное значение первого параметра.
        /// </summary>
        [JsonPropertyName("parameter_default_value1")]
        public int? FirstParameterDefaultValue { get; init; }

        /// <summary>
        /// Стандартное значение второго параметра.
        /// </summary>
        [JsonPropertyName("parameter_default_value2")]
        public int? SecondParameterDefaultValue { get; init; }

        /// <summary>
        /// Стандартное значение третьего параметра.
        /// </summary>
        [JsonPropertyName("parameter_default_value3")]
        public int? ThirdParameterDefaultValue { get; init; }
    }
}
