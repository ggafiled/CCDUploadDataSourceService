using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace CCDUploadDataSourceService.Model
{
    class OPMS
    {
        [ExcelColumnName("KPI")]
        public string KPI { get; set; }

        [ExcelColumnName("Date")]
        public DateTime Date { get; set; }

        [ExcelColumnName("Target")]
        public string Target { get; set; }

        [ExcelColumnName("Performance")]
        public string Performance { get; set; }

        [ExcelColumnName("Total")]
        public int Total { get; set; }

        [ExcelColumnName("Indicator")]
        public int Indicator { get; set; }

        [ExcelColumnName("Failure")]
        public int Failure { get; set; }
    }
}
