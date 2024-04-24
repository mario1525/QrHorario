using Data;
using Entity;
using System.Data;
using System.Threading.Tasks;

namespace Buisnes
{
    public class HorarioControllogical
    {
        private readonly DAOHorario _daoHorario;

        public HorarioControllogical(DAOHorario daoHorario)
        {
            _daoHorario = daoHorario;

        }

        public async Task<Guid> guardarHorario(Horario horario)
        {
            
            return await  _daoHorario.UpdateDocument(horario);

        }

        public Horario mostrarDocumento(string id)
        {
            // Mapear DataTable a lista de archivos
            Task<DataTable> taskDataTable = _daoHorario.descarDocument(id);
            DataTable user = taskDataTable.Result;
            //Console.WriteLine(user.Rows.Count);
            Horario archivos = MapDataTableArchivoList(user);
            return archivos;
        }

        public string buscarHorario(string salon)
        {
            Task<DataTable> taskDataTable =  _daoHorario.GetSalon(salon);
            DataTable archivo = taskDataTable.Result;
            string id = archivo.ToString();

            return id;
        }

        public string eliminarHorario(string id) 
        {
            Task<DataTable> taskDataTable = _daoHorario.deleteHorario(id);
            DataTable elm = taskDataTable.Result;
            string data = elm.ToString();
            return data;
        }

        private static Horario MapDataTableArchivoList(DataTable dataTable)
        {
           Horario ArchivosList = new Horario();

            foreach (DataRow row in dataTable.Rows)
            {
                Horario archivo = new Horario
                {
                    Nombre_Archivo = row["Nombre_Archivo"].ToString(),
                    Extension = row["Extension"].ToString(),
                    Formato = row["Formato"].ToString(),
                    Archivo = ((byte[])row["Archivos"]).ToArray(),
                    Tamanio = Convert.ToDouble(row["Tamanio"]),
                    // Asigna otras propiedades según tu DataTable y clase Usuarios
                };
                ArchivosList= archivo;
            }
            return ArchivosList;
        }
    }
}