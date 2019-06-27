using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bcsweb.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Configuration;
using bcsweb.Class;

namespace bcsweb.Controllers
{
    public class AccountController : Controller
    {
        string strCon = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        DBUtility dbu = new DBUtility();
        StringUtility stru = new StringUtility();
       


        public ActionResult Login()
        {

            if (Session["Userid"] != null) 
            {
                return Redirect("~/Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!IsValidWharfCode(user)) 
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid Wharf Code!');window.location.href='../account/login'</script>");
            }

            if (IsValid(user))
            {
                DataTable dtGetWharfInfoByCode = dbu.FetchDataTable("EXEC GetWharfInfoByCode '" + user.Wharfcode + "'");
                int wharfid = Convert.ToInt32(dtGetWharfInfoByCode.Rows[0][0]);

                Session["Wharfid"] = wharfid;
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return Redirect("~/Home/Index");
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid Username/Password');window.location.href='../account/login'</script>");
            }


        }

        private bool IsValidWharfCode(User user)
        { 
            var wharfcode = user.Wharfcode;

            DataTable dtGetWharfInfoByCode = dbu.FetchDataTable("EXEC GetWharfInfoByCode '" + wharfcode +"'");
            if (dtGetWharfInfoByCode.Rows.Count > 0)
            {
               return true;
            }
            else
            {
                return false;
            }

        }



        private bool IsValid(User user)
        {
            
            var md5encrypt = new MD5Enc.MD5Encryption();    

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("CheckUser", cn);
            cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = user.Username;
            cmd.Parameters.Add("@pwd", SqlDbType.Binary, 16).Value = md5encrypt.EncodeString(user.Password);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                DataRow row = dt.Rows[0];
                Session["Userid"] = row["userid"].ToString();
                return true;
            }
            else {
                return false;
            }

            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["Userid"] = null;
            return Redirect("~/Home/Index");
        }

        public JsonResult checkSession()
        {
            sessionClass s = new sessionClass();
            if (Session["Userid"] != null || Session["Wharfid"] != null)
            {
                s.sessionValue = true;
                s.userid = Convert.ToInt32(Session["Userid"]);
                s.wharfid = Convert.ToInt32(Session["Wharfid"]);
            }
            else
            {
                s.sessionValue = false;
                s.userid = 0;
                s.wharfid = 0;
            }
            return Json(s, JsonRequestBehavior.AllowGet);  

        }
    }
}
