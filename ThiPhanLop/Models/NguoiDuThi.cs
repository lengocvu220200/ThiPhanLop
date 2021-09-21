using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiPhanLop.Models
{
    public class NguoiDuThi
    {
        public NguoiDuThi()
        {
        }
        public int nguoiduthi_id { get; set; }
        public string nguoiduthi_hoten { get; set; }
        public string nguoiduthi_namsinh { get; set; }
        public string nguoiduthi_gioitinh { get; set; }
        public string nguoiduthi_cmnd { get; set; }
        public string nguoiduthi_sdt { get; set; }
        public string nguoiduthi_diachi { get; set; }
        public int khoathi_id { get; set; }
        public string khoathi_ten { get; set; }
        public int nguoiduthi_trinhdo_id { get; set; }
        public string nguoiduthi_trinhdo_ten { get; set; }
        public int nguoiduthi_trangthai { get; set; }
        public int dsnguoiduthi_id { get; set; }
        public string sobaodanh { get; set; }
        public int phongthi_id { get; set; }
        public string phongthi_ten { get; set; }
        public double diemnghe { get; set; }
        public double diemnoi { get; set; }
        public double diemdoc { get; set; }
        public double diemviet { get; set; }
    }
   
}