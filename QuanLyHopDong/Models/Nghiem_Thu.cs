//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyHopDong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Nghiem_Thu
    {
        public int ID_Ngiem_Thu { get; set; }
        [Display(Name = "Người nghiệm thu")]
        public Nullable<int> Nguoi_Nghiem_Thu { get; set; }
        [Display(Name = "Ngày nghiệm thu")]
        public Nullable<System.DateTime> Ngay_Nghiem_Thu { get; set; }
        [Display(Name = "Hàng hóa")]
        public Nullable<int> ID_Hang_Hoa { get; set; }
        [Display(Name = "Hợp đồng")]
        public Nullable<int> ID_Hop_dong { get; set; }
        [Display(Name = "Trạng thái")]
        public string Trang_Thai { get; set; }
        [Display(Name = "Hàng hóa")]
        public virtual Hang_Hoa Hang_Hoa { get; set; }
        [Display(Name = "Hợp đồng")]
        public virtual Hop_Dong Hop_Dong { get; set; }
        [Display(Name = "Người tạo hợp đồng")]
        public virtual Nguoi_Dung Nguoi_Dung { get; set; }
    }
}
