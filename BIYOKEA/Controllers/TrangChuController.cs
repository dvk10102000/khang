using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIYOKEA.Models;

namespace BIYOKEA.Controllers
{
    public class TrangChuController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var all_loai = from tt in data.LoaiSPs select tt;
            var all_ctLoai = from tt in data.CTloaiSPs select tt;
            var all_sp = from tt in data.SanPhams select tt;
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
            Object[] a = new Object[4] {all_ctLoai, all_loai, all_sp, mang };
            return View(a);
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