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
    public partial class MovimientoDAC : DataAccessComponent, IRepository<Movimiento>
    {
        public Movimiento Create(Movimiento movimiento)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Movimiento ([Fecha],[ClienteId],[TipoMovimientoId],[Valor]) VALUES(@Fecha,@ClienteId,@TipoMovimientoId,@Valor); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, movimiento.Fecha);
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, movimiento.ClienteId);
                    db.AddInParameter(cmd, "@TipoMovimientoId", DbType.Int32, movimiento.TipoMovimientoId);
                    db.AddInParameter(cmd, "@Valor", DbType.Decimal, movimiento.Valor);
                    movimiento.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return movimiento;
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
                const string SQL_STATEMENT = "DELETE Movimiento WHERE [Id]= @Id ";
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

        public List<Movimiento> ReadByClienteId(int clienteId)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[ClienteId],[TipoMovimientoId],[Valor] FROM Movimiento WHERE [ClienteId]=@ClienteId ";
                List<Movimiento> result = new List<Movimiento>();

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, clienteId);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Movimiento movimiento = LoadMovimiento(dr);
                            result.Add(movimiento);
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

        public List<Movimiento> Read()
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[ClienteId],[TipoMovimientoId],[Valor] FROM Movimiento";

                List<Movimiento> result = new List<Movimiento>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Movimiento movimiento = LoadMovimiento(dr);
                            result.Add(movimiento);
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

        public Movimiento ReadBy(int id)
        {
            try
            {
                const string SQL_STATEMENT = "SELECT [Id],[Fecha],[ClienteId],[TipoMovimientoId],[Valor] FROM Movimiento WHERE [Id]=@Id ";
                Movimiento movimiento = null;

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            movimiento = LoadMovimiento(dr);
                        }
                    }
                }
                return movimiento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Movimiento movimiento)
        {
            try
            {
                const string SQL_STATEMENT = "UPDATE Movimiento SET [Fecha]=@Fecha,[ClienteId]=@ClienteId,[TipoMovimientoId]=@TipoMovimientoId,[Valor]=@Valor WHERE [Id]= @Id ";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, movimiento.Fecha);
                    db.AddInParameter(cmd, "@ClienteId", DbType.Int32, movimiento.ClienteId);
                    db.AddInParameter(cmd, "@TipoMovimientoId", DbType.Int32, movimiento.TipoMovimientoId);
                    db.AddInParameter(cmd, "@Valor", DbType.Decimal, movimiento.Valor);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, movimiento.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Movimiento LoadMovimiento(IDataReader dr)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.Id = GetDataValue<int>(dr, "Id");
            movimiento.Fecha = GetDateTimeValue(dr, "Fecha");
            movimiento.ClienteId = GetDataValue<int>(dr, "ClienteId");
            movimiento.TipoMovimientoId = GetDataValue<int>(dr, "TipoMovimientoId");
            movimiento.Valor = GetDataValue<decimal>(dr, "Valor");
            return movimiento;
        }
    }
}
