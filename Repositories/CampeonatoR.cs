using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class CampeonatoR : CampeonatoI
    {
        private MySQLConfiguration _connectionString;
        public CampeonatoR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Campeonato>> GetInfoCampeonato(long id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, Nombre, Fecha_inicio, Fecha_fin, Descripcion_reglas
                        FROM CAMPEONATO
                        WHERE id = @id";
            return await db.QueryAsync<Campeonato>(sql, new { id = id });
        }

        public async Task<bool> InsertCampeonato(Campeonato campeonato)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO CAMPEONATO (id, Nombre, Fecha_inicio, Fecha_fin, Descripcion_reglas)
                        VALUES (@id, @Nombre, @Fecha_inicio, @Fecha_fin, @Descripcion_reglas)";
            var result = await db.ExecuteAsync(sql, new { campeonato.id, campeonato.Nombre, campeonato.Fecha_inicio, campeonato.Fecha_fin, campeonato.Descripcion_reglas });

            return result > 0;
        }

        public async Task<bool> UpdateInfoCampeonato(Campeonato campeonato)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE CAMPEONATO 
                        SET Nombre = @Nombre, Fecha_inicio = @Fecha_inicio, Fecha_fin = @Fecha_fin, Descripcion_reglas = @Descripcion_reglas 
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { campeonato.id, campeonato.Nombre, campeonato.Fecha_inicio, campeonato.Fecha_fin, campeonato.Descripcion_reglas });

            return result > 0;
        }

        public async Task<bool> DeleteCampeonato(Campeonato campeonato)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM CAMPEONATO
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id = campeonato.id });

            return result > 0;
        }
    }
}
