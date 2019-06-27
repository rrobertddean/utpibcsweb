using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using bcsweb.Models;
using System.Data;
using System.Configuration;
using bcsweb.Class;
using System.Text;
using System.Data.SqlClient;
using System.Web.Security;

namespace bcsweb.Controllers
{
    public class HomeController : Controller
    {
        string strCon = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        DBUtility dbu = new DBUtility();
        StringUtility stru = new StringUtility();


        public ActionResult Index()
        {
           if (Session["Userid"] != null) {
               return View();
           }

           return Redirect("~/Account/Login");
        }

    

        public ActionResult ColdStorage()
        {
            if (Session["Userid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }


        public ActionResult Loading()
        {
            if (Session["Userid"] != null)
            {
                return View();
            }

            return Redirect("~/Account/Login");
        }



        public ActionResult Submitcode()
        {   
            try
            {

            dynamic model = new ExpandoObject();
            List<PalletInfo> pInfo = new List<PalletInfo>();
            PalletInfo pInfoDetail;

            string code = Request.Params["code"];
            var getBarcodeId = Convert.ToInt32(code.Substring(code.Length - 10, 10));

            DataTable dtPalletInfo = dbu.FetchDataTable("EXEC GetPalletInfo " + getBarcodeId + "");
            if (dtPalletInfo.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPalletInfo.Rows)
                {
                    pInfoDetail = new PalletInfo();
                    pInfoDetail.status = dr["status"].ToString();
                    pInfoDetail.palletno = Convert.ToInt32(dr["palletno"].ToString());
                    pInfoDetail.noofboxes = Convert.ToInt32(dr["noofboxes"].ToString());
                    pInfoDetail.productspecid = Convert.ToInt32(dr["productspecid"].ToString());
                    pInfoDetail.productspeccode = dr["productspeccode"].ToString();
                    pInfoDetail.brandcode = dr["brandcode"].ToString();
                    pInfoDetail.costclasscode = dr["costclasscode"].ToString();
                    pInfoDetail.handpackcode = dr["handpackcode"].ToString();
                    pInfoDetail.plastictypecode = dr["plastictypecode"].ToString();
                    pInfoDetail.putinweight = Convert.ToDouble(dr["putinweight"].ToString());
                    pInfoDetail.packinghousecode = Convert.ToInt32(dr["packinghousecode"].ToString());
                    pInfoDetail.portcode = dr["portcode"].ToString();
                    pInfoDetail.shipmentname = Convert.ToInt32(dr["shipmentname"].ToString());
                    pInfoDetail.datetimepacked = Convert.ToDateTime(dr["datetimepacked"].ToString());
                    pInfoDetail.drno = Convert.ToInt32(dr["drno"].ToString());
                    pInfoDetail.truckplateno = dr["truckplateno"].ToString();
                    pInfoDetail.deliveryid = Convert.ToInt32(dr["deliveryid"].ToString());
                    pInfoDetail.rpltzdtagno = dr["rpltzdtagno"].ToString();
                    pInfoDetail.qtyloaded = Convert.ToInt32(dr["qtyloaded"].ToString());
                    pInfoDetail.qtyToload = Convert.ToInt32(dr["qtyToload"].ToString());
                    pInfoDetail.qtydldeducted = Convert.ToInt32(dr["qtydldeducted"].ToString());

                    pInfo.Add(pInfoDetail);
                }

                model.PalletInfo = pInfo;


                return View("PalletInfo", model);
            }
            else {
                return Content("<script language='javascript' type='text/javascript'>alert('Error: Barcode does not exists');window.location.href='../';</script>");
            }

            }

            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Error: Barcode does not exists');window.location.href='../';</script>");
            }
               
           
        }

        public string testHome()
        {
           
            var md5encrypt = new MD5Enc.MD5Encryption();
          
                string username = "den";
                string password = "9794";

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();

                SqlConnection cn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand("CheckUser",cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pwd", SqlDbType.Binary, 16).Value = md5encrypt.EncodeString(password);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return "test 123";
        }



      

    }
}
