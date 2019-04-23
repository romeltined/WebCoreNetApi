using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreNetApi.Models
{
    public class Dht
    {
        public int Id { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
