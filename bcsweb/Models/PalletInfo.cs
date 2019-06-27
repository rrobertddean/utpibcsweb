using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bcsweb.Models
{
    public class PalletInfo
    {
        public string status { get; set; }
        public int palletno { get; set; }
        public int noofboxes { get; set; }
        public int productspecid { get; set; }
        public string productspeccode { get; set; }
        public string brandcode { get; set; }
        public string costclasscode { get; set; }
        public string handpackcode { get; set; }
        public string plastictypecode { get; set; }
        public double putinweight { get; set; }
        public int packinghousecode { get; set; }
        public string portcode { get; set; }
        public int shipmentname { get; set; }
        public DateTime datetimepacked { get; set; }
        public int drno { get; set; }
        public string truckplateno { get; set; }
        public int deliveryid { get; set; } 
        public string rpltzdtagno { get; set; }
        public int qtyloaded { get; set; }
        public int qtyToload { get; set; }
        public int qtydldeducted { get; set; }

    }
}