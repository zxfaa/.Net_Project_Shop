using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace final.Models
{
    public class Department
    {
        //編號
        [DisplayName("商品編號")]
        public int DepId { get; set; }
        //名稱
        [DisplayName("部門名稱")]
        [Required(ErrorMessage = "請輸入分類名稱與代號")]
        [StringLength(50, ErrorMessage = "名稱不可超過50 字元")]
        public string DepName { get; set; }
    }
}