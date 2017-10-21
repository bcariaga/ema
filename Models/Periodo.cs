using System;

namespace ema.Models
{
    public class Periodo 
    {
        private int periodoId;
        public int PeriodoId
        {
            get { return periodoId;}
            set { periodoId = value;}
        }
        
        private DateTime desde;
        public DateTime Desde
        {
            get { return desde;}
            set { desde = value;}
        }
        
        private DateTime hasta;
        public DateTime Hasta
        {
            get { return hasta;}
            set { hasta = value;}
        }
        
        private string descripcion;
        public string Descripcion
        {
            get { return descripcion;}
            set { descripcion = value;}
        }
        
    }
}