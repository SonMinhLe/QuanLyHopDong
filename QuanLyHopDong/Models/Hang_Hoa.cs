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

    public partial class Hang_Hoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hang_Hoa()
        {
            this.Hop_Dong = new HashSet<Hop_Dong>();
            this.Nghiem_Thu = new HashSet<Nghiem_Thu>();
        }
    
        public int ID_Hang_Hoa { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string Ten_Hang_Hoa { get; set; }
        [Display(Name = "Loại hợp đồng")]
        public Nullable<int> ID_Loai_Hang_Hoa { get; set; }
        [Display(Name = "Đơn vị tính")]
        public string Don_Vi_Tinh { get; set; }
        [Display(Name = "Hãng sản xuất")]
        public string Hang_San_Xuat { get; set; }
    
        public virtual Loai_Hang Loai_Hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hop_Dong> Hop_Dong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nghiem_Thu> Nghiem_Thu { get; set; }
    }
}
