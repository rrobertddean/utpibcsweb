using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bcsweb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using bcsweb.Class;

namespace bcsweb.Controllers
{
    public class ColdStorageController : Controller
    {

        string strCon = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        DBUtility dbu = new DBUtility();
        StringUtility stru = new StringUtility();

      
        public ActionResult InsertPallet()
        {
            if (Session["Userid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

   
        public ActionResult InsertPalletBay()
        {
            if (Session["Userid"] != null) {
                return View();
            }

            return Redirect("~/Account/Login");
        }

       
        public ActionResult InsertPalletReeferVan()
        {
            if (Session["Userid"] != null) {
                return View();
            }

            return Redirect("~/Account/Login");
        }


        public ActionResult ReleasePallet()
        { 
            if (Session["Userid"] != null) {
                return View();
            }

            return Redirect("~/Account/Login");
        }



        
        public string GetColdStorageBayId()
        {

            string bayno = Request.Params["bayno"];
            DataTable dtBayInfo = dbu.FetchDataTable("EXECUTE GetColdStorageBayID '" + bayno + "' ");
            string bayinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtBayInfo);

            if (dtBayInfo.Rows.Count > 0)
            {
                return bayinfo;
            }
            else 
            {
                return "0";
            }
        }

        
        public string GetPalletInfo()
        {
            string barcode = Request.Params["barcode"];

            string barcodeclean = barcode.Substring(6, barcode.Length - 6);
            long cvlngbarcode = Convert.ToInt64(barcodeclean);


            DataTable dtPalletInfo = dbu.FetchDataTable("EXECUTE GetPalletInfo '" + cvlngbarcode + "' ");
            string palletinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtPalletInfo);

            if (dtPalletInfo.Rows.Count > 0)
            {
                return palletinfo;
            }
            else
            {
                return "0";
            }

        }

        public int submitInsertPalletToColdstore()
        {
            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@CellCategory", "Bay/Room" }
            };

            var csid_bay = dbu.fetchSPRetInt("GetCellCategoryID", param);
            var bayid = Request.Params["bayid"];
            var cellno = Request.Params["cellno"];
            var palletno = Request.Params["palletno"];
            var reason = Request.Params["reason"];
            var userid = Session["Userid"];

            Dictionary<string, dynamic> param2 = new Dictionary<string, dynamic>()
            {
                { "@CategoryID", csid_bay },
                { "@BayID", bayid },
                { "@CellNo", cellno },
                { "@PalletNo", palletno },
                { "@StoredBy", userid },
                { "@Reason", reason }
            };

            var retVal = dbu.fetchSPRetInt("StorePalletINCSNew2", param2);

            return retVal;

        }


        public int submitReleasePallet()
        {
            var palletno = Request.Params["palletno"];
            var remarks = Request.Params["remarks"];
            var datetimenow = DateTime.Now;
            var userid = Session["Userid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@ActualTimeOut", datetimenow },
                { "@ReleasedBy", userid },
                { "@Reason", remarks }
            };


            var retVal = dbu.fetchSPRetInt("UpdatePalletInCS", param);

            return retVal;

        }

        public string DisplayReeferVanId()
        {
            var rvno = Request.Params["rvno"];
            DataTable dtGetReeferVanLabel = dbu.FetchDataTable("EXECUTE GetReeferVanID '" + rvno + "' ");

            string reefervanlabel = stru.DataTableToJSONWithJavaScriptSerializer(dtGetReeferVanLabel);

            if (dtGetReeferVanLabel.Rows.Count > 0)
            {
                return reefervanlabel;
            }
            else
            {
                return "0";
            }

        }


        public string DisplayPalletNumber()
        {
            string barcode = Request.Params["palletbarcode"];
            string barcodeclean = barcode.Substring(6, barcode.Length - 6);
            long cvlngbarcode = Convert.ToInt64(barcodeclean);

            DataTable dtPalletInfo = dbu.FetchDataTable("EXECUTE GetPalletInfo '" + cvlngbarcode + "' ");
            string palletinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtPalletInfo);

            if (dtPalletInfo.Rows.Count > 0)
            {
                return palletinfo;
            }
            else
            {
                return "0";
            }

        }


        public string InsertReeferVanToColdStorage()
        {

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@CellCategory", "ReeferVan" }
            };

            var ccid = dbu.fetchSPRetInt("GetCellCategoryID", param);

            var palletno = Request.Params["palletno"];
            var remarks = Request.Params["remarks"];
            var rvid = Request.Params["rvid"];
            var userid = Session["Userid"];


            Dictionary<string, dynamic> param2 = new Dictionary<string, dynamic>()
            {
                { "@CategoryID", ccid },
                { "@BayID", rvid },
                { "@PalletNo", palletno },
                { "@StoredBy", userid },
                { "@Reason", remarks }
            };


            var retVal = dbu.fetchSPRetInt("StorePalletINCSNew", param2);


            return retVal.ToString();

        }

        public string GetStorageInfoById()
        {
            string barcode = Request.Params["barcode"];
            string barcodeclean = barcode.Substring(6, barcode.Length -6);
            long cvlngbarcode = Convert.ToInt64(barcodeclean);
                

            DataTable dtStorageInfo = dbu.FetchDataTable("EXEC GetStorageInfoByID " + barcodeclean);
            string storageinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtStorageInfo);

            if (dtStorageInfo.Rows.Count > 0)
            {
                return storageinfo;
            }
            else
            {
                return "0";
            }


        }


        public string GetPalletReceivingDetails()
        {
            string palletno = Request.Params["palletno"];
            DataTable dtReceivingDetails = dbu.FetchDataTable("EXEC GetPalletReceivingDetails " + palletno);
            string receivingdetails = stru.DataTableToJSONWithJavaScriptSerializer(dtReceivingDetails);

            if (dtReceivingDetails.Rows.Count > 0)
            {
                return receivingdetails;
            }
            else
            {
                return "0";
            }


        }

        public int ReleaseFromColdStorage()
        {
            var palletno = Request.Params["palletno"];
            var remarks = Request.Params["remarks"];
            var datetimenow = DateTime.Now;
            var userid = Session["Userid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@ActualTimeOut", datetimenow },
                { "@ReleasedBy", userid },
                { "@Reason", remarks }
            };


            var retVal = dbu.fetchSPRetInt("UpdatePalletInCS", param);

            return retVal;
        }


        public string GetColdStorageBay()
        {
            var bayBarcode = Request.Params["bayBarcode"];
            string barcodeclean = bayBarcode.Substring(6, bayBarcode.Length - 6);
            long cvlngbarcode = Convert.ToInt64(barcodeclean);

            DataTable dtColdStorageBay = dbu.FetchDataTable("EXEC GetColdStorageBay " + cvlngbarcode);
            string coldstoragebay = stru.DataTableToJSONWithJavaScriptSerializer(dtColdStorageBay);

            if (dtColdStorageBay.Rows.Count > 0)
            {
                return coldstoragebay;
            }
            else
            {
                return "0";
            }

        }

        public string GetColdStorageBay2()
        {
            var bayId = Request.Params["bayid"];

            DataTable dtColdStorageBay = dbu.FetchDataTable("EXEC GetColdStorageBay " + bayId);
            string coldstoragebay = stru.DataTableToJSONWithJavaScriptSerializer(dtColdStorageBay);

            if (dtColdStorageBay.Rows.Count > 0)
            {
                return coldstoragebay;
            }
            else
            {
                return "0";
            }
        }

        public string DisplayReeferVanData()
        {
            var reefervanbc = Request.Params["reefervanbc"];
            string barcodeclean = reefervanbc.Substring(6, reefervanbc.Length - 6);
            long cvlngbarcode = Convert.ToInt64(barcodeclean);

            DataTable dtReeferVanData = dbu.FetchDataTable("EXEC GetReeferVanLabel " + cvlngbarcode);
            string reefervandata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanData);

            if (dtReeferVanData.Rows.Count > 0)
            {
                return reefervandata;
            }
            else
            {
                return "0";
            }


        }

        public string DisplayReeferVanData2()
        {
            var reefervanid = Convert.ToInt64(Request.Params["reefervanid"]);

            DataTable dtReeferVanData = dbu.FetchDataTable("EXEC GetReeferVanLabel " + reefervanid);
            string reefervandata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanData);

            if (dtReeferVanData.Rows.Count > 0)
            {
                return reefervandata;
            }
            else
            {
                return "0";
            }


        }


        public int ChangePalletPort()
        {
            var userid = Session["Userid"];
            var palletno = Request.Params["palletno"];
            var portcode = Request.Params["portcode"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@PortCode", portcode },
                { "@UpdatedBy", userid }
            };


            var retVal = dbu.fetchSPRetInt("UpdatePalletPortCode", param);

            return retVal;


        }


    }
}
