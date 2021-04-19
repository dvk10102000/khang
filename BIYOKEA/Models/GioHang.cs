using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIYOKEA.Models
{
    public class GioHang
    { 
        public int maHD { get; set; }
        public int maND { get; set; }
        public int maSP { get; set; }
        public string tenND { get; set; }
        public string sdt { get; set; }
        public string diaChi { get; set; }
        public int soLuongBan { get; set; }
        public bool trangThai { get; set; }
        public DateTime ngayTL { get; set; }
        public bool xacNhan { get; set; }
        public string photoURL { get; set; }
        public decimal gia { get; set; }

    }
}