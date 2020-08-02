using Demo.Data.Models;
using Demo.Data.ViewModels;
using Demo.Service;
using Demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private IMaterialService materialService;
        private IUserService userService;

        public MaterialController()
        {
            this.materialService = new MaterialService();
            this.userService = new UserService();
        }


        // GET: Material
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 取得所有物料資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult JsonGetListData()
        {
            try
            {
                var temp = this.materialService.GetAllHaveInfo().ToList();
                var model = new MaterialViewModel() { ListData = temp };
                return Json(new ReData { Success = true, Data = model }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonCreate(Material material)
        {
            try
            {
                material.Creater = this.userService.GetIDByAccount(User.Identity.Name);
                material.LastEditor = material.Creater;
                this.materialService.Create(material);
                return Json(new ReData { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 物料變更
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonUpdate(Material material)
        {
            try
            {
                material.LastEditor = this.userService.GetIDByAccount(User.Identity.Name);
                this.materialService.Update(material);
                return Json(new ReData { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 物料刪除
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonDelete(Material material)
        {
            try
            {
                this.materialService.Delete(material);
                return Json(new ReData { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message });
            }
        }
    }
}