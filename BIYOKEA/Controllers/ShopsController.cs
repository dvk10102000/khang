using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Linq;
using System.Web.Mvc;
using BIYOKEA.Models; 

namespace BIYOKEA.Controllers
{
    public class ShopsController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Shops
        public ActionResult Index(int id = 1)
        {
            NguoiDung nd = Session["nguoiDung"] as NguoiDung;
            if(nd == null)
            {
                List<HoaDon> list = Session["cart"] as List<HoaDon>;
                HoaDon[] aa = list.ToArray();
                Session["slItem"] = aa.Length;
            }
            else
            {
                var items = data.HoaDons.Where(i => i.maND == nd.maND && i.trangThai == false);
                int n = items.ToArray().Length;
                Session["slItem"] = n;
            }
            var all_sp = from tt in data.SanPhams select tt;
            string sapXep = Request["sapXep"];
            switch (sapXep)
            {
                case "Mới cập nhật":
                    all_sp = from tt in data.SanPhams 
                            orderby tt.ngayThem descending
                            select tt;
                    break;
                case "Giá tăng dần":
                    all_sp = from tt in data.SanPhams
                             orderby tt.gia
                             select tt;
                    break;
                case "Giá giảm dần":
                    all_sp = from tt in data.SanPhams
                             orderby tt.gia descending
                             select tt;
                    break;
                default:
                    all_sp = from tt in data.SanPhams
                             orderby tt.ngayThem descending
                             select tt;
                    break;
            }
            var all_loai = from tt in data.LoaiSPs select tt;
            var all_ctLoai = from tt in data.CTloaiSPs select tt;
            var all_sp_most = (
                              from k in data.HoaDons
                              where k.trangThai == true
                              group k by k.maSP into kq
                              orderby kq.Sum(i => i.soLuongBan) descending
                              select
                              new { maSP = kq.Key }
                              ).Take(5).ToArray();
            int[] arr = new int[5];
            int j = 0;
            foreach(var sp in all_sp_most)
            {
                arr[j] = (int)sp.maSP;
                j++;
            }
            SanPham[] mang = new SanPham[5];
            int t = 0;
            foreach(var sp in all_sp)
            {
                if(Array.IndexOf(arr, sp.maSP) > -1)
                {
                    mang[t] = sp;
                    t++;
                }
            }
           
            var b = all_sp.ToArray();
            int pages = b.Length/6;
            if(b.Length%6 != 0)
            {
                pages++;
            }
            int from = (id - 1) * 6;
            int to = id * 6 -1;
            var c = b.Where((val, index) => index >= from && index <= to);
            Object[] a = new Object[7] { all_ctLoai, all_loai, c, mang, id, pages, sapXep };
            return View(a);
        }
        
        
        public ActionResult AddToCart(int param1, FormCollection form)
        {
            var sp = data.SanPhams.First(m => m.maSP == param1);
            NguoiDung a = Session["nguoiDung"] as NguoiDung;
            if (a != null)
            {
                var nd = data.NguoiDungs.First(i => i.maND == a.maND);
                var hoaDon = data.HoaDons.FirstOrDefault(i => i.maSP == sp.maSP && i.maND == nd.maND && i.trangThai==false);
                if(hoaDon != null)
                {
                    hoaDon.soLuongBan = int.Parse(form["soLuongBan"]);
                    UpdateModel(hoaDon);
                    data.SubmitChanges();
                }
                else {
                    HoaDon hd = new HoaDon();
                    hd.maND = nd.maND;
                    hd.maSP = sp.maSP;
                    hd.diaChi = nd.diaChi;
                    hd.soLuongBan = int.Parse(form["soLuongBan"]);
                    hd.trangThai = false;
                    hd.xacNhan = false;
                    data.HoaDons.InsertOnSubmit(hd);
                    data.SubmitChanges();
                }
            }
            else
            {
                
                HoaDon hd = new HoaDon();
                hd.maSP = sp.maSP;
                hd.soLuongBan = int.Parse(form["soLuongBan"]);
                if (hd.soLuongBan <= sp.soLuong)
                {
                    List<HoaDon> cart = Session["cart"] as List<HoaDon>;
                    HoaDon c = cart.Find(x => x.maSP == sp.maSP);
                    if (c != null)
                    {
                        cart.Remove(c);
                        cart.Add(hd);
                    }
                    else
                    {
                        cart.Add(hd);
                    }
                    Session["cart"] = cart;
                }
                else
                {
                    ViewBag.error = "Số sản phẩm không còn đủ";
                }
                
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Type(int param1 = 1, int param2 = 1)
        {
            int loai = param1;
            int pageNum = param2;
            var all_loai = from tt in data.LoaiSPs select tt;
            var all_ctLoai = from tt in data.CTloaiSPs select tt;
            var all_sp = from tt in data.SanPhams
                         join k in data.CTloaiSPs
                         on tt.maCTloai equals k.maCTloai
                         join p in data.LoaiSPs
                         on k.maLoai equals p.maLoai
                         where p.maLoai == loai
                         select tt;
            string sapXep = Request["sapXep"];
            switch (sapXep)
            {
                case "Mới cập nhật":
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             join p in data.LoaiSPs
                             on k.maLoai equals p.maLoai
                             where p.maLoai == loai
                             orderby tt.ngayThem descending
                             select tt;
                    break;
                case "Giá tăng dần":
                    all_sp = from tt in data.SanPhams
                            join k in data.CTloaiSPs
                            on tt.maCTloai equals k.maCTloai
                            join p in data.LoaiSPs
                            on k.maLoai equals p.maLoai
                            where p.maLoai == loai
                            orderby tt.gia
                            select tt;
                    break;
                case "Giá giảm dần":
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             join p in data.LoaiSPs
                             on k.maLoai equals p.maLoai
                             where p.maLoai == loai
                             orderby tt.gia descending
                             select tt;
                    break;
                default:
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             join p in data.LoaiSPs
                             on k.maLoai equals p.maLoai
                             where p.maLoai == loai
                             orderby tt.ngayThem descending
                             select tt;
                    break;
            }
            var b = all_sp.ToArray();
            int pages = b.Length / 6;
            if (b.Length % 6 != 0)
            {
                pages++;
            }
            int from = (pageNum - 1) * 6;
            int to = pageNum * 6 - 1;
            var c = b.Where((val, index) => index >= from && index <= to);
            var all_sp_most = (
                              from k in data.HoaDons
                              where k.trangThai == true
                              group k by k.maSP into kq
                              orderby kq.Sum(i => i.soLuongBan) descending
                              select
                              new { maSP = kq.Key }
                              ).Take(5).ToArray();
           
            int[] arr = new int[5];
            int j = 0;
            foreach (var sp in all_sp_most)
            {
                arr[j] = (int)sp.maSP;
                j++;
            }
            SanPham[] mang = new SanPham[5];
            int t = 0;
            foreach (var sp in all_sp)
            {
                if (Array.IndexOf(arr, sp.maSP) > -1)
                {
                    mang[t] = sp;
                    t++;
                }
            }
            Object[] a = new Object[8] { all_ctLoai, all_loai, c, loai, pageNum, pages, mang, sapXep };
            return View(a);
        }

        public ActionResult TypeDetail(int param1 = 1, int param2 = 1)
        {
            int ctLoai = param1;
            int pageNum = param2;
            var all_loai = from tt in data.LoaiSPs select tt;
            var all_ctLoai = from tt in data.CTloaiSPs select tt;
            var all_sp = from tt in data.SanPhams
                         join k in data.CTloaiSPs
                         on tt.maCTloai equals k.maCTloai
                         where k.maCTloai == ctLoai
                         select tt;
            string sapXep = Request["sapXep"];
            switch (sapXep)
            {
                case "Mới cập nhật":
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             where k.maCTloai == ctLoai
                             orderby tt.ngayThem descending
                             select tt;
                    break;
                case "Giá tăng dần":
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             where k.maCTloai == ctLoai
                             orderby tt.gia
                             select tt;
                    break;
                case "Giá giảm dần":
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             where k.maCTloai == ctLoai
                             orderby tt.gia descending
                             select tt;
                    break;
                default:
                    all_sp = from tt in data.SanPhams
                             join k in data.CTloaiSPs
                             on tt.maCTloai equals k.maCTloai
                             where k.maCTloai == ctLoai
                             orderby tt.ngayThem descending
                             select tt;
                    break;
            }
            var all_sp_most = (
                              from k in data.HoaDons
                              where k.trangThai == true
                              group k by k.maSP into kq
                              orderby kq.Sum(i => i.soLuongBan) descending
                              select
                              new { maSP = kq.Key }
                              ).Take(5).ToArray();
            int[] arr = new int[5];
            int j = 0;
            foreach (var sp in all_sp_most)
            {
                arr[j] = (int)sp.maSP;
                j++;
            }
            SanPham[] mang = new SanPham[5];
            int t = 0;
            foreach (var sp in all_sp)
            {
                if (Array.IndexOf(arr, sp.maSP) > -1)
                {
                    mang[t] = sp;
                    t++;
                }
            }

            var b = all_sp.ToArray();
            int pages = b.Length / 6;
            if (b.Length % 6 != 0)
            {
                pages++;
            }
            int from = (pageNum - 1) * 6;
            int to = pageNum * 6 - 1;
            var c = b.Where((val, index) => index >= from && index <= to);
            Object[] a = new Object[8] { all_ctLoai, all_loai, c, ctLoai, pageNum, pages, mang, sapXep };
            return View(a);
        }

        public ActionResult ProductDetail(int param1)
        {
            var sp = data.SanPhams.First(e => e.maSP == param1);
            var all_sp = data.SanPhams.Where(e => e.maCTloai == sp.maCTloai && e.maSP != sp.maSP).Take(6);
            var all_sp_most = (
                              from k in data.HoaDons
                              where k.trangThai == true
                              group k by k.maSP into kq
                              orderby kq.Sum(i => i.soLuongBan) descending
                              select
                              new { maSP = kq.Key }
                              ).Take(5).ToArray();
            int[] arr = new int[5];
            int j = 0;
            foreach (var item in all_sp_most)
            {
                arr[j] = (int)item.maSP;
                j++;
            }
            SanPham[] mang = new SanPham[5];
            int t = 0;
            foreach (var item in all_sp)
            {
                if (Array.IndexOf(arr, item.maSP) > -1)
                {
                    mang[t] = item;
                    t++;
                }
            }

            Object[] a = new Object[] { sp, all_sp, mang };
            return View(a);
        }

        public ActionResult Cart(string param1)
        {
            List<SanPhamCart> all = new List<SanPhamCart>();
            NguoiDung nd = Session["nguoiDung"] as NguoiDung;
            if (nd != null)
            {
                var all_sp = from t in data.SanPhams
                             join k in data.HoaDons
                             on t.maSP equals k.maSP
                             where k.maND == nd.maND && k.trangThai == false
                             select new { t.tenSP, t.gia, k.soLuongBan };
                foreach(var sp in all_sp)
                {
                    SanPhamCart b = new SanPhamCart();
                    b.tenSP = sp.tenSP;
                    b.gia = sp.gia + "";
                    b.soLuongBan = sp.soLuongBan + "";
                    all.Add(b);
                }
                var items = data.HoaDons.Where(i => i.maND == nd.maND && i.trangThai == false);
                int n = items.ToArray().Length;
                Session["slItem"] = n;
            }
            else
            {
                var all_sp = from t in data.SanPhams select t;
                List<HoaDon> cart = Session["cart"] as List<HoaDon>;
                HoaDon[] a = cart.ToArray();
                foreach (var sp in all_sp)
                {
                    foreach (var j in a)
                    {
                        if (sp.maSP == j.maSP)
                        {
                            SanPhamCart b = new SanPhamCart();
                            b.tenSP = sp.tenSP;
                            b.gia = sp.gia + "";
                            b.soLuongBan = j.soLuongBan + "";
                            all.Add(b);
                        }
                    }
                }
                List<HoaDon> list = Session["cart"] as List<HoaDon>;
                HoaDon[] aa = list.ToArray();
                Session["slItem"] = aa.Length;
            }
            
            return View(all);
        }
        [HttpPost]
        public JsonResult UpdateCart(SanPhamCart[] itemlist)
        {
            NguoiDung nd = Session["nguoiDung"] as NguoiDung;
            if (nd != null)
            {
                var all_sp = from t in data.SanPhams
                             join k in data.HoaDons
                             on t.maSP equals k.maSP
                             where k.maND == nd.maND && k.trangThai == false
                             select new { k.maHD, k.maND, t.maSP, t.soLuong, k.diaChi, k.soLuongBan, t.tenSP, t.gia};
                foreach(var sp in all_sp)
                {
                    foreach(SanPhamCart item in itemlist)
                    {
                        if(sp.tenSP == item.tenSP && int.Parse(item.soLuongBan) <= sp.soLuong)
                        {
                            var hd = data.HoaDons.First(i => i.maHD == sp.maHD);
                            
                            hd.soLuongBan = int.Parse(item.soLuongBan);
                            UpdateModel(hd);
                            data.SubmitChanges();
                        }
                    }
                }

            }
            else
            {
                var all_sp = from t in data.SanPhams select t;
                List<HoaDon> cart = Session["cart"] as List<HoaDon>;
                List<HoaDon> cartUpdate = new List<HoaDon>();
                foreach (SanPhamCart item in itemlist)
                {
                    var sp = data.SanPhams.First(m => m.tenSP == item.tenSP);
                    
                    if (item.tenSP == sp.tenSP)
                    {
                        HoaDon i = new HoaDon();
                        i.maSP = sp.maSP;
                        if(int.Parse(item.soLuongBan) <= sp.soLuong)
                        {
                            i.soLuongBan = int.Parse(item.soLuongBan);
                        }
                        else
                        {
                            HoaDon cc = cart.Find(b => b.maSP == sp.maSP);
                            i.soLuongBan = cc.soLuongBan;
                        }
                        cartUpdate.Add(i);
                    }
                    
                }
                Session["cart"] = cartUpdate;
            }
            
            return Json("ok");
        }
        
        public ActionResult DeleteCartItem(string param1)
        {
            NguoiDung nd = Session["nguoiDung"] as NguoiDung;
            var sp = data.SanPhams.First(i => i.tenSP == param1);
            if (nd != null)
            {
                var hd = data.HoaDons.First(i => i.maSP == sp.maSP && i.maND == nd.maND && i.trangThai == false);
                data.HoaDons.DeleteOnSubmit(hd);
                data.SubmitChanges();
            }
            else
            {
                List<HoaDon> list = Session["cart"] as List<HoaDon>;
                HoaDon hd = list.Find(i => i.maSP == sp.maSP);
                list.Remove(hd);
                Session["cart"] = list;
            }
            return RedirectToAction("Cart");
        } 

        public ActionResult Order()
        {
            List<SanPhamCart> list = new List<SanPhamCart>();
            NguoiDung nd = Session["nguoiDung"] as NguoiDung;
            if (nd != null)
            {
                var all_hd = from t in data.SanPhams
                             join k in data.HoaDons
                             on t.maSP equals k.maSP
                             where k.maND == nd.maND && k.trangThai == false
                             select new { k.maHD, k.maND, t.maSP, k.diaChi, k.soLuongBan, t.tenSP, t.gia };
                
                foreach(var hd in all_hd)
                {
                    SanPhamCart a = new SanPhamCart();
                    a.tenSP = hd.tenSP;
                    a.gia = hd.gia + "";
                    a.soLuongBan = hd.soLuongBan + "";
                    list.Add(a);
                }
            }
            else
            {
                var all_sp = from t in data.SanPhams select t;
                List<HoaDon> cart = Session["cart"] as List<HoaDon>;
                HoaDon[] a = cart.ToArray();
                foreach (var sp in all_sp)
                {
                    foreach (var j in a)
                    {
                        if (sp.maSP == j.maSP)
                        {
                            SanPhamCart b = new SanPhamCart();
                            b.tenSP = sp.tenSP;
                            b.gia = sp.gia + "";
                            b.soLuongBan = j.soLuongBan + "";
                            list.Add(b);
                        }
                    }
                }
            }

            return View(list);
        }
        [HttpPost]
        public ActionResult Order(NguoiDung nd)
        {
            NguoiDung n = Session["nguoiDung"] as NguoiDung;
            if (n != null)
            {
                var all_hd = data.HoaDons.Where(i => i.maND == n.maND && i.trangThai == false);
                foreach(var hd in all_hd)
                {
                    var sp = data.SanPhams.First(i => i.maSP == hd.maSP);
                    if(sp.soLuong >= hd.soLuongBan)
                    {
                        hd.trangThai = true;
                        sp.soLuong = sp.soLuong - hd.soLuongBan;
                        hd.ngayTL = DateTime.Now;
                        UpdateModel(hd);
                        UpdateModel(sp);
                        data.SubmitChanges();
                    }
                }
            }
            else
            {
                data.NguoiDungs.InsertOnSubmit(nd);
                data.SubmitChanges();
                var a = data.NguoiDungs.First(i => i.tenND == nd.tenND);
                List<HoaDon> list = Session["cart"] as List<HoaDon>;
                List<HoaDon> items = new List<HoaDon>();
                foreach(HoaDon hd in list)
                {
                    var sp = data.SanPhams.First(i => i.maSP == hd.maSP);
                    if(sp.soLuong >= hd.soLuongBan)
                    {
                        hd.maND = a.maND;
                        hd.diaChi = a.diaChi;
                        hd.trangThai = true;
                        hd.xacNhan = false;
                        hd.ngayTL = DateTime.Now;
                        data.HoaDons.InsertOnSubmit(hd);
                        sp.soLuong = sp.soLuong - hd.soLuongBan;
                        data.SubmitChanges();
                    }
                    else
                    {
                        items.Add(hd);
                    }
                }
                Session["cart"] = items;
                
            }
            return RedirectToAction("Cart");
        }
    }
}