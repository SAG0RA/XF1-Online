using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class EquipoR : EquipoI
    {
        private MySQLConfiguration _connectionString;
        public EquipoR (MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Equipo>> GetInfoEquipo(long id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, Jugador_nombre_usuario, Escuderia_nombre
                        FROM EQUIPO
                        WHERE id = @id";
            return await db.QueryAsync<Equipo>(sql, new { id = id });
        }

        public async Task<bool> InsertEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO EQUIPO (id, Jugador_nombre_usuario, Escuderia_nombre)
                        VALUES (@id, @Jugador_nombre_usuario, @Escuderia_nombre)";
            var result = await db.ExecuteAsync(sql, new { equipo.id, equipo.Jugador_nombre_usuario, equipo.Escuderia_nombre });

            return result > 0;
        }

        public async Task<bool> UpdateInfoEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE EQUIPO 
                        SET Jugador_nombre_usuario = @Jugador_nombre_usuario, Escuderia_nombre = @Escuderia_nombre 
                        WHERE @id = id";
            var result = await db.ExecuteAsync(sql, new { equipo.Jugador_nombre_usuario, equipo.Escuderia_nombre });

            return result > 0;
        }

        public async Task<bool> DeleteEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM EQUIPO
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id = equipo.id });

            return result > 0;
        }
    }
}
