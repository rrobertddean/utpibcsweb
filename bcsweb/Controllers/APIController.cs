using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bcsweb.Class;
using System.Configuration;
using System.Data;
using System.Dynamic;
using bcsweb.Models;

namespace bcsweb.Controllers
{
    public class APIController : Controller
    {
        string strCon = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        DBUtility dbu = new DBUtility();
        StringUtility stru = new StringUtility();

        //
        // GET: /API/

        public string Index()
        {
            return "API Index";
        }


        public string post()
        {
            //Response.AppendHeader("Access-Control-Allow-Origin", "*");
            string param = Request.Params["action"];
            switch (param)
            {
                case "submitcode":
                {
                    
                    return "submit code";
                }
                break;

                default:
                return "error";
                break;
            }
        }

    }
}
