using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIYOKEA.Models;

namespace BIYOKEA.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index(ItemSearched form)
        {
            var all_sp = from t in data.SanPhams
                         join k in data.CTloaiSPs
                         on t.maCTloai equals k.maCTloai
                         join c in data.LoaiSPs
                         on k.maLoai equals c.maLoai
                         select new { t.maSP, t.tenSP, k.maCTloai, c.maLoai, t.gia, t.photoURL, t.soLuong };
            ItemSearched item = new ItemSearched();
            item.loai = form.loai;
            if ( form.loai != "Tat ca" && form.loai != null)
            {
                var loai = data.LoaiSPs.FirstOrDefault(i => i.tenLoai == item.loai);
                if (loai != null)
                {
                    all_sp = all_sp.Where(x => x.maLoai == loai.maLoai);
                }
                else
                {
                    var ctLoai = data.CTloaiSPs.First(i => i.tenCTloai == item.loai);
                    all_sp = all_sp.Where(x => x.maCTloai == ctLoai.maCTloai);
                }
            }
            
            if (form.ten != "" && form.ten != null)
            {
                item.ten = form.ten;
                all_sp = all_sp.Where(i => i.tenSP.Contains(item.ten));
            }
            if (form.from != 0)
            {
                item.from = form.from;
                all_sp = all_sp.Where(i => i.gia >= item.from);
            }
            if (form.to != 0)
            {
                item.to = form.to;
                all_sp = all_sp.Where(i => i.gia <= item.to);
            }
            
            var all_loai = from loais in data.LoaiSPs select loais;
            var all_ctLoai = from ctLoais in data.CTloaiSPs select ctLoais;
            string[] a = new string[26];
            int z = 0;
            foreach(var loai in all_loai)
            {
                a[z] = loai.tenLoai;
                foreach(var ctLoai in all_ctLoai)
                {
                    if(loai.maLoai == ctLoai.maLoai)
                    {
                        z++;
                        a[z] = ctLoai.tenCTloai;
                    }
                }
            }
            List<SanPham> all = new List<SanPham>();
            
            foreach (var sp in all_sp)
            {
                SanPham x = new SanPham();
                x.maSP = sp.maSP;
                x.tenSP = sp.tenSP;
                x.gia = sp.gia;
                x.photoURL = sp.photoURL;
                all.Add(x);
            }
            Object[] n = new Object[] { all, item, a };
            return View(n);
        }
    }
}