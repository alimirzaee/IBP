using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT_API2.Database.Models.IOT
{
    public class Tree
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }


        public Int32 ForestId { get; set; }
        
    }
}
