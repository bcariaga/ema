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

        public float Importe { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimento TipoMovimento { get; set; }

        public Estado Estado { get; set; }

        public Regularidad Regularidad { get; set; }

    }
}
