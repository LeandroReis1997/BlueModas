using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueModas.Web.Info.Entities
{
    public class SaleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int NumberOrder { get; set; }
    }
}
