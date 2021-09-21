using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiPhanLop.Models;
using ThiPhanLop.ThiModel;

namespace ThiPhanLop.Controllers
{
    public class HomeController : Controller
    {
        Execute getModel = new Execute();
        NguoiDuThi dto;
        List<NguoiDuThi> list;
        
        public ActionResult Index()
        {
            //list = new List<NguoiDuThi>();
            
            ViewBag.List = getModel.GetList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}