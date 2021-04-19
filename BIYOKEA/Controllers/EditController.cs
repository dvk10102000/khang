using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIYOKEA.Models;
namespace BIYOKEA.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        DataClasses1DataContext data = new DataClasses1DataContext();


        [HttpGet]
        public ActionResult Sua(int id)
        {
            SanPham sp = new SanPham();
            sp = data.SanPhams.First(m => m.maSP == id);
            ViewBag.sp = sp;
            return View();
        }
        [HttpPost]
        
        public ActionResult Sua(HttpPostedFileBase file, int id, FormCollection form)
        {
            string fileName = null;
            var sp = data.SanPhams.First(m => m.maSP == id);
            var name = form["ten"];
            if (string.IsNullOrEmpty(name))
            {
                ViewData["loi"] = "the name is not empty";
            }
            else
            {
                sp.maSP = id;
                sp.tenSP = form["ten"];
                sp.soLuong = Int32.Parse(form["soLuong"]);
                sp.gia = Decimal.Parse(form["gia"]);
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Asset/shop/new_add/"), fileName);
                    file.SaveAs(path);
                }
                sp.photoURL = "/Asset/shop/new_add/" + fileName;
                ViewBag.Update = true;
                UpdateModel(sp);
                data.SubmitChanges();
                return RedirectToAction("editItem", "Admin");
            }
            //return this.Sua(id);
            return this.Sua(id);
        }




        //public ActionResult Sua(int id)
        //{
        //    SanPham sp = new SanPham();
        //    sp = data.SanPhams.First(m => m.maSP == id);
        //    ViewBag.sp = sp;
        //    return View(ViewBag.sp);
        //}
        //[HttpPost]
        //public ActionResult Sua(FormCollection form, int id, HttpPostedFileBase file)
        //{
        //    string fileName = null;
        //    var sp = data.SanPhams.First(m => m.maSP == id);
        //    var name = form["ten"];
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        ViewData["loi"] = "the name is not empty";
        //    }
        //    else
        //    {

        //        sp.tenSP = form["ten"];
        //        sp.soLuong = Int32.Parse(form["soLuong"]);
        //        sp.gia = Decimal.Parse(form["gia"]);
        //        if (file != null)
        //        {
        //            fileName = System.IO.Path.GetFileName(file.FileName);
        //            string path = System.IO.Path.Combine(Server.MapPath("~/Asset/shop/new_add/"), fileName);
        //            // file is uploaded
        //            file.SaveAs(path);
        //        }
        //            sp.photoURL = "/Asset/shop/new_add/" + fileName;
        //            UpdateModel(sp);
        //            data.SubmitChanges();
        //            return RedirectToAction("editItem", "Admin");


        //    }
        //    return View();
        //}

        public ActionResult Xoa(int id)
        {
            SanPham sp = new SanPham();
            sp = data.SanPhams.First(m => m.maSP == id);
            //ViewBag.sp = sp;
            return View(sp);
        }
        [HttpPost]
        public ActionResult Xoa(FormCollection form, int id)
        {
            var sp = data.SanPhams.Where(m => m.maSP == id).First();
            data.SanPhams.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("editItem", "Admin");
        }
        //[HttpGet]
        //public ActionResult create()
        //{
        //    ViewBag.maCTloai = new SelectList(data.CTloaiSPs.OrderBy(m => m.maCTloai), "maCTloai", "maCTloai");
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult create(SanPham sp,HttpPostedFileBase photoURL)
        //{

        //    ViewBag.maCTloai = new SelectList(data.CTloaiSPs.OrderBy(m => m.maCTloai), "maCTloai", "maCTloai");
        //    try
        //    {
        //        if (photoURL.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(photoURL.FileName);
        //            string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
        //            photoURL.SaveAs(_path);
        //        }
        //        ViewBag.Message = "File Uploaded Successfully!!";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed!!";
        //        return View();
        //    }

        //}
        public ActionResult create()
        {
            ViewBag.maCTloai = new SelectList(data.CTloaiSPs.OrderBy(m => m.maCTloai), "maCTloai", "maCTloai");
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult create(HttpPostedFileBase file,SanPham sp,FormCollection f)
        {
            ViewBag.maCTloai = new SelectList(data.CTloaiSPs.OrderBy(m => m.maCTloai), "maCTloai", "maCTloai");
            string fileName = null;
            if (file != null)
            {
                fileName = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Asset/shop/new_add/"), fileName);
                // file is uploaded
                file.SaveAs(path);
                ViewBag.Message = true;
                sp.photoURL = "/Asset/shop/new_add/" + fileName;
            }
            sp.ngayThem = DateTime.Parse(f["ngayThem"]);
            data.SanPhams.InsertOnSubmit(sp);
            data.SubmitChanges();
            

            return View();
        }
        public ActionResult themLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themLoai(FormCollection form)
        {
            LoaiSP loai = new LoaiSP();
            loai.tenLoai = form["tenLoai"];
            data.LoaiSPs.InsertOnSubmit(loai);
            data.SubmitChanges();
            ViewBag.ok = true;
            return View();
        }
        public ActionResult themChiTietLoai()
        {
            ViewBag.maLoai = new SelectList(data.LoaiSPs.OrderBy(m => m.maLoai), "maLoai", "maLoai");
            return View();
        }
        [HttpPost]
        public ActionResult themChiTietLoai(FormCollection form)
        {
            ViewBag.maLoai = new SelectList(data.LoaiSPs.OrderBy(m => m.maLoai), "maLoai", "maLoai");
            CTloaiSP chiTiet = new CTloaiSP();
            chiTiet.maLoai = int.Parse(form["maLoai"]);
            chiTiet.tenCTloai = form["tenCTloai"];
            ViewBag.ok = true;
            data.CTloaiSPs.InsertOnSubmit(chiTiet);
            data.SubmitChanges();
            return View();
        }
    }
}