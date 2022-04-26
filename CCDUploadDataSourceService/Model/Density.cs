using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace CCDUploadDataSourceService.Model
{
    class Density
    {
        [ExcelColumnName("KPI")]
        public string KPI { get; set; }

        [ExcelColumnName("Date")]
        public DateTime Date { get; set; }

        [ExcelColumnName("Mvnm")]
        public string Mvnm { get; set; }

        [ExcelColumnName("Destination")]
        public string Destination { get; set; }

        [ExcelColumnName("Aviation Net Weight")]
        public string AviationNetWeight { get; set; }

        [ExcelColumnName("Available Volume")]
        public string AvailableVolume { get; set; }

        [ExcelColumnName("Aviation Loading Density")]
        public string AviationLoadingDensity { get; set; }
    }
}
