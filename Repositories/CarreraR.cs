using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class CarreraR : CarreraI
    {

        private MySQLConfiguration _connectionString;
        public CarreraR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Carrera>> GetInfoCarrera(long id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, Nombre, Nombre_pista, Pais, Fecha_inicio, Fecha_fin, Estado, Id_Campeonato
                        FROM CARRERA
                        WHERE id = @id";
            return await db.QueryAsync<Carrera>(sql, new { id = id });
        }

        public async Task<bool> InsertCarrera(Carrera carrera)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO CARRERA (id, Nombre, Nombre_pista, Pais, Fecha_inicio, Fecha_fin, Estado, Id_Campeonato)
                        VALUES (@id, @Nombre, @Nombre_pista, @Pais, @Fecha_inicio, @Fecha_fin, @Estado. @Id_Campeonato)";
            var result = await db.ExecuteAsync(sql, new { carrera.id, carrera.Nombre, carrera.Nombre_pista, carrera.Pais, carrera.Fecha_inicio, carrera.Fecha_fin, carrera.Estado, carrera.Id_Campeonato });

            return result > 0;
        }

        public async Task<bool> UpdateInfoCarrera(Carrera carrera)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE CARRERA 
                        SET Nombre = @Nombre, Nombre_pista = @Nombre_pista, Pais = @Pais, Fecha_inicio = @Fecha_inicio, Fecha_fin = @Fecha_fin, Estado = @Estado, Id_Campeonato = @Id_Campeonato
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { carrera.id, carrera.Nombre, carrera.Nombre_pista, carrera.Pais, carrera.Fecha_inicio, carrera.Fecha_fin, carrera.Estado, carrera.Id_Campeonato });

            return result > 0;
        }

        public async Task<bool> DeleteCarrera(Carrera carrera)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM CARRERA
                        WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { id = carrera.id });

            return result > 0;
        }
    }
}
