using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCDUploadDataSourceService.Model
{
    class CCDMessage
    {
        public string fileName { get; set; }
        public DataSourceType sourceType { get; set; }
    }
}
