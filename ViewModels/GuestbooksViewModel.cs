﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using final.Models;
using final.Serivces;

namespace final.ViewModels
{
    public class GuestbooksViewModel
    {

        // 搜尋欄位
        [DisplayName(" 搜尋：")]
        public string Search { get; set; }
        //顯示資料陣列
        public List<Guestbooks> DataList { get; set; }
    }
}