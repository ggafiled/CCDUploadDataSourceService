using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace CCDUploadDataSourceService.Model
{
    class Volume
    {
        [ExcelColumnName("Handled Month")]
        public string HandledMonth { get; set; }

        [ExcelColumnName("Handled Date")]
        public DateTime HandledDate { get; set; }

        [ExcelColumnName("Handled Day of Week")]
        public string HandledDayOfWeek { get; set; }

        [ExcelColumnName("Handled Yr & Wk")]
        public string HandledYrAndWk { get; set; }

        [ExcelColumnName("Handled Year")]
        public string HandledYear { get; set; }

        [ExcelColumnName("DOM OB SVC Piece count")]
        public int DOMOBSVCPieceCount { get; set; }

        [ExcelColumnName("DOM OB SVC Shipment count")]
        public int DOMOBSVCShipmentCount { get; set; }

        [ExcelColumnName("DOM OB SVC Physical Weight")]
        public float DOMOBSVCPhysicalWeight { get; set; }

        [ExcelColumnName("DOM OB SVC Handled Unit")]
        public int DOMOBSVCHandledUnit { get; set; }

        [ExcelColumnName("DOM TXF Piece count")]
        public int DOMTXFPieceCount { get; set; }

        [ExcelColumnName("DOM TXF Shipment count")]
        public int DOMTXFShipmentCount { get; set; }

        [ExcelColumnName("DOM TXF Physical Weight")]
        public float DOMTXFPhysicalWeight { get; set; }

        [ExcelColumnName("DOM TXF Handled Unit")]
        public int DOMTXFHandledUnit { get; set; }

        [ExcelColumnName("OB SVC Piece count")]
        public int OBSVCPieceCount { get; set; }

        [ExcelColumnName("OB SVC Shipment count")]
        public int OBSVCShipmentCount { get; set; }

        [ExcelColumnName("OB SVC Physical Weight")]
        public float OBSVCPhysicalWeight { get; set; }

        [ExcelColumnName("OB SVC Handled Unit")]
        public int OBSVCHandledUnit { get; set; }

        [ExcelColumnName("OB SVC + GTW Piece count")]
        public int OBSVCGTWPieceCount { get; set; }

        [ExcelColumnName("OB SVC + GTW Shipment count")]
        public int OBSVCGTWShipmentCount { get; set; }

        [ExcelColumnName("OB SVC + GTW Physical Weight")]
        public float OBSVCGTWPhysicalWeight { get; set; }

        [ExcelColumnName("OB SVC + GTW Handled Unit")]
        public int OBSVCGTWHandledUnit { get; set; }

        [ExcelColumnName("OB GTW Piece count")]
        public int OBGTWPieceCount { get; set; }

        [ExcelColumnName("OB GTW Shipment count")]
        public int OBGTWShipmentCount { get; set; }

        [ExcelColumnName("OB GTW Physical Weight")]
        public float OBGTWPhysicalWeight { get; set; }

        [ExcelColumnName("OB GTW Handled Unit")]
        public int OBGTWHandledUnit { get; set; }

        [ExcelColumnName("IB GTW Piece count")]
        public int IBGTWPieceCount { get; set; }

        [ExcelColumnName("IB GTW Shipment count")]
        public int IBGTWShipmentCount { get; set; }

        [ExcelColumnName("IB GTW Physical Weight")]
        public float IBGTWPhysicalWeight { get; set; }

        [ExcelColumnName("IB GTW Handled Unit")]
        public int IBGTWHandledUnit { get; set; }

        [ExcelColumnName("IB GTW + SVC Piece count")]
        public int IBGTWSVCPieceCount { get; set; }

        [ExcelColumnName("IB GTW + SVC Shipment count")]
        public int IBGTWSVCShipmentCount { get; set; }

        [ExcelColumnName("IB GTW + SVC Physical Weight")]
        public float IBGTWSVCPhysicalWeight { get; set; }

        [ExcelColumnName("IB GTW + SVC Handled Unit")]
        public int IBGTWSVCHandledUnit { get; set; }

        [ExcelColumnName("IB SVC Piece count")]
        public int IBSVCPieceCount { get; set; }

        [ExcelColumnName("IB SVC Shipment count")]
        public int IBSVCShipmentCount { get; set; }

        [ExcelColumnName("IB SVC Physical Weight")]
        public float IBSVCPhysicalWeight { get; set; }

        [ExcelColumnName("IB SVC Handled Unit")]
        public int IBSVCHandledUnit { get; set; }

        [ExcelColumnName("Belly TXF Piece count")]
        public int BellyTXFPieceCount { get; set; }

        [ExcelColumnName("Belly TXF Shipment count")]
        public int BellyTXFShipmentCount { get; set; }

        [ExcelColumnName("Belly TXF Physical Weight")]
        public float BellyTXFPhysicalWeight { get; set; }

        [ExcelColumnName("Belly TXF Handled Unit")]
        public int BellyTXFHandledUnit { get; set; }

        [ExcelColumnName("ULD TXF Piece count")]
        public int ULDTXFPieceCount { get; set; }

        [ExcelColumnName("ULD TXF Shipment count")]
        public int ULDTXFShipmentCount { get; set; }

        [ExcelColumnName("ULD TXF Physical Weight")]
        public float ULDTXFPhysicalWeight { get; set; }

        [ExcelColumnName("ULD TXF Handled Unit")]
        public int ULDTXFHandledUnit { get; set; }

        [ExcelColumnName("Lck & Stay Piece count")]
        public int LckStayPieceCount { get; set; }

        [ExcelColumnName("Lck & Stay Shipment count")]
        public int LckStayShipmentCount { get; set; }

        [ExcelColumnName("Lck & Stay Physical Weight")]
        public float LckStayPhysicalWeight { get; set; }

        [ExcelColumnName("Lck & Stay Handled Unit")]
        public int LckStayHandledUnit { get; set; }

        [ExcelColumnName("INT TXF Piece count")]
        public int INTTXFPieceCount { get; set; }

        [ExcelColumnName("INT TXF Shipment count")]
        public int INTTXFShipmentCount { get; set; }

        [ExcelColumnName("INT TXF Physical Weight")]
        public float INTTXFPhysicalWeight { get; set; }

        [ExcelColumnName("INT TXF Handled Unit")]
        public int INTTXFHandledUnit { get; set; }

        [ExcelColumnName("Inf Lck & Stay Piece count")]
        public int InfLckStayPieceCount { get; set; }

        [ExcelColumnName("Inf Lck & Stay Shipment count")]
        public int InfLckStayShipmentCount { get; set; }

        [ExcelColumnName("Inf Lck & Stay Physical Weight")]
        public float InfLckStayPhysicalWeight { get; set; }

        [ExcelColumnName("Inf Lck & Stay Handled Unit")]
        public int InfLckStayHandledUnit { get; set; }

        [ExcelColumnName("IB Piece count")]
        public int IBPieceCount { get; set; }

        [ExcelColumnName("IB Shipment count")]
        public int IBShipmentCount { get; set; }

        [ExcelColumnName("IB Physical Weight")]
        public float IBPhysicalWeight { get; set; }

        [ExcelColumnName("IB Handled Unit")]
        public int IBHandledUnit { get; set; }

        [ExcelColumnName("OB Piece count")]
        public int OBPieceCount { get; set; }

        [ExcelColumnName("OB Shipment count")]
        public int OBShipmentCount { get; set; }

        [ExcelColumnName("OB Physical Weight")]
        public float OBPhysicalWeight { get; set; }

        [ExcelColumnName("OB Handled Unit")]
        public int OBHandledUnit { get; set; }

        [ExcelColumnName("TR Piece count")]
        public int TRPieceCount { get; set; }

        [ExcelColumnName("TR Shipment count")]
        public int TRShipmentCount { get; set; }

        [ExcelColumnName("TR Physical Weight")]
        public float TRPhysicalWeight { get; set; }

        [ExcelColumnName("TR Handled Unit")]
        public int TRHandledUnit { get; set; }

        [ExcelColumnName("Ramp Piece count")]
        public int RampPieceCount { get; set; }

        [ExcelColumnName("Ramp Shipment count")]
        public int RampShipmentCount { get; set; }

        [ExcelColumnName("Ramp Physical Weight")]
        public float RampPhysicalWeight { get; set; }

        [ExcelColumnName("Ramp Handled Unit")]
        public int RampHandledUnit { get; set; }

        [ExcelColumnName("Total Piece count")]
        public int TotalPieceCount { get; set; }

        [ExcelColumnName("Total Shipment count")]
        public int TotalShipmentCount { get; set; }

        [ExcelColumnName("Total Physical Weight")]
        public float TotalPhysicalWeight { get; set; }

        [ExcelColumnName("Total Handled Unit")]
        public int TotalHandledUnit { get; set; }
    }
}
