using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using mvcPet.Entities;

namespace mvcPet.Data
{
            public partial class PrecioDAC : DataAccessComponent, IRepository<Precio>
        {
            public Precio Create(Precio precio)
            {
                const string SQL_STATEMENT = "INSERT INTO Precio  ([fecha_desde]) VALUES(@fecha_desde), ([fecha_hasta]) VALUES(@fecha_hasta), ([valor) VALUES(@valor); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@fecha_desde", DbType.DateTime, precio.Fecha_desde);
                    db.AddInParameter(cmd, "@fecha_hasta", DbType.DateTime, precio.Fecha_hasta);
                    db.AddInParameter(cmd, "@valor", DbType.Decimal, precio.valor);
                    precio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }
                return precio;
            }

            public List<Precio> Read()
            {
                const string SQL_STATEMENT = "SELECT [Id] FROM Precio ";

                List<Precio> result = new List<Precio>();
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        while (dr.Read())
                        {
                            Precio precio = LoadPrecio(dr);
                            result.Add(precio);
                        }
                    }
                }
                return result;
            }

            public void Delete(Precio precio)
            {
                throw new NotImplementedException();
            }

            public Precio ReadBy(int id)
            {
                const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM Precio WHERE [Id]=@Id ";
                Precio precio = null;

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    using (IDataReader dr = db.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            precio = LoadPrecio(dr);
                        }
                    }
                }
                return precio;
            }

        public List<Precio> ReadByTipoServicioId(int tipoServicioId)
        {
            const string SQL_STATEMENT = "SELECT [Id],[TipoServicioId],[FechaDesde],[FechaHasta],[Valor] FROM Precio WHERE [TipoServicioId]=@TipoServicioId ";

            List<Precio> result = new List<Precio>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, tipoServicioId);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Precio precio = LoadPrecio(dr);
                        result.Add(precio);
                    }
                }
            }
            return result;
        }

        public void Update(Precio precio)
            {
                const string SQL_STATEMENT = "UPDATE Precio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                db.AddInParameter(cmd, "@fecha_desde", DbType.DateTime, precio.Fecha_desde);
                db.AddInParameter(cmd, "@fecha_hasta", DbType.DateTime, precio.Fecha_hasta);
                db.AddInParameter(cmd, "@valor", DbType.Decimal, precio.valor);
                db.AddInParameter(cmd, "@Id", DbType.Int32, precio.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }

            public void Delete(int id)
            {
                const string SQL_STATEMENT = "DELETE Precio WHERE [Id]= @Id ";
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    db.ExecuteNonQuery(cmd);
                }
            }

            private Precio LoadPrecio(IDataReader dr)
            {
                Precio precio = new Precio();
                precio.Id = GetDataValue<int>(dr, "Id");
                precio.Fecha_desde = GetDataValue<DateTime>(dr, "fecha_desde");
                precio.Fecha_hasta = GetDataValue<DateTime>(dr, "fecha_hasta");
                precio.valor = GetDataValue<Decimal>(dr, "valor");
                return precio;
            }
        }
}
