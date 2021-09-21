using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ThiPhanLop.Models;

namespace ThiPhanLop.ThiModel
{
    public class Execute
    {
        NguoiDuThi dto;
        ThongKe thongkeDTO;
        string path = "Server =localhost; Uid=root; password= ;persistsecurityinfo = True; database =trungtamtienganh; SslMode = none";
        MySqlCommand myCommand = null;
        List<NguoiDuThi> list;
        List<ThongKe> listKhoaThi;
        public MySqlConnection KetNoi()
        {
            MySqlConnection conn = new MySqlConnection(path);
            return conn;
        }
        public bool Insert(NguoiDuThi dto)
        {
            MySqlConnection conn = KetNoi();
            try
            {
                
                myCommand = new MySqlCommand("insert into nguoiduthi(nguoiduthi_hoten,nguoiduthi_namsinh,nguoiduthi_gioitinh,nguoiduthi_cmnd,nguoiduthi_sdt,nguoiduthi_diachi,nguoiduthi_idkhoathi,nguoiduthi_idtrinhdo,nguoiduthi_trangthaiDS) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", conn);
                myCommand.Parameters.AddWithValue("@a1", dto.nguoiduthi_hoten);
                myCommand.Parameters.AddWithValue("@a2", dto.nguoiduthi_namsinh);
                myCommand.Parameters.AddWithValue("@a3", dto.nguoiduthi_gioitinh);
                myCommand.Parameters.AddWithValue("@a4", dto.nguoiduthi_cmnd);
                myCommand.Parameters.AddWithValue("@a5", dto.nguoiduthi_sdt);
                myCommand.Parameters.AddWithValue("@a6", dto.nguoiduthi_diachi);
                myCommand.Parameters.AddWithValue("@a7", dto.khoathi_id);
                myCommand.Parameters.AddWithValue("@a8", dto.nguoiduthi_trinhdo_id);
                myCommand.Parameters.AddWithValue("@a9", 1);
                conn.Open();
                myCommand.ExecuteNonQuery();
                conn.Close();
                Console.Write(myCommand);

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
            return true;
        }
        public List<NguoiDuThi> GetList()
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {

                myCommand = new MySqlCommand("SELECT n.*, k.khoathi_ten FROM nguoiduthi AS n, khoathi AS k WHERE n.nguoiduthi_idkhoathi=k.khoathi_id", conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_id = Convert.ToInt32(reader["nguoiduthi_id"]);
                    dto.nguoiduthi_hoten = reader["nguoiduthi_hoten"].ToString();
                    dto.nguoiduthi_namsinh = reader["nguoiduthi_namsinh"].ToString();
                    dto.nguoiduthi_gioitinh = reader["nguoiduthi_gioitinh"].ToString();
                    dto.nguoiduthi_cmnd = reader["nguoiduthi_cmnd"].ToString();
                    dto.nguoiduthi_sdt = reader["nguoiduthi_sdt"].ToString();
                    dto.nguoiduthi_diachi = reader["nguoiduthi_diachi"].ToString();
                    dto.khoathi_id = Convert.ToInt32(reader["nguoiduthi_idkhoathi"]);
                    dto.khoathi_ten = reader["khoathi_ten"].ToString();
                    dto.nguoiduthi_trinhdo_id = Convert.ToInt32(reader["nguoiduthi_idtrinhdo"]);
                    dto.nguoiduthi_trangthai = Convert.ToInt32(reader["nguoiduthi_trangthaiDS"]);
                    list.Add(dto);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }
            return list;
        }
        public List<NguoiDuThi> GetKhoaThi()
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {

                myCommand = new MySqlCommand("select * from khoathi", conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.khoathi_id = Convert.ToInt32(reader["khoathi_id"]);
                    dto.khoathi_ten = reader["khoathi_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        public List<NguoiDuThi> GetTrinhDo()
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {

                myCommand = new MySqlCommand("select * from trinhdo", conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_trinhdo_id = Convert.ToInt32(reader["trinhdo_id"]);
                    dto.nguoiduthi_trinhdo_ten = reader["trinhdo_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        //Lấy ds phòng thi theo id khoa thi
        public List<NguoiDuThi> GetPhongThi(int idKhoaThi)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "select phongthi_id, phongthi_ten from phongthi where phongthi_idkhoa = " + idKhoaThi;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.phongthi_id = Convert.ToInt32(reader["phongthi_id"]);
                    dto.phongthi_ten = reader["phongthi_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        //Lấy ds sinh viên của phòng thi theo id phòng thi
        public List<NguoiDuThi> GetDSDuThi(int idPhongThi)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT n.nguoiduthi_id,nguoiduthi_hoten,nguoiduthi_namsinh,n.nguoiduthi_gioitinh,n.nguoiduthi_cmnd,n.nguoiduthi_sdt,n.nguoiduthi_diachi,d.dsnguoiduthi_id, d.dsnguoiduthi_sbd " +
                    "FROM dsnguoiduthi AS d, nguoiduthi AS n, phongthi AS p, trinhdo AS t " +
                    "WHERE n.nguoiduthi_id=d.dsnguoiduthi_idngthi AND d.dsnguoiduthi_idphthi=p.phongthi_id AND p.phongthi_idtrinhdo=t.trinhdo_id " +
                    "AND p.phongthi_id = " + idPhongThi;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_id = Convert.ToInt32(reader["nguoiduthi_id"]);
                    dto.nguoiduthi_hoten = reader["nguoiduthi_hoten"].ToString();
                    dto.nguoiduthi_namsinh = reader["nguoiduthi_namsinh"].ToString();
                    dto.nguoiduthi_gioitinh = reader["nguoiduthi_gioitinh"].ToString();
                    dto.nguoiduthi_cmnd = reader["nguoiduthi_cmnd"].ToString();
                    dto.nguoiduthi_sdt = reader["nguoiduthi_sdt"].ToString();
                    dto.nguoiduthi_diachi = reader["nguoiduthi_diachi"].ToString();
                    dto.dsnguoiduthi_id = Convert.ToInt32(reader["dsnguoiduthi_id"]);
                    dto.sobaodanh = reader["dsnguoiduthi_sbd"].ToString();
                    list.Add(dto);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }
            return list;
        }
        //Lấy thông tin phòng thi theo tên và số điện thoại người dự thi
        public List<NguoiDuThi> GetPhongThiTenSDT(string hoten, string sodienthoai)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT n.nguoiduthi_id,d.dsnguoiduthi_id,d.dsnguoiduthi_sbd,n.nguoiduthi_hoten,n.nguoiduthi_sdt,n.nguoiduthi_cmnd, p.phongthi_ten,k.khoathi_ten,t.trinhdo_ten " +
                    "FROM nguoiduthi AS n, dsnguoiduthi AS d, phongthi AS p, khoathi AS k, trinhdo AS t " +
                    "WHERE n.nguoiduthi_id=d.dsnguoiduthi_idngthi AND d.dsnguoiduthi_idphthi=p.phongthi_id AND p.phongthi_idkhoa=k.khoathi_id AND p.phongthi_idtrinhdo=t.trinhdo_id " +
                    "AND n.nguoiduthi_hoten='" + hoten + "' AND n.nguoiduthi_sdt='"+ sodienthoai +"'";
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_id = Convert.ToInt32(reader["nguoiduthi_id"]);
                    dto.nguoiduthi_hoten = reader["nguoiduthi_hoten"].ToString();
                    dto.nguoiduthi_cmnd = reader["nguoiduthi_cmnd"].ToString();
                    dto.nguoiduthi_sdt = reader["nguoiduthi_sdt"].ToString();
                    dto.phongthi_ten = reader["phongthi_ten"].ToString();
                    dto.khoathi_ten = reader["khoathi_ten"].ToString();
                    dto.nguoiduthi_trinhdo_ten = reader["trinhdo_ten"].ToString();
                    dto.dsnguoiduthi_id = Convert.ToInt32(reader["dsnguoiduthi_id"]);
                    dto.sobaodanh = reader["dsnguoiduthi_sbd"].ToString();
                    list.Add(dto);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }
            return list;
        }
        public List<ThongKe> ThongKeKhoaThiPhongThi(int idTrinhDo)
        {
            listKhoaThi = new List<ThongKe>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query ="SELECT COUNT(p.phongthi_id) AS 'soluongphongthi', COUNT(DISTINCT p.phongthi_idkhoa) AS 'soluongkhoathi' FROM phongthi AS p WHERE p.phongthi_idtrinhdo = " + idTrinhDo;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    thongkeDTO = new ThongKe();
                    thongkeDTO.soluong_phongthi = Convert.ToInt32(reader["soluongphongthi"]);
                    thongkeDTO.soluong_khoathi = Convert.ToInt32(reader["soluongkhoathi"]);
                    listKhoaThi.Add(thongkeDTO);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return listKhoaThi;
        }
        public List<NguoiDuThi> GetKhoaThiTheoTrinhDo(int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT DISTINCT k.khoathi_id, k.khoathi_ten FROM phongthi AS p, khoathi AS k WHERE p.phongthi_idkhoa=k.khoathi_id AND p.phongthi_idtrinhdo = " + idTrinhDo;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.khoathi_id = Convert.ToInt32(reader["khoathi_id"]);
                    dto.khoathi_ten = reader["khoathi_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        public List<NguoiDuThi> GetPhongThiTheoTrinhDo(int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT p.phongthi_id, p.phongthi_ten FROM phongthi AS p WHERE p.phongthi_idtrinhdo = " + idTrinhDo;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.phongthi_id = Convert.ToInt32(reader["phongthi_id"]);
                    dto.phongthi_ten = reader["phongthi_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        public List<NguoiDuThi> GetSinhVienTheoTrinhDo(int idKhoaThi, int idTrinhDo)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT n.nguoiduthi_hoten, n.nguoiduthi_namsinh,n.nguoiduthi_cmnd,n.nguoiduthi_sdt, d.dsnguoiduthi_sbd, p.phongthi_ten FROM nguoiduthi AS n, dsnguoiduthi AS d, phongthi AS p WHERE d.dsnguoiduthi_idngthi=n.nguoiduthi_id AND d.dsnguoiduthi_idphthi=p.phongthi_id AND p.phongthi_idkhoa = "+idKhoaThi+" AND p.phongthi_idtrinhdo = " + idTrinhDo;
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_hoten = reader["nguoiduthi_hoten"].ToString();
                    dto.nguoiduthi_namsinh = reader["nguoiduthi_namsinh"].ToString();
                    dto.nguoiduthi_cmnd = reader["nguoiduthi_cmnd"].ToString();
                    dto.nguoiduthi_sdt = reader["nguoiduthi_sdt"].ToString();
                    dto.sobaodanh = reader["dsnguoiduthi_sbd"].ToString();
                    dto.phongthi_ten = reader["phongthi_ten"].ToString();
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
        public List<NguoiDuThi> GetDiemThi(string sobaodanh)
        {
            list = new List<NguoiDuThi>();
            MySqlConnection conn = KetNoi();
            try
            {
                string query = "SELECT n.nguoiduthi_hoten,d.dsnguoiduthi_sbd,n.nguoiduthi_namsinh,n.nguoiduthi_cmnd,n.nguoiduthi_sdt,k.khoathi_ten,t.trinhdo_ten,q.ketqua_diemnghe,q.ketqua_diemnoi,q.ketqua_diemdoc,q.ketqua_diemviet " +
                    "FROM dsnguoiduthi AS d, nguoiduthi AS n, trinhdo AS t, khoathi AS k, ketqua AS q " +
                    "WHERE d.dsnguoiduthi_idngthi=n.nguoiduthi_id AND n.nguoiduthi_idkhoathi=k.khoathi_id AND n.nguoiduthi_idtrinhdo=t.trinhdo_id AND d.dsnguoiduthi_id=q.ketqua_iddsngthi " +
                    "AND d.dsnguoiduthi_sbd = '"+ sobaodanh + "'";
                myCommand = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    dto = new NguoiDuThi();
                    dto.nguoiduthi_hoten = reader["nguoiduthi_hoten"].ToString();
                    dto.sobaodanh = reader["dsnguoiduthi_sbd"].ToString();
                    dto.nguoiduthi_namsinh = reader["nguoiduthi_namsinh"].ToString();
                    dto.nguoiduthi_cmnd = reader["nguoiduthi_cmnd"].ToString();
                    dto.nguoiduthi_sdt = reader["nguoiduthi_sdt"].ToString();
                    dto.khoathi_ten = reader["khoathi_ten"].ToString();
                    dto.nguoiduthi_trinhdo_ten = reader["trinhdo_ten"].ToString();
                    dto.diemnghe = Convert.ToDouble(reader["ketqua_diemnghe"]);
                    dto.diemnoi = Convert.ToDouble(reader["ketqua_diemnoi"]);
                    dto.diemdoc = Convert.ToDouble(reader["ketqua_diemdoc"]);
                    dto.diemviet = Convert.ToDouble(reader["ketqua_diemviet"]);
                    list.Add(dto);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                conn.Close();
            }

            return list;
        }
    }

}