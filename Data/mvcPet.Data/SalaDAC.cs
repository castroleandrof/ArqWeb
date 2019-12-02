using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using mvcPet.Entities;

namespace mvcPet.Data
{
    public partial class SalaDAC : DataAccessComponent, IRepository<Sala>
    {
        public Sala Create(Sala sala)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Sala ([Nombre],[TipoSala]) VALUES(@Nombre, @TipoSala); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                    db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala.ToString());
                    sala.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return sala;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Sala> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala ";

            List<Sala> result = new List<Sala>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Sala sala = LoadSala(dr);
                        result.Add(sala);
                    }
                }
            }
            return result;
        }

        public Sala ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala WHERE [Id]=@Id ";
            Sala sala = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        sala = LoadSala(dr);
                    }
                }
            }
            return sala;
        }

        public void Update(Sala sala)
        {
            try
            {
                const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]=@Nombre, [TipoSala]=@TipoSala WHERE [Id]= @Id ";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, sala.Nombre);
                    db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, sala.TipoSala);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, sala.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private Sala LoadSala(IDataReader dr)
        {
            Sala sala = new Sala();
            sala.Id = GetDataValue<int>(dr, "Id");
            sala.Nombre = GetDataValue<string>(dr, "Nombre");
            sala.TipoSala = GetEnumValue<TipoSala>(dr, "TipoSala");
            return sala;
        }
    }
}
