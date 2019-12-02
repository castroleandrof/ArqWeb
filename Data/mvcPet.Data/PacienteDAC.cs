using Microsoft.Practices.EnterpriseLibrary.Data;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Data
{
    public partial class PacienteDAC : DataAccessComponent, IRepository<Paciente>
    {
        public Paciente Create(Paciente paciente)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Paciente ([ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion]) VALUES (@ClienteId,@Nombre,@FechaNacimiento,@EspecieId,@Observacion); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, paciente.ClienteId);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, paciente.FechaNacimiento);
                    db.AddInParameter(cmd, "@EspecieId", DbType.Int32, paciente.EspecieId);
                    db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                    paciente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return paciente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                const string SQL_STATEMENT = "DELETE Paciente WHERE [Id]= @Id ";
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> ReadByClienteId(int clienteId)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion] FROM Paciente WHERE [ClienteId]=@ClienteId ";

                List<Paciente> result = new List<Paciente>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, clienteId);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Paciente paciente = LoadPaciente(dr);
                            result.Add(paciente);
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Read()
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion] FROM Paciente";

                List<Paciente> result = new List<Paciente>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Paciente paciente = LoadPaciente(dr);
                            result.Add(paciente);
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Paciente ReadBy(int id)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[ClienteId],[Nombre],[FechaNacimiento],[EspecieId],[Observacion] FROM Paciente WHERE [Id]=@Id ";
                Paciente paciente = null;

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            paciente = LoadPaciente(dr);
                        }
                    }
                }
                return paciente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Paciente paciente)
        {
            try
            {
                const string SQL_STATEMENT = "UPDATE Paciente SET [ClienteId]=@ClienteId,[Nombre]=@Nombre,[FechaNacimiento]=@FechaNacimiento,[EspecieId]=@EspecieId,[Observacion]=@Observacion WHERE [Id]=@Id";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, paciente.ClienteId);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, paciente.Nombre);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, paciente.FechaNacimiento);
                    db.AddInParameter(cmd, "@EspecieId", DbType.Int32, paciente.EspecieId);
                    db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, paciente.Observacion);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, paciente.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Paciente LoadPaciente(IDataReader dr)
        {
            Paciente paciente = new Paciente();
            paciente.Id = GetDataValue<int>(dr, "Id");
            paciente.ClienteId = GetDataValue<int>(dr, "ClienteId");
            paciente.Nombre = GetDataValue<string>(dr, "Nombre");
            paciente.FechaNacimiento = GetDateTimeValue(dr, "FechaNacimiento");
            paciente.EspecieId = GetDataValue<int>(dr, "EspecieId");
            paciente.Observacion = GetDataValue<string>(dr, "Observacion");
            return paciente;
        }
    }
}
