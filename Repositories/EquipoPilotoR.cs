using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class EquipoPilotoR : EquipoPilotoI
    {
        private MySQLConfiguration _connectionString;
        public EquipoPilotoR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Equipo_Piloto>> GetInfoEquipo_Piloto(long equipo_id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT Equipo_id, Piloto_id
                        FROM EQUIPO_PILOTO
                        WHERE Equipo_id = @equipo_id";
            return await db.QueryAsync<Equipo_Piloto>(sql, new { equipo_id = equipo_id });
        }

        public async Task<bool> InsertEquipo_Piloto(Equipo_Piloto equipo_piloto)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO EQUIPO_PILOTO (Equipo_id, Piloto_id)
                        VALUES (@Equipo_id, @Piloto_id)";
            var result = await db.ExecuteAsync(sql, new { equipo_piloto.Equipo_id, equipo_piloto.Piloto_id });

            return result > 0;
        }

        public async Task<bool> UpdateInfoEquipo_Piloto(Equipo_Piloto equipo_piloto)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE EQUIPO_PILOTO 
                        SET Equipo_id = @Equipo_id, Piloto_id = @Piloto_id 
                        WHERE Equipo_id = @Equipo_id";
            var result = await db.ExecuteAsync(sql, new { equipo_piloto.Equipo_id, equipo_piloto.Piloto_id });

            return result > 0;
        }

        public async Task<bool> DeleteEquipo_Piloto(Equipo_Piloto equipo_piloto)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM EQUIPO_PILOTO
                        WHERE Equipo_id = @Equipo_id";
            var result = await db.ExecuteAsync(sql, new { Equipo_id = equipo_piloto.Equipo_id });

            return result > 0;
        }
    }
}
