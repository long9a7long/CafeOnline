﻿using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using System;
using Models.Common;
using Model.DTO;

namespace CafeOnline.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page =1 )
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        } 
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.GetByName(user.UserID) == null)
                {
                    string id = dao.Insert(user);
                    if (id != null)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm Người Dùng Không Thành Công !");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Người Dùng Đã Tồn Tại !");
                }
            }
            return View("Index");
            
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new GrantDao();
            ViewBag.GrantID = new SelectList(dao.ListAll(), "GrantID", "GrantName", selectedID);
        }

        public JsonResult ChangeStatus(string userID)
        {
            bool result = false;
            try
            {
                result = UserDao.Instance.changeStatus(userID);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string userID)
        {
            var sess = (Model.DTO.UserSession)Session[Constants.USER_SESSION];
            string session = sess.UserName;
            bool result = false;
            if (string.Compare(session, userID,true)==0)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    result = UserDao.Instance.Delete(userID);
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }    
        }

        public JsonResult EditName(string userID,string column, string name)
        {
            var result = UserDao.Instance.UpdateName(userID, column, name);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}