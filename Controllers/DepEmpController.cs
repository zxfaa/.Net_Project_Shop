using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using final.Models;
using final.Services;
using final.ViewModels;

namespace final.Controllers
{
    public class DepEmpController : Controller
    {
        //宣告Guestbooks資料表的Service物件
        private readonly DepEmpDBService DepEmpService = new DepEmpDBService();
        // GET: DepEmp
        public ActionResult Index(int depid = 1)
        {
            //宣告一個新頁面模型
            DepEmpViewModel Data = new DepEmpViewModel();

            //從Service 中取得分類的資料
            Data.depList = DepEmpService.GetDepList();

            //從Service 中取得分類的商品資料
            Data.empList = DepEmpService.GetEmpList(depid);

            //從Service 中取得分類的名稱
            Data.SrhId = depid;
            Data.SrhName = DepEmpService.GetDepName(depid);

            return View(Data);
        }
        //新增商品
        public ActionResult Create(int dId)
        {
            // 取得頁面所需資料，藉由Service 取得
            List<Department> depList = new List<Department>();
            ViewBag.depList = DepEmpService.GetDepList();
            ViewBag.dId = dId;
            // 將分類資料傳入View 中
            return View();
        }
        // 新增商品傳入資料時的Action
        [HttpPost] // 設定此Action 只接受頁面POST 資料傳入
        // 使用Bind 的 Include 來定義只接受的欄位，用來避免傳入其他不相干的值
        public ActionResult Create([Bind(Include = "EmpId, EmpName, EmpPhone, DepId, upload")] Employee Data)
        {
            if (Data.upload != null)
            {
                string img = Path.Combine(Server.MapPath("~/Images/"), Data.upload.FileName);
                Data.upload.SaveAs(img);
                Data.Img = Data.upload.FileName;
                DepEmpService.InsertEmp(Data);
            }
            else
            {
                ModelState.AddModelError("upload", "upload images");
                ViewBag.depList = DepEmpService.GetDepList();
                return View(Data);
            }
            return RedirectToAction("Index", new { depid = Data.DepId }); // 重新導向頁面至開始頁面
        }

        public ActionResult Edit(string eId)
        {
            // 取得頁面所需資料，藉由Service 取得
            Employee Data = DepEmpService.GetEmpById(eId);
            // 將資料傳入View 中
            if (Data == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Data);
            }
            // 修改商品資料傳入資料時的Action

        }
        [HttpPost] // 設定此Action 只接受頁面POST 資料傳入

        // 使用Bind 的Inculde 來定義只接受的欄位，用來避免傳入其他不相干值
        public ActionResult Edit(string eId, [Bind(Include = "empId,EmpName,EmpPhone,DepId")] Employee UpdateData)
        {
            // 將編號設定至修改資料中
            UpdateData.EmpId = eId;
            // 使用Service 來修改資料
            DepEmpService.UpdateEmp(UpdateData);

            // 重新導向頁面至開始頁面
            return RedirectToAction("Index", new { depid = UpdateData.DepId });
        }

        // 刪除頁面要根據傳入編號來刪除資料
        public ActionResult Delete(string eId, int dId)
        {
            // 使用Service 來刪除資料
            DepEmpService.DeleteEmp(eId.Trim());
            // 重新導向頁面至開始頁面
            return RedirectToAction("Index", new { depid = dId });
        }
    }
}