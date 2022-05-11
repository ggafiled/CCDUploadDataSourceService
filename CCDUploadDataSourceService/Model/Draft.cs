using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace CCDUploadDataSourceService.Model
{
    class Draft
    {

        [ExcelColumnName("HAWBNo")]
        public string HAWBNo { get; set; }

        [ExcelColumnName("Origin")]
        public string Origin { get; set; }

        [ExcelColumnName("CSPassToDateTime")]
        public string CSPassToDateTime { get; set; }

        [ExcelColumnName("CSPassToTeam")]
        public string CSPassToTeam { get; set; }

        [ExcelColumnName("CSPassUser")]
        public string CSPassUser { get; set; }

        [ExcelColumnName("StartCSDateTime")]
        public string StartCSDateTime { get; set; }

        [ExcelColumnName("InstructionFormRevised")]
        public string InstructionFormRevised { get; set; }

        [ExcelColumnName("DraftFlag")]
        public int DraftFlag { get; set; }

        [ExcelColumnName("NurseryDraftFlag")]
        public int NurseryDraftFlag { get; set; }

        [ExcelColumnName("ConsigneeName")]
        public string ConsigneeName { get; set; }

        [ExcelColumnName("DoctorPassToBTO")]
        public string DoctorPassToBTO { get; set; }

        [ExcelColumnName("DestroyShipmentDateTime")]
        public string DestroyShipmentDateTime { get; set; }

        [ExcelColumnName("CEReturntoCS")]
        public string CEReturntoCS { get; set; }

        [ExcelColumnName("QCSentDrafttoCS")]
        public string QCSentDrafttoCS { get; set; }

        [ExcelColumnName("CSSentDraftToCustomers")]
        public string CSSentDraftToCustomers { get; set; }

        [ExcelColumnName("CSConfirmedDraft")]
        public string CSConfirmedDraft { get; set; }
    }
}
