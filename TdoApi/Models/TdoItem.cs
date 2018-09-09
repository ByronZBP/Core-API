using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TdoApi.Models
{
    public class TdoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isComplete { get; set; }
    }
}
