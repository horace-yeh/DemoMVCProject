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
    public class InventoryController : Controller
    {
        private IInventoryService inventoryService;
        private IMaterialService materialService;
        private IUserService userService;


        public InventoryController()
        {
            this.inventoryService = new InventoryService();
            this.materialService = new MaterialService();
            this.userService = new UserService();
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 取得庫存資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult JsonGetListData()
        {
            try
            {
                var temp = this.inventoryService.GetAllHaveInfo().ToList();
                var model = new InventoryViewModel() { ListData = temp };
                return Json(new ReData { Success = true, Data = model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 取得物料選單資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult JsonGetMaterialSelect()
        {
            try
            {
                var temp = this.materialService.GetAll().ToList();
                return Json(new ReData { Success = true, Data = temp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 物料入庫
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult StockIn(Inventory item)
        {
            try
            {
                item.Creater = this.userService.GetIDByAccount(User.Identity.Name);
                item.LastEditor = item.Creater;
                this.inventoryService.StockIn(item);
                return Json(new ReData { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 物料出庫
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult StockOut(Inventory item)
        {
            try
            {
                item.LastEditor = this.userService.GetIDByAccount(User.Identity.Name);
                this.inventoryService.StockOut(item);
                return Json(new ReData { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReData { Success = false, Message = ex.Message });
            }
        }
    }
}