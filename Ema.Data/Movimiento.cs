using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ema.Data
{
    [Table("Movimiento")]
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Importe")]
        [DataType(DataType.Currency)]
        public float Importe { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        public TipoMovimento TipoMovimento { get; set; }

        public Estado Estado { get; set; }

        public Regularidad Regularidad { get; set; }

    }
}
