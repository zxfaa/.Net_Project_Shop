using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace final.Models
{
    public class Employee
    {
        //編號
        [DisplayName("商品編號")]
        [Required(ErrorMessage = "請輸入商品編號")]
        [StringLength(10, ErrorMessage = "商品編號不可超過 10 字元")]
        public string EmpId { get; set; }
        //名字
        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        [StringLength(50, ErrorMessage = "名稱不可超過 50 字元")]
        public string EmpName { get; set; }
        //簡介
        [DisplayName("商品簡介")]
        [Required(ErrorMessage = "請輸商品簡介")]
        [StringLength(20, ErrorMessage = "商品簡介不可超過 50 字元")]
        public string EmpPhone { get; set; }
        //所屬分類
        [DisplayName("分類")]
        public int DepId { get; set; }

        public string Img { get; set; }
        [Required(ErrorMessage = "請選擇圖片檔案")]
        public HttpPostedFileBase upload { get; set; }
    }
}