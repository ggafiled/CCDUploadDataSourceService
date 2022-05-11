using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace CCDUploadDataSourceService.Model
{
    class COABOS
    {
        [ExcelColumnName("Age class")]
        public string AgeClass { get; set; }

        [ExcelColumnName("Shipment SID / Piece ID")]
        public string ShipmentSID { get; set; }

        [ExcelColumnName("Waybill")]
        public string Waybill { get; set; }

        [ExcelColumnName("Shp Rec Key")]
        public string ShpRecKey { get; set; }

        [ExcelColumnName("Pcs Rec Key")]
        public string PcsRecKey { get; set; }

        [ExcelColumnName("Startclock Date")]
        public DateTime StartclockDate { get; set; }

        [ExcelColumnName("Product Group")]
        public string ProductGroup { get; set; }

        [ExcelColumnName("OPS Product Group")]
        public string OPSProductGroup { get; set; }

        [ExcelColumnName("Product Code")]
        public string ProductCode { get; set; }
        
        [ExcelColumnName("Product Content Code")]
        public string ProductContentCode { get; set; }
        
        [ExcelColumnName("Product Description")]
        public string ProductDescription { get; set; }
        
        [ExcelColumnName("Network Charge Code")]
        public string NetworkChargeCode { get; set; }
        
        [ExcelColumnName("Direct Inj.")]
        public string DirectInjection { get; set; }
        
        [ExcelColumnName("Orig Super Region")]
        public string OrigSuperRegion { get; set; }
        
        [ExcelColumnName("Orig Region")]
        public string OrigRegion { get; set; }
        
        [ExcelColumnName("Orig Sub Region")]
        public string OrigSubRegion { get; set; }
        
        [ExcelColumnName("Orig Region Area")]
        public string OrigRegionArea { get; set; }
        
        [ExcelColumnName("Orig Cluster")]
        public string OrigCluster { get; set; }
        
        [ExcelColumnName("Orig Country")]
        public string OrigCountry { get; set; }
        
        [ExcelColumnName("Orig Country Region")]
        public string OrigCountryRegion { get; set; }
        
        [ExcelColumnName("Orig Country Area")]
        public string OrigCountryArea { get; set; }
        
        [ExcelColumnName("Orig Station")]
        public string OrigStation { get; set; }
        
        [ExcelColumnName("Orig Facility")]
        public string OrigFacility { get; set; }
        
        [ExcelColumnName("Dest Super Region")]
        public string DestSuperRegion { get; set; }
        
        [ExcelColumnName("Dest Region")]
        public string DestRegion { get; set; }
        
        [ExcelColumnName("Dest Sub Region")]
        public string DestSubRegion { get; set; }
        
        [ExcelColumnName("Dest Region Area")]
        public string DestRegionArea { get; set; }
        
        [ExcelColumnName("Dest Cluster")]
        public string DestCluster { get; set; }
        
        [ExcelColumnName("Dest Country")]
        public string DestCountry { get; set; }
        
        [ExcelColumnName("Dest Country Region")]
        public string DestCountryRegion { get; set; }
        
        [ExcelColumnName("Dest Country Area")]
        public string DestCountryArea { get; set; }
        
        [ExcelColumnName("Dest Station")]
        public string DestStation { get; set; }
        
        [ExcelColumnName("Dest Facility")]
        public string DestFacility { get; set; }
        
        [ExcelColumnName("Shipper Name")]
        public string ShipperName { get; set; }
        
        [ExcelColumnName("Consignee Name")]
        public string ConsigneeName { get; set; }
        
        [ExcelColumnName("USD Value")]
        public string USDValue { get; set; }
        
        [ExcelColumnName("Value Class")]
        public string ValueClass { get; set; }
        
        [ExcelColumnName("Wt(Kg)")]
        public string Wt { get; set; }
        
        [ExcelColumnName("Shipper Account")]
        public string ShipperAccount { get; set; }
        
        [ExcelColumnName("Billing Account")]
        public string BillingAccount { get; set; }
        
        [ExcelColumnName("HRS Weight Type")]
        public string HRSWeightType { get; set; }
        
        [ExcelColumnName("Contents")]
        public string Contents { get; set; }
        
        [ExcelColumnName("Pieces")]
        public string Pieces { get; set; }

        [ExcelColumnName("Movement No")]
        public string MovementNo { get; set; }

        [ExcelColumnName("Clrnc Type")]
        public string ClrncType { get; set; }

        [ExcelColumnName("Clearance DTM")]
        public string ClearanceDTM { get; set; }

        [ExcelColumnName("Clearance Region")]
        public string ClearanceRegion { get; set; }

        [ExcelColumnName("Clearance Country")]
        public string ClearanceCountry { get; set; }

        [ExcelColumnName("Clearance Station")]
        public string ClearanceStation { get; set; }

        [ExcelColumnName("Clearance Facility")]
        public string ClearanceFacility { get; set; }

        [ExcelColumnName("Clrnc Startclock Event")]
        public string ClrncStartclockEvent { get; set; }

        [ExcelColumnName("Clrnc Startclock DTM")]
        public string ClrncStartclockDTM { get; set; }

        [ExcelColumnName("Clrnc Startclock Opsday")]
        public string ClrncStartclockOpsday { get; set; }

        [ExcelColumnName("Clrnc Startclock Region")]
        public string ClrncStartclockRegion { get; set; }

        [ExcelColumnName("Clrnc Startclock Country")]
        public string ClrncStartclockCountry { get; set; }

        [ExcelColumnName("Clrnc Startclock Station")]
        public string ClrncStartclockStation { get; set; }

        [ExcelColumnName("Clrnc Startclock Facility")]
        public string ClrncStartclockFacility { get; set; }

        [ExcelColumnName("CD-UD")]
        public string CDUD { get; set; }

        [ExcelColumnName("Clrnc Remark")]
        public string ClrncRemark { get; set; }

        [ExcelColumnName("Clrnc Delay")]
        public string ClrncDelay { get; set; }

        [ExcelColumnName("SC Event Code")]
        public string SCEventCode { get; set; }

        [ExcelColumnName("SC DTM")]
        public string SCDTM { get; set; }

        [ExcelColumnName("NC Event Code")]
        public string NCEventCode { get; set; }

        [ExcelColumnName("NC DTM")]
        public string NCDTM { get; set; }

        [ExcelColumnName("Last Event Code")]
        public string LastEventCode { get; set; }

        [ExcelColumnName("Last Event Remark")]
        public string LastEventRemark { get; set; }

        [ExcelColumnName("Last Event DTM")]
        public string LastEventDTM { get; set; }

        [ExcelColumnName("Has TI")]
        public string HasTI { get; set; }
    }
}
