﻿using Microsoft.Practices.EnterpriseLibrary.Data;
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
    public partial class MedicoDAC : DataAccessComponent, IRepository<Medico>
    {
        public Medico Create(Medico medico)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Medico ([TipoMatricula],[NumeroMatricula],[Apellido],[Nombre],[Especialidad],[FechaNacimiento],[Email],[Telefono]) VALUES (@TipoMatricula, @NumeroMatricula, @Apellido, @Nombre, @Especialidad, @FechaNacimiento, @Email, @Telefono); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula.ToString());
                    db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, medico.NumeroMatricula);
                    db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                    db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, medico.FechaNacimiento);
                    db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                    db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);
                    medico.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return medico;
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
                const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
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

        public List<Medico> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id],[TipoMatricula],[NumeroMatricula],[Apellido],[Nombre],[Especialidad],[FechaNacimiento],[Email],[Telefono] FROM Medico";

            List<Medico> result = new List<Medico>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Medico medico = LoadMedico(dr);
                        result.Add(medico);
                    }
                }
            }
            return result;
        }

        public Medico ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id],[TipoMatricula],[NumeroMatricula],[Apellido],[Nombre],[Especialidad],[FechaNacimiento],[Email],[Telefono] FROM Medico WHERE [Id]=@Id";
            Medico medico = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        medico = LoadMedico(dr);
                    }
                }
            }
            return medico;
        }

        public void Update(Medico medico)
        {
            try
            {
                const string SQL_STATEMENT = "UPDATE Medico SET [TipoMatricula]=@TipoMatricula,[NumeroMatricula]=@NumeroMatricula,[Apellido]=@Apellido,[Nombre]=@Nombre,[Especialidad]=@Especialidad,[FechaNacimiento]=@FechaNacimiento,[Email]=@Email,[Telefono]=@Telefono WHERE [Id]=@Id";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, medico.TipoMatricula.ToString());
                    db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, medico.NumeroMatricula);
                    db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, medico.Apellido);
                    db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, medico.Nombre);
                    db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, medico.Especialidad);
                    db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, medico.FechaNacimiento);
                    db.AddInParameter(cmd, "@Email", DbType.AnsiString, medico.Email);
                    db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, medico.Telefono);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, medico.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Medico LoadMedico(IDataReader dr)
        {
            Medico medico = new Medico();
            medico.Id = GetDataValue<int>(dr, "Id");
            medico.TipoMatricula = GetEnumValue<TipoMatricula>(dr, "TipoMatricula");
            medico.NumeroMatricula = GetDataValue<int>(dr, "NumeroMatricula");
            medico.Apellido = GetDataValue<string>(dr, "Apellido");
            medico.Nombre = GetDataValue<string>(dr, "Nombre");
            medico.Especialidad = GetDataValue<string>(dr, "Especialidad");
            medico.FechaNacimiento = GetDateTimeValue(dr, "FechaNacimiento");
            medico.Email = GetDataValue<string>(dr, "Email");
            medico.Telefono = GetDataValue<string>(dr, "Telefono");
            return medico;
        }
    }
}
