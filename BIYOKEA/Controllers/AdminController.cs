using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIYOKEA.Models;
using PagedList;

namespace BIYOKEA.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataClasses1DataContext data = new DataClasses1DataContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Register(FormCollection f,NguoiDung nd)
        {

            var tenND = f["tenND"];
            var Email = f["email"];
            var matKhau = f["matKhau"];
            var SDT = f["SDT"];
            var Quyen = f["quyen"];
            var diaChi = f["diaChi"];
            if (string.IsNullOrEmpty(tenND))
            {
                ViewData["Loi"] = "Đăng Kí Thất Bại";
            }
            else
            {
                nd.tenND = tenND;
                nd.email = Email;
                nd.matKhau = matKhau;
                nd.sdt = SDT;
                nd.quyen = Quyen;
                nd.diaChi = diaChi;
                data.NguoiDungs.InsertOnSubmit(nd);
                data.SubmitChanges();
                return RedirectToAction("Register1", nd);
                
            }
            return this.Register();
            
        }
        public ActionResult Register1(NguoiDung nd)
        {
            return View(nd);
        }
        [HttpGet]
        public ActionResult dangNhap()
        {
            return View();
        }
       
        public ActionResult dangNhap(FormCollection f)
        {
            string tenTK = f["tenTK"].ToString();
            string MK = f["matKhau"].ToString();
            NguoiDung nd = data.NguoiDungs.SingleOrDefault(tt => tt.tenND == tenTK && tt.matKhau == MK);
            if(nd != null)
            {
                Session["taikhoan"] = nd;
                Session["tenTaiKhoan"] = nd.tenND;
                Session["Quyen"] = nd.quyen;
                return View("Register1", nd);
            }
            ViewData["Loi"] = "Đăng nhập thất bại";
            return this.dangNhap();
        }
        //public ActionResult thongTin()
        //{
        //    if(Session["taikhoan"]!=null)
        //    {

        //    }    
        //    return View();
        //}
        public ActionResult dangXuat()
        {
            Session["taikhoan"] = null;
            return RedirectToAction("Index","TrangChu");
        }
        public ActionResult quanLi(int? page)
        {
            var all = from tt in data.SanPhams select tt;
            // Số sản phẩm trên 1 trang
            int pageSize = 20;
            //số trang hiện tại
            int pageNumber = (page ?? 1);
            return View(all.OrderByDescending(n=>n.maSP).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult editItem(FormCollection form, int? page)
        { 
            var all = (from tt in data.SanPhams select tt);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            
            return View(all.OrderByDescending(n => n.maSP).ToPagedList(pageNumber, pageSize));
            
            
        }
        public ActionResult xuLiGioHang()
        {
            
            var list = from t in data.HoaDons
                             join k in data.NguoiDungs
                             on t.maND equals k.maND
                             where t.trangThai==true 
                             select new { t.maHD,t.maND, t.maSP, k.tenND, t.diaChi, t.soLuongBan, t.trangThai, t.ngayTL, t.xacNhan};
            List<GioHang> all = new List<GioHang>();
            foreach(var item in list)
            {
                GioHang a = new GioHang();
                a.maHD = (int)item.maHD;
                a.maND = (int)item.maND;
                a.maSP = (int)item.maSP;
                a.tenND = item.tenND;
                a.diaChi = item.diaChi;
                a.soLuongBan =(int)item.soLuongBan;
                a.trangThai = (bool)item.trangThai;
                a.ngayTL = (DateTime)item.ngayTL;
                a.xacNhan = (bool)item.xacNhan;
                all.Add(a);
            }
            return View(all);
        }
        [HttpPost]
        public ActionResult xuLiGioHang(HoaDon maHD)
        {

            return View();
        }
        public ActionResult XuLiDonHang(int id)
        {
            var tt = from k in data.NguoiDungs
                     join t in data.HoaDons
                     on k.maND equals t.maND
                     join l in data.SanPhams
                     on t.maSP equals l.maSP
                     where t.maHD == id
                     select new { t.maHD, t.maND, t.maSP, k.tenND, t.diaChi, l.photoURL, t.soLuongBan, t.trangThai, t.ngayTL, t.xacNhan ,l.gia,k.sdt};
            GioHang a = new GioHang();
            var item = tt.First();
            a.maHD = (int)item.maHD;
            a.maND = (int)item.maND;
            a.maSP = (int)item.maSP;
            a.tenND = item.tenND;
            a.diaChi = item.diaChi;
            a.photoURL = item.photoURL;
            a.soLuongBan = (int)item.soLuongBan;
            a.trangThai = (bool)item.trangThai;
            a.ngayTL = (DateTime)item.ngayTL;
            a.xacNhan = (bool)item.xacNhan;
            a.gia = (decimal)item.gia;
            a.sdt = item.sdt;
            return View(a);
        }
        [HttpPost]
        public ActionResult XuLiDonHang(FormCollection form,int id)
        {
            HoaDon hd = data.HoaDons.Single(n => n.maHD == id); 
                hd.xacNhan = true;
                UpdateModel(hd);
                data.SubmitChanges();
                ViewBag.Confirm = true;

            return RedirectToAction("/xuLiGioHang");
        }



    }
}