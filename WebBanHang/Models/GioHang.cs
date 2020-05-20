using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class GioHang
    {
        public string iId { get; set; }
        public string iName { get; set; }
        public string iImage { get; set; }
        public int? iSoLuong { get; set; }
        public int? iPrice { get; set; }

        public string iTotalPrice => (this.iSoLuong * this.iPrice ?? 0).ToString("C");
    }
}