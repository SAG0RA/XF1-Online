using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class EscuderiaR : EscuderiaI
    {
        private MySQLConfiguration _connectionString;
        public EscuderiaR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Escuderia>> GetInfoEscuderia(String nombre)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT Nombre, Precio
                        FROM ESCUDERIA
                        WHERE Nombre = @nombre";
            return await db.QueryAsync<Escuderia>(sql, new { Nombre = nombre });
        }

        public async Task<bool> InsertEscuderia(Escuderia escuderia)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO ESCUDERIA (Nombre, Precio)
                        VALUES (@Nombre, @Precio)";
            var result = await db.ExecuteAsync(sql, new { escuderia.Nombre, escuderia.Precio });

            return result > 0;
        }

        public async Task<bool> UpdateInfoEscuderia(Escuderia escuderia)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE ESCUDERIA 
                        SET Nombre = @Nombre, Precio = @Precio 
                        WHERE Nombre = @Nombre";
            var result = await db.ExecuteAsync(sql, new { escuderia.Nombre, escuderia.Precio });

            return result > 0;
        }

        public async Task<bool> DeleteEscuderia(Escuderia escuderia)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM ESCUDERIA
                        WHERE Nombre = @nombre";
            var result = await db.ExecuteAsync(sql, new { Nombre_usuario = escuderia.Nombre });

            return result > 0;
        }
    }
}

