using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using mvcPet.Entities;

namespace mvcPet.Data
{
    public partial class TipoServicioDAC : DataAccessComponent, IRepository<TipoServicio>
    {
        public TipoServicio Create(TipoServicio tipo_servicio)
        {
            const string SQL_STATEMENT = "INSERT INTO Tipo_Servicio ([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipo_servicio.Nombre);
                tipo_servicio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return tipo_servicio;
        }
		
        public List<TipoServicio> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Tipo_Servicio ";

            List<TipoServicio> result = new List<TipoServicio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoServicio tipoServicio = LoadTipoServicio(dr);
                        result.Add(tipoServicio);
                    }
                }
            }
            return result;
        }

        public void Delete(TipoServicio tipoServicio)
        {
            throw new NotImplementedException();
        }

        public TipoServicio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Tipo_Servicio WHERE [Id]=@Id ";
            TipoServicio tipoServicio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        tipoServicio = LoadTipoServicio(dr);
                    }
                }
            }
            return tipoServicio;
        }
		
        public void Update(TipoServicio tipo_servicio)
        {
            const string SQL_STATEMENT = "UPDATE Tipo_Servicio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, tipo_servicio.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, tipo_servicio.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Tipo_Servicio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private TipoServicio LoadTipoServicio(IDataReader dr)
        {
            TipoServicio tipoServicio = new TipoServicio();
            tipoServicio.Id = GetDataValue<int>(dr, "Id");
            tipoServicio.Nombre = GetDataValue<string>(dr, "Nombre");
            return tipoServicio;
        }
    }
}
