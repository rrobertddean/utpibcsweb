using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using bcsweb.Class;

namespace bcsweb.Controllers
{
    public class LoadingController : Controller
    {
        string strCon = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        DBUtility dbu = new DBUtility();
        StringUtility stru = new StringUtility();


        public ActionResult Index()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult LoadPallets()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }


        public ActionResult HatchLoadingPalletized()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult HatchLoadingBreakBulk()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null) 
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult Reefervan()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult LoadWholeReeferVan()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult SetLoadingTime()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult EndHatchLoadingTime(int shipmentid)
        {

            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                TempData["shipmentid"] = shipmentid;
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult LoadMaterials()
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult HatchMaterialsLoading(int shipmentid, int portid, int vesselid)
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                TempData["shipmentid"] = shipmentid;
                TempData["portid"] = portid;
                TempData["vesselid"] = vesselid;
                return View();
            }

            return Redirect("~/Account/Login");
        }

        public ActionResult ReeferVanMaterialsLoading(int shipmentid,int portid, int vesselid)
        {
            if (Session["Userid"] != null && Session["Wharfid"] != null)
            {
                TempData["shipmentid"] = shipmentid;
                TempData["portid"] = portid;
                TempData["vesselid"] = vesselid;

                return View();
            }

            return Redirect("~/Account/Login");
        }


        public string GetShipmentRouteByCode()
        {

            string shipmentcode = Request.Params["shipmentcode"];
            string port = Request.Params["port"];

            DataTable dtShipmentRouteCode = dbu.FetchDataTable("EXECUTE GetShipmentRouteByCode '" + shipmentcode + "', '"+port+"' ");
            string shipmentroutecode = stru.DataTableToJSONWithJavaScriptSerializer(dtShipmentRouteCode);

            if (dtShipmentRouteCode.Rows.Count > 0)
            {
                return shipmentroutecode;
            }
            else
            {
                return "0";
            }

        }

        public string GetHatchholdByIDNew()
        {

            var hatchbarcode = Request.Params["hatchbarcode"];
            var shipmentcode = Request.Params["shipmentcode"];
            var vesselid = Request.Params["vesselid"];

            string hatchbarcodeclean = hatchbarcode.Substring(6, hatchbarcode.Length - 6);
            long cvlnghatchbarcode = Convert.ToInt64(hatchbarcodeclean);
          
            DataTable dtGetHatchholdByIDNew = dbu.FetchDataTable("EXECUTE GetHatchholdByIDNew " + cvlnghatchbarcode + ", " + shipmentcode + " ");
            string gethatchholdbyidnew = stru.DataTableToJSONWithJavaScriptSerializer(dtGetHatchholdByIDNew);

            if (dtGetHatchholdByIDNew.Rows.Count > 0)
            {
                return gethatchholdbyidnew;
            }
            else 
            {
                return "0";
            }


        }

        public string GetHatchholdByIDNew2()
        {

            var hatchbarcode = Request.Params["hatchbarcode"];
            var shipmentcode = Request.Params["shipmentcode"];
            var vesselid = Request.Params["vesselid"];

            //string hatchbarcodeclean = hatchbarcode.Substring(6, hatchbarcode.Length - 6);
            long cvlnghatchbarcode = Convert.ToInt64(hatchbarcode);

            DataTable dtGetHatchholdByIDNew = dbu.FetchDataTable("EXECUTE GetHatchholdByIDNew " + cvlnghatchbarcode + ", " + shipmentcode + " ");
            string gethatchholdbyidnew = stru.DataTableToJSONWithJavaScriptSerializer(dtGetHatchholdByIDNew);

            if (dtGetHatchholdByIDNew.Rows.Count > 0)
            {
                return gethatchholdbyidnew;
            }
            else
            {
                return "0";
            }


        }



        public string GetHatchHoldID()
        {
            var hatchidval = Request.Params["hatchidval"];
            var shipmentcode = Request.Params["shipmentcode"];

            DataTable dtGetHatchHoldIdInfo = dbu.FetchDataTable("EXECUTE GetHatchholdByIDNew " + hatchidval + ", " + shipmentcode + " ");
            string gethatchholdidinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtGetHatchHoldIdInfo);

            if (dtGetHatchHoldIdInfo.Rows.Count > 0)
            {
                return gethatchholdidinfo;
            }
            else
            {
                return "0";
            }

            
        }
            
        public string GetPalletInfo()
        {
            var palletbarcode = Request.Params["palletbarcode"];
            string palletbarcodeclean = palletbarcode.Substring(6, palletbarcode.Length - 6);
            long cvlngpalletbarcode = Convert.ToInt64(palletbarcodeclean);

            DataTable dtGetPalletInfo = dbu.FetchDataTable("EXECUTE GetPalletInfo "+ cvlngpalletbarcode + "");
            string getpalletinfo = stru.DataTableToJSONWithJavaScriptSerializer(dtGetPalletInfo);

            if (dtGetPalletInfo.Rows.Count > 0)
            {
                return getpalletinfo;
            }
            else
            {
                return "0";
            }

        }


        public string GetLoadingDetails()
        {
            var palletbarcode = Request.Params["palletbarcode"];
            string palletbarcodeclean = palletbarcode.Substring(6, palletbarcode.Length - 6);
            long cvlngpalletbarcode = Convert.ToInt64(palletbarcodeclean);

            DataTable dtGetLoadingDetails = dbu.FetchDataTable("EXECUTE GetLoadingDetails " + cvlngpalletbarcode + "");
            string getloadingdetails = stru.DataTableToJSONWithJavaScriptSerializer(dtGetLoadingDetails);

            if (dtGetLoadingDetails.Rows.Count > 0)
            {
                return getloadingdetails;
            }
            else
            {
                return "0";
            }

        }

        public string IsPortMatched()
        {
            var portid = Request.Params["portid"];
            var portcode = Request.Params["portcode"];

            DataTable dtGetPortInfoByCode = dbu.FetchDataTable("EXECUTE GetPortInfoByCode '" + portcode + "'");
            string getportinfobycode = stru.DataTableToJSONWithJavaScriptSerializer(dtGetPortInfoByCode);

            if (dtGetPortInfoByCode.Rows.Count > 0)
            {
                var portidRef = dtGetPortInfoByCode.Rows[0][0].ToString();

                if (portidRef == portid)
                {
                    return "1";
                }
                else
                {
                    return "-1"; //Mismatched portid and portcode
                }

            }
            else
            {
                return "0";
            }

            
        }


        public int ReleaseFromColdStorage2()
        {
            var userid = Session["userid"];
            var palletno = Request.Params["palletno"];
            var datetimenow = DateTime.Now;
            var remarks = Request.Params["remarks"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@ActualTimeOut", datetimenow },
                { "@ReleasedBy", userid },
                { "@Reason", remarks }
            };

            var retVal = dbu.fetchSPRetInt("UpdatePalletInCS2", param);

            return retVal;
        }

        public int InsertLoadingHatchNew()
        {
            int palletno = Convert.ToInt32(Request.Params["palletno"]);
            string ropesling = Request.Params["ropesling"].ToUpper();
            string dismantled = Request.Params["dismantled"];
            int shipcode = Convert.ToInt32(Request.Params["shipcode"]);
            int portid = Convert.ToInt32(Request.Params["portid"]);
            int hatchholdid = Convert.ToInt32(Request.Params["hatchholdid"]);
            int intqty = Convert.ToInt32(Request.Params["intqty"]);
            string remarks = Request.Params["remarks"];
            int userid = Convert.ToInt32(Session["Userid"]);
            int wharfid = Convert.ToInt32(Session["Wharfid"]);
            string inreefervan = "N";


            if (YesNo(ropesling) == true)
            {
                int lngresult = InsertLoadingNew(palletno,shipcode, portid, inreefervan, userid, ropesling, dismantled, wharfid, hatchholdid, remarks, intqty);
                return lngresult;

            }
            else {
                return -9; // Invalid RopeSling Value
            }

        }



        private Boolean YesNo(string param)
        {
            if (param.Length > 0) 
            {
                var paramToLower = param.ToLower();
                if (paramToLower == "n" || paramToLower == "y")
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            return false;
        }


        private int InsertLoadingNew(int palletno, int shipcode, int portid, string inreefervan, int userid, string ropesling, 
            string dismantled, int wharfid, int hatchholdid, string remarks, int intqty)
        {

            int reefervanid = 0;

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@ActualShipmentID", shipcode },
                { "@ActualPortID", portid },
                { "@InReeferVan", inreefervan },
                { "@ReeferVanID", reefervanid },
                { "@ScannedBy", userid },
                { "@HatchHoldID", hatchholdid },
                { "@Remarks", remarks },
                { "@WithRopeSling", ropesling },
                { "@Dismantled", dismantled },
                { "@WharfID", wharfid },
                { "@QtyLoaded", intqty }
            };

            var retVal = dbu.fetchSPRetInt("InsertLoadingNew", param);

            return retVal;


        }

        public int DeleteLoadingEntry()
        {
            var palletno = Request.Params["palletno"];
            var hatchholdid = Request.Params["hatchholdid"];
            var remarks = Request.Params["remarks"];
            var userid = Session["Userid"];
            var wharfid = Session["Wharfid"];


            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PalletNo", palletno },
                { "@HatchAndHoldID", hatchholdid },
                { "@ScannedBy", userid },
                { "@WharfID", wharfid },
                { "@Remarks", remarks }
            };

            var retVal = dbu.fetchSPRetInt("DeleteLoading", param);

            return retVal;
            
        }

        public int IsPortBreakbulk()
        {
            var portid = Request.Params["portid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@PortID", portid }
            };

            var retVal = dbu.fetchSPRetInt("IsPortBreakbulk", param);

            return retVal;
        }

        public string DisplayReeferVanData()
        {
            var rvbarcode = Request.Params["rvbarcode"];
            var shipcode = Request.Params["shipcode"];
            var isloading = Request.Params["isloading"];

            string rvbarcodeclean = rvbarcode.Substring(6, rvbarcode.Length - 6);
            long cvlngrvbarcode = Convert.ToInt64(rvbarcodeclean);

            if (isloading == "true")
            {
                DataTable dtReeferVanData = dbu.FetchDataTable("EXECUTE GetReeferVanLoading " + rvbarcodeclean + ", " + shipcode + "");
                string getreefervandata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanData);

                if (dtReeferVanData.Rows.Count > 0)
                {
                    return getreefervandata;
                }
                else
                {
                    return "0";
                }

            }
            else { 
                
            }



            return "0";
        
        }


        public string DisplayReeferVanData2()
        {
            var rvid = Request.Params["rvid"];
            var shipmentid = Request.Params["shipmentid"];
            var isloading = Request.Params["isloading"];

            if (isloading == "true")
            {
                DataTable dtReeferVanData = dbu.FetchDataTable("EXECUTE GetReeferVanLoading " + rvid + ", " + shipmentid + "");
                string getreefervandata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanData);

                if (dtReeferVanData.Rows.Count > 0)
                {
                    return getreefervandata;
                }
                else
                {
                    return "0";
                }

            }
            else
            {

            }



            return "0";

        }


        public string GetReeferVanIDLoading()
        {
            var rvno = Request.Params["rvno"];
            var shipmentcode = Request.Params["shipmentcode"];
            var isloading = Request.Params["isloading"];

            if (isloading == "true")
            {
                DataTable dtReeferVanIDLoading = dbu.FetchDataTable("EXECUTE GetReeferVanIDLoading '" + rvno + "' , " + shipmentcode + "");
                string getreefervanidloading = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanIDLoading);

                if (dtReeferVanIDLoading.Rows.Count > 0)
                {
                    return getreefervanidloading;
                }
                else
                {
                    return "0";
                }
            }
            else { 
            
            }



            return "0";
        }

        public int InsertLoadingReeferVan()
        {
            var palletno = Request.Params["palletno"];
            var dismantled = Request.Params["dismantled"];
            var shipmentid = Request.Params["shipmentid"];
            var portid = Request.Params["portid"];
            var rvid = Request.Params["rvid"];
            var rvno = Request.Params["rvno"];
            var intQty = Request.Params["intQty"];
            var userid = Session["Userid"];
            var wharfid = Session["Wharfid"];


            DataTable dtGetReeferVanLabel = dbu.FetchDataTable("EXECUTE GetReeferVanLabel " + rvid + "");
            if (dtGetReeferVanLabel.Rows.Count > 0)
            {
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
                {
                    { "@PalletNo", palletno },
                    { "@ActualShipmentID", shipmentid },
                    { "@ActualPortID", portid },
                    { "@InReeferVan", "Y" },
                    { "@ReeferVanID", rvid },
                    { "@ScannedBy", userid },
                    { "@HatchHoldID", 0 },
                    { "@Remarks", "" },
                    { "@WithRopeSling", "N" },
                    { "@Dismantled", dismantled },
                    { "@WharfID", wharfid },
                    { "@QtyLoaded", intQty }
                };

                var retVal = dbu.fetchSPRetInt("InsertLoadingNew", param);

                return retVal;
            }
            else
            {
                return 99;
            }

            

        }

        public string DisplayWholeReeferVanData()
        {
            var rvbarcode = Request.Params["rvbarcode"];
            string rvbarcodeclean = rvbarcode.Substring(6, rvbarcode.Length - 6);
            long cvlngrvbarcode = Convert.ToInt64(rvbarcodeclean);

            DataTable dtWholeReeferVanData = dbu.FetchDataTable("EXECUTE GetWholeReeferVanInfo " + cvlngrvbarcode + "");
            string getwholereefervandata = stru.DataTableToJSONWithJavaScriptSerializer(dtWholeReeferVanData);

            if (dtWholeReeferVanData.Rows.Count > 0)
            {
                return getwholereefervandata;
            }
            else
            {
                return "0";
            }

        }

        public string DisplayReeferVanId()
        {
            var rvno = Request.Params["rvno"];
            var isloading = Request.Params["isloading"];

            if (isloading == "true") 
            {
            
            }
            else if (isloading == "false")
            {
                DataTable dtReeferVanID = dbu.FetchDataTable("EXECUTE GetReeferVanID '" + rvno + "'");
                string getreefervanid = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanID);

                if (dtReeferVanID.Rows.Count > 0)
                {
                    return getreefervanid;
                }
                else
                {
                    return "0";
                }
            }


            return "0";
        }


        public int InsertWholeReeferVanForLoading()
        {
            var shipmentid = Request.Params["shipmentid"];
            var portid = Request.Params["portid"];
            var rvid = Request.Params["rvid"];
            var userid = Session["Userid"];
            var wharfid = Session["Wharfid"];

            int retVal;
            int retVal2;

            do
            {
                Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
                {
                    { "@ReeferVanID", rvid }    
                };

                retVal = dbu.fetchSPRetInt("GetPreStuffedPalletCount", param);

                Dictionary<string, dynamic> param2 = new Dictionary<string, dynamic>()
                {
                    { "@ActualShipmentID", shipmentid },
                    { "@ActualPortID", portid },
                    { "@UserID", userid },
                    { "@ReeferVanID", rvid },
                };

                retVal2 = dbu.fetchSPRetInt("InsertWholeReeferVanForLoading", param2);

            } while (retVal > 0);


            return 1;

        }

        public string GetShipmentInfoByName()
        {
            var shipmentcode = Request.Params["shipmentcode"];
            DataTable dtShipmentInfoByName = dbu.FetchDataTable("EXECUTE GetShipmentInfoByName '" + shipmentcode + "'");
            string getshipmentinfobyname = stru.DataTableToJSONWithJavaScriptSerializer(dtShipmentInfoByName);


            if (dtShipmentInfoByName.Rows.Count > 0)
            {
                return getshipmentinfobyname;
            }
            else {
                return "0";
            }

            
        }

        public string DisplayDataHatchHold()
        {
            var hatchholdbarcode = Request.Params["hatchholdbarcode"];
            string hatchholdbarcodeclean = hatchholdbarcode.Substring(6, hatchholdbarcode.Length - 6);
            long cvlnghatchholdbarcode = Convert.ToInt64(hatchholdbarcodeclean);

            DataTable dtDataHatchHold = dbu.FetchDataTable("EXECUTE GetHatchholdByID '" + cvlnghatchholdbarcode + "'");
            string getdatahatchhold = stru.DataTableToJSONWithJavaScriptSerializer(dtDataHatchHold);


            if (dtDataHatchHold.Rows.Count > 0)
            {
                return getdatahatchhold;
            }
            else
            {
                return "0";
            }
        }

        public string DisplayDataHatchHold2()
        {
            var hatchholdid = Request.Params["hatchholdid"];


            DataTable dtDataHatchHold = dbu.FetchDataTable("EXECUTE GetHatchholdByID '" + hatchholdid + "'");
            string getdatahatchhold = stru.DataTableToJSONWithJavaScriptSerializer(dtDataHatchHold);


            if (dtDataHatchHold.Rows.Count > 0)
            {
                return getdatahatchhold;
            }
            else
            {
                return "0";
            }
        }

        public int InsertLoadingHatchEndTime()
        {
            var hatchholdid = Request.Params["hatchholdid"];
            var shipmentid = Request.Params["shipmentid"];
            var datetimenow = DateTime.Now;
            var userid = Session["userid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@ShipmentID", shipmentid },
                { "@HatchHoldID", hatchholdid },
                { "@CreatedBy", userid },
            };

            var retVal = dbu.fetchSPRetInt("InsertLoadingHatchEndTime", param);

            return retVal;

        }


        public int InsertLoadingEndTime()
        {
            var shipmentcode = Request.Params["shipmentcode"];
            var userid = Session["userid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@ShipmentID", shipmentcode },
                { "@UpdatedBy", userid }
            };

            var retVal = dbu.fetchSPRetInt("UpdateShipmentATLF", param);

            return retVal;
        }

        public string DisplayMaterialsData()
        {

            var materialbarcode = Request.Params["materialbarcode"];
            string materialbarcodeclean = materialbarcode.Substring(6, materialbarcode.Length - 6);
            long cvlngmaterialbarcode = Convert.ToInt64(materialbarcodeclean);

            DataTable dtMaterialsData = dbu.FetchDataTable("EXECUTE GetMaterialLabel '" + cvlngmaterialbarcode + "'");
            string getmaterialsdata = stru.DataTableToJSONWithJavaScriptSerializer(dtMaterialsData);


            if (dtMaterialsData.Rows.Count > 0)
            {
                return getmaterialsdata;
            }
            else
            {
                return "0";
            }

        }

        public int InsertLoadingMaterials()
        {

            int userid = Convert.ToInt32(Session["Userid"]);
            int wharfid = Convert.ToInt32(Session["Wharfid"]);
            var materialid = Request.Params["materialid"];
            var shipmentid = Request.Params["shipmentid"];
            var portid = Request.Params["portid"];
            var inreefervan = Request.Params["inreefervan"];
            var hatchholdid = Request.Params["hatchholdid"];
            var reefervan = Request.Params["reefervan"];
            var quantity = Request.Params["quantity"];
            var remarks = Request.Params["remarks"];


            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@MaterialID", materialid },
                { "@ShipmentID", shipmentid },
                { "@PortID", portid },
                { "@InReeferVan", inreefervan },
                { "@HatchHoldID", hatchholdid },
                { "@ReeferVanID", reefervan },
                { "@Quantity", quantity },
                { "@WharfID", wharfid },
                { "@Remarks", remarks },
                { "@CreatedBy", userid },
            };

            var retVal = dbu.fetchSPRetInt("InsertLoadingMaterials", param);

            return retVal;
        }

        public int UnloadLoadingMaterial()
        {
            int userid = Convert.ToInt32(Session["Userid"]);
            int wharfid = Convert.ToInt32(Session["Wharfid"]);
            var materialid = Request.Params["materialid"];
            var shipmentid = Request.Params["shipmentid"];
            var portid = Request.Params["portid"];
            var inreefervan = Request.Params["inreefervan"];
            var hatchid = Request.Params["hatchid"];
            var reefervanid = Request.Params["reefervanid"];

            Dictionary<string, dynamic> param = new Dictionary<string, dynamic>()
            {
                { "@MaterialID", materialid },
                { "@ShipmentID", shipmentid },
                { "@PortID", portid },
                { "@InReeferVan", inreefervan },
                { "@HatchHoldID", hatchid },
                { "@ReeferVanID", reefervanid },
                { "@WharfID", wharfid },
                { "@DeletedBy", userid },
            };

            var retVal = dbu.fetchSPRetInt("UnloadLoadingMaterial", param);

            return retVal;

        }

        public string DisplayReeferVanLoadingData()
        {
            var rvbarcode = Request.Params["rvbarcode"];

            string rvbarcodeclean = rvbarcode.Substring(6, rvbarcode.Length - 6);
            long cvlngrvbarcode = Convert.ToInt64(rvbarcodeclean);

            DataTable dtReeferVanLoadingData = dbu.FetchDataTable("EXECUTE GetReeferVanLabel " + cvlngrvbarcode + "");
            string getrvloadingdata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanLoadingData);

            if (dtReeferVanLoadingData.Rows.Count > 0)
            {
                return getrvloadingdata;
            }
            else
            {
                return "0";
            }
            

        }

        public string DisplayReeferVanLoadingDataByRVID()
        {
            var rvid = Request.Params["rvid"];

            DataTable dtReeferVanLoadingData = dbu.FetchDataTable("EXECUTE GetReeferVanLabel " + rvid + "");
            string getrvloadingdata = stru.DataTableToJSONWithJavaScriptSerializer(dtReeferVanLoadingData);

            if (dtReeferVanLoadingData.Rows.Count > 0)
            {
                return getrvloadingdata;    
            }
            else
            {
                return "0";
            }

        }




    }
}
