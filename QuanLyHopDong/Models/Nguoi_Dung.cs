﻿//------------------------------------------------------------------------------
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

    public partial class Nguoi_Dung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoi_Dung()
        {
            this.Nghiem_Thu = new HashSet<Nghiem_Thu>();
        }
    
        public int ID_Nguoi_Dung { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string Ten_Dang_Nhap { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Mat_Khau { get; set; }
        [Display(Name = "Họ tên")]
        public string Ho_Ten { get; set; }
        [Display(Name = "Ngày sinh")]
        public Nullable<System.DateTime> Ngay_Sinh { get; set; }
        public string Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nghiem_Thu> Nghiem_Thu { get; set; }
    }
}