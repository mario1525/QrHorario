using Buisnes;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    [ApiController]
    [Route("api/descargas")]
    public class DescargaController : ControllerBase
    {

        private readonly HorarioControllogical _doConLogical;

        public DescargaController(HorarioControllogical doConLogical)
        {
            _doConLogical = doConLogical;
        }


        [HttpPost]
        public mensajes UploadFile(IFormFile[] archivos)
        {
            if (archivos.Length == 0)
            {
                mensajes mensaje = new mensajes();
                mensaje.mensaje = "no se paso ningun archivo";
                return mensaje;
            }
            else
            {
                for (int i = 0; i < archivos.Length; i++)
                {
                    Horario horario = new Horario();

                    horario.Nombre_Archivo = Path.GetFileNameWithoutExtension(archivos[i].FileName);
                    horario.Extension = Path.GetExtension(archivos[i].FileName);
                    horario.Formato = archivos[i].ContentType;

                    long longitudArchivo = archivos[i].Length;

                    // Convierte el tamaño a megabytes
                    double tamanio = longitudArchivo / 1000000.0;
                    horario.Tamanio = Math.Round(tamanio, 2);
                    

                    // Lee el archivo en un array de bytes
                    using (MemoryStream ms = new MemoryStream())
                    {
                        archivos[i].CopyTo(ms);
                        horario.Archivo = ms.ToArray();
                    }



                    _doConLogical.guardarHorario(horario);
                }



                mensajes mensaje1 = new mensajes();
                mensaje1.mensaje = "archivo guardado";
                return mensaje1;
            }

        }




        [HttpGet("{id}")]
        public IActionResult DownloadImage(string id)
        {
            // Obtener los datos del horario desde la base de datos
            Horario horario = _doConLogical.mostrarDocumento(id);

            if (horario == null)
            {
                return NotFound(); // Devolver un 404 si no se encuentra el horario
            }

            // Devolver el archivo como un FileContentResult
            return File(horario.Archivo, "application/pdf", horario.Nombre_Archivo);
        }
    }
}
