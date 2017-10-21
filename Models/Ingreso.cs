using System;

namespace ema.Models
{
    public class Ingreso 
    {
        private int ingresoId;
        public int IngresoId
        {
            get { return ingresoId;}
            set { ingresoId = value;}
        }
        
        private string tipoIngreso;
        public string TipoIngreso
        {
            get { return tipoIngreso;}
            set { tipoIngreso = value;}
        }
        
        private string descripcion;
        public string Descripcion
        {
            get { return descripcion;}
            set { descripcion = value;}
        }
        
        private DateTime fechaIngreso;
        public DateTime FechaIngreso
        {
            get { return fechaIngreso;}
            set { fechaIngreso = value;}
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