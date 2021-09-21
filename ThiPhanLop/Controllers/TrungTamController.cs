using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThiPhanLop.Models;
using ThiPhanLop.ThiModel;

namespace ThiPhanLop.Controllers
{
    public class TrungTamController : Controller
    {
        Execute getModel = new Execute();
        NguoiDuThi dto;
        List<NguoiDuThi> list;
        List<ThongKe> listTK;
        public ActionResult Index()
        {
            ViewBag.List = getModel.GetList();
            return View();
        }
        public ActionResult Create()
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetKhoaThi();
            ViewBag.TenKhoaThi = list;
            ViewBag.TrinhDo = getModel.GetTrinhDo();
            return View();
        }
        [HttpPost]
        public ActionResult Create(NguoiDuThi dto)
        {
            getModel.Insert(dto);
            TempData["ThemThanhCong"] = "Thêm thành công.";
            ViewBag.TenKhoaThi = list;
            ViewBag.TrinhDo = getModel.GetTrinhDo();
            return View();
        }
        public ActionResult DanhSachDuThi()
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetKhoaThi();
            ViewBag.TenKhoaThi = list;
            ViewBag.Count = 0;
            return View();
        }
        //Lấy danh sách phòng thi theo khóa thi
        public ActionResult DanhSachPhongThi(int id)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetPhongThi(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        //Lấy danh sách sinh viên theo phòng thi
        public ActionResult DSSinhVienDuThi(int idPhongThi)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetDSDuThi(idPhongThi);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TimKiemThongTinPhongThi()
        {
            ViewBag.Count = 0;
            return View();
        }
        [HttpPost]
        public ActionResult TimKiemThongTinPhongThi(NguoiDuThi dto)
        {
            ViewBag.Ten = dto.nguoiduthi_hoten;
            ViewBag.SDT = dto.nguoiduthi_sdt;
            
            list = getModel.GetPhongThiTenSDT(dto.nguoiduthi_hoten,dto.nguoiduthi_sdt);
            if(list.Count > 0)
            {
                ViewBag.Count = 1;
                ViewBag.DS = list;
            }
            else
            {
                ViewBag.Count = 0;
                ViewBag.Check = false;
            }
            TempData["ThemThanhCong"] = "Thêm thành công.";
            return View();
        }
        public ActionResult ThongKeSLKhoaThiPhongThi()
        {
            ViewBag.TrinhDo = getModel.GetTrinhDo();
            //ViewBag.ThongKe = getModel.ThongKeKhoaThiPhongThi(idTrinhDo);
            return View();
        }
       
        public ActionResult GetThongKeSLKhoaThiPhongThi(int idTrinhDo)
        {
            listTK = new List<ThongKe>();
            listTK = getModel.ThongKeKhoaThiPhongThi(idTrinhDo);
            return Json(listTK, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDSKhoaThiTheoTrinhDo(int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetKhoaThiTheoTrinhDo(idTrinhDo);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDSPhongThiTheoTrinhDo(int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetPhongThiTheoTrinhDo(idTrinhDo);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ThongKeSinhVien()
        {
            ViewBag.TenKhoaThi = getModel.GetKhoaThi();
            ViewBag.TenTrinhDo = getModel.GetTrinhDo();
            return View();
        }
        public ActionResult GetDSSVThongKe(int idKhoaThi, int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetSinhVienTheoTrinhDo(idKhoaThi,idTrinhDo);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XemDiem()
        {
            return View();
        }
        public ActionResult GetDiemNghe(string sobaodanh)
        {
            list = new List<NguoiDuThi>();
            list = getModel.GetDiemThi(sobaodanh);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}