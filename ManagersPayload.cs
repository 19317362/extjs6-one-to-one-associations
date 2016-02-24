using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebUI.Class.Chapter_Model.model_associations_one_to_one_csharp_backend
{
    public class ManagersPayload
    {
        [JsonProperty(propertyName: "managers")]
        public List<Employee> Managers { get; set; }
        [JsonProperty(propertyName: "count")]
        public int Count { get; set; }
    }
}