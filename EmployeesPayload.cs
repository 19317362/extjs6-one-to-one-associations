using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebUI.Class.Chapter_Model.model_associations_one_to_one_csharp_backend
{
    public class EmployeesPayload
    {
        [JsonProperty(propertyName: "employees")]
        public List<Employee> Employees { get; set; }
        [JsonProperty(propertyName: "count")]
        public int Count { get; set; }
    }
}