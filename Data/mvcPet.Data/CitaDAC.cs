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
    public partial class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita cita)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Cita ([Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate],[ChangedBy],[ChangedDate],[DeletedBy],[DeletedDate],[Deleted]) VALUES (@Fecha,@MedicoId,@PacienteId,@SalaId,@TipoServicioId,@Estado,@CreatedBy,@CreatedDate,@ChangedBy,@ChangedDate,@DeletedBy,@DeletedDate,@Deleted); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                    db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                    db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                    db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                    db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                    db.AddInParameter(cmd, "@Estado", DbType.AnsiString, cita.Estado);
                    db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, cita.CreatedBy);
                    db.AddInParameter(cmd, "@CreatedDate", DbType.DateTime, cita.CreatedDate);
                    db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, cita.ChangedBy);
                    db.AddInParameter(cmd, "@ChangedDate", DbType.DateTime, cita.ChangedDate);
                    db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, cita.DeletedBy);
                    db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, cita.DeletedDate);
                    db.AddInParameter(cmd, "@Deleted", DbType.Boolean, cita.Deleted);
                    cita.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return cita;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteCita(Cita cita)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate],[ChangedBy],[ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM Cita WHERE [Fecha]=@Fecha AND [MedicoId]=@MedicoId AND [SalaId]=@SalaId ";
                Cita result = null;

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                    db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                    db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            result = LoadCita(dr);
                        }
                    }
                }
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cita> ReadByPacienteId(int pacienteId)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate],[ChangedBy],[ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM Cita WHERE [PacienteId]=@PacienteId ";

                List<Cita> result = new List<Cita>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@PacienteId", DbType.Int32, pacienteId);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Cita cita = LoadCita(dr);
                            result.Add(cita);
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

        public void Delete(int id)
        {
            try
            {
                const string SQL_STATEMENT = "DELETE Cita WHERE [Id]= @Id ";
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

        public List<Cita> Read()
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate],[ChangedBy],[ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM dbo.Cita";

                List<Cita> result = new List<Cita>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Cita cita = LoadCita(dr);
                            result.Add(cita);
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

        public Cita ReadBy(int id)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[MedicoId],[PacienteId],[SalaId],[TipoServicioId],[Estado],[CreatedBy],[CreatedDate],[ChangedBy],[ChangedDate],[DeletedBy],[DeletedDate],[Deleted] FROM Cita WHERE [Id]=@Id ";
                Cita cita = null;

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            cita = LoadCita(dr);
                        }
                    }
                }
                return cita;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Cita cita)
        {
            try
            {
                const string SQL_STATEMENT = "UPDATE Cita SET [Fecha]=@Fecha, [MedicoId]=@MedicoId, [PacienteId]=@PacienteId, [SalaId]=@SalaId, [TipoServicioId]=@TipoServicioId, [Estado]=@Estado, [CreatedBy]=@CreatedBy, [CreatedDate]=@CreatedDate, [ChangedBy]=@ChangedBy, [ChangedDate]=@ChangedDate, [DeletedBy]=@DeletedBy, [DeletedDate]=@DeletedDate, [Deleted]=@Deleted WHERE [Id]=@Id";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                    db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                    db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                    db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                    db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                    db.AddInParameter(cmd, "@Estado", DbType.AnsiString, cita.Estado);
                    db.AddInParameter(cmd, "@CreatedBy", DbType.AnsiString, cita.CreatedBy);
                    db.AddInParameter(cmd, "@CreatedDate", DbType.DateTime, cita.CreatedDate);
                    db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, cita.ChangedBy);
                    db.AddInParameter(cmd, "@ChangedDate", DbType.DateTime, cita.ChangedDate);
                    db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, cita.DeletedBy);
                    db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, cita.DeletedDate);
                    db.AddInParameter(cmd, "@Deleted", DbType.Boolean, cita.Deleted);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, cita.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Cita LoadCita(IDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = GetDataValue<int>(dr, "Id");
            cita.Fecha = GetDateTimeValue(dr, "Fecha");
            cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            cita.SalaId = GetDataValue<int>(dr, "SalaId");
            cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            cita.Estado = GetDataValue<string>(dr, "Estado");
            cita.CreatedBy = GetDataValue<string>(dr, "CreatedBy");
            cita.CreatedDate = GetDateTimeValue(dr, "CreatedDate");
            cita.ChangedBy = GetDataValue<string>(dr, "ChangedBy");
            cita.ChangedDate = GetDateTimeValue(dr, "ChangedDate");
            cita.DeletedBy = GetDataValue<string>(dr, "DeletedBy");
            cita.DeletedDate = GetDateTimeValue(dr, "DeletedDate");
            cita.Deleted = GetDataValue<bool>(dr, "Deleted");
            return cita;
        }

    }
}
