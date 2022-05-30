using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class PilotoR : PilotoI
    {
        private MySQLConfiguration _connectionString;
        public PilotoR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Piloto>> GetInfoPiloto(long id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, Nombre, Precio
                        FROM PILOTO
                        WHERE id = @id";
            return await db.QueryAsync<Piloto>(sql, new { id = id });
        }

        public async Task<bool> InsertPiloto(Piloto piloto)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO JUGADOR (id, Nombre, Precio)
                        VALUES (@id, @Nombre, @Precio)";
            var result = await db.ExecuteAsync(sql, new { piloto.id, piloto.Nombre, piloto.Precio });

            return result > 0;
        }

        public async Task<bool> UpdateInfoPiloto(Piloto piloto)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE PILOTO 
                        SET Nombre = @Nombre, Precio = @Precio  
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { piloto.id, piloto.Nombre, piloto.Precio });

            return result > 0;
        }

        public async Task<bool> DeletePiloto(Piloto piloto)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM PILOTO
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id = piloto.id });

            return result > 0;
        }
    }
}
