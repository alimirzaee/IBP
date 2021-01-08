using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBP_API.Database.Models.IOT
{
 
    public class IoTDatabaseSettings : IIoTDatabaseSettings
    {
        public string IoTCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IIoTDatabaseSettings
    {
        string IoTCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }



}
