using System.Data;
using System.Data.SqlClient;
using Data.SQLClient;
using Entity;


namespace Data
{
    public class DAOHorario
    {
        #region declaracion de variables 


        //SQLClient ob_SQLClient = null;
        //ParametrosSesion ob_ParametrosSesion;

        #endregion

        #region Metodos 

        private readonly SQLclient _sqlClient;

        public DAOHorario(SQLclient dbContext)
        {
            _sqlClient = dbContext;
        }

        public async Task<Guid> UpdateDocument(Horario horario)
        {
            Guid uid = Guid.NewGuid();
            if (horario == null)
            {
                throw new ArgumentNullException(nameof(horario));
            }

            string procedureName = "dbo.db_sp_Horario_insert";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", uid),                
                new SqlParameter("@Nombre_Archivo", horario.Nombre_Archivo),
                new SqlParameter("@Salon", horario.Salon),
                new SqlParameter("@Extension", horario.Extension ),
                new SqlParameter("@Formato", horario.Formato),
                new SqlParameter("@Archivos", horario.Archivo),
                new SqlParameter("@Tamanio", horario.Tamanio),               
            };
            await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
            // _sqlClient.
            return uid;
        }

        public async Task<DataTable> descarDocument(string id)
        {
            string procedureName = "dbo.db_sp_Horario_select";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID", id),                
            };
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);

        }

        public async Task<DataTable> GetSalon(String Salon)
        {
            string procedureName = "dbo.db_sp_Horario_buscar";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Salon", Salon),
            };
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);

        }

        public async Task<DataTable> deleteHorario(String id)
        {
            string procedureName = "dbo.db_sp_Horario_Del";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id),
            };
            return await _sqlClient.ExecuteStoredProcedure(procedureName, parameters);
        }

        #endregion
    }
}