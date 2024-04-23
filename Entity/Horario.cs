namespace Entity
{
    public class Horario
    {
        public Horario()
        {

        }


        private string _Nombre_Archivo;
        public string Nombre_Archivo
        {
            get { return _Nombre_Archivo; }
            set { _Nombre_Archivo = value; }
        }

        private string _salon;
        public string Salon
        {
            get { return _salon; }
            set { _salon = value; }
        }

        private string _Extension;
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        private string _Formato;
        public string Formato
        {
            get { return _Formato; }
            set { _Formato = value; }
        }


        private byte[] _Archivos;
        public byte[] Archivo
        {
            get { return _Archivos; }
            set { _Archivos = value; }
        }

        private double _Tamanio;
        public double Tamanio
        {
            get { return _Tamanio; }
            set { _Tamanio = value; }
        }
      
    }
}