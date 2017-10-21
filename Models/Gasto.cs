using System;

namespace ema.Models
{
    public class Gasto 
    { 
        private int gastoId;
        public int GastoId
        {
            get { return gastoId;}
            set { gastoId = value;}
        }
        
        private string tipoGasto;
        public string TipoGasto
        {
            get { return tipoGasto;}
            set { tipoGasto = value;}
        }
        
        private string descripcion;
        public string Descripcion
        {
            get { return descripcion;}
            set { descripcion = value;}
        }
        
        private DateTime fechaGasto;
        public DateTime FechaGasto
        {
            get { return fechaGasto;}
            set { fechaGasto = value;}
        }
        
        private float importe;
        public float Importe
        {
            get { return importe;}
            set { importe = value;}
        }
        
        private int recursivo;
        public int Recursivo
        {
            get { return recursivo;}
            set { recursivo = value;}
        }
    }
}
        