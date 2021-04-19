using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIYOKEA.Models;
namespace BIYOKEA.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        //Số người truy cập
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            ViewBag.SoNguoiDaTruyCap = HttpContext.Application["pageView"].ToString();
            ViewBag.SoNguoiDangTrucTuyen = HttpContext.Application["viewOnline"].ToString();
            ViewBag.TongTaiKhoan = ThongKeTaiKhoan();
            ViewBag.doanhThu = ThongKeDoanhThu();
            return View();
        }
        public int ThongKeTaiKhoan()
        {
            var tongTK = 0;
            tongTK = data.NguoiDungs.Count();
            return tongTK;
        }
        public int ThongKeDoanhThu()
        {
            int  tongDoanhThu = 0;
            var thongKe = from sp in data.SanPhams
                          join hd in data.HoaDons on sp.maSP equals hd.maSP
                          where hd.trangThai==true && hd.xacNhan==true
                          select new { sp.gia, hd.soLuongBan };
            foreach(var item in thongKe)
            {
                var a = item.soLuongBan*item.gia;
                tongDoanhThu +=(int)a;
            }    
            return tongDoanhThu;
        }
    }
}