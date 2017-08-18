namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Divisions = new HashSet<Division>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExportDate { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int? TableID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Division> Divisions { get; set; }

        public virtual Table Table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
