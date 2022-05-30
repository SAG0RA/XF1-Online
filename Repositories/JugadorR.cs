using Dapper;
using MySql.Data.MySqlClient;
using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public class JugadorR : JugadorI
    {
        private MySQLConfiguration _connectionString;
        public JugadorR(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Equipo>> GetInfoJugador(char nombre_usuario)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT Nombre_usuario, Nombre, Apellido, Correo, Rango_edad, Pais, Contrasenia
                        FROM JUGADOR
                        WHERE Nombre_usuario = @nombre_usuario";
            return await db.QueryAsync<Equipo>(sql, new { Nombre_usuario = nombre_usuario });
        }

        public async Task<bool> InsertJugador(Jugador jugador)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO JUGADOR (Nombre_usuario, Nombre, Apellido, Correo, Rango_edad, Pais, Contrasenia)
                        VALUES (@Nombre_usuario, @Nombre, @Apellido, @Correo, @Rango_edad, @Pais, @Contrasenia)";
            var result = await db.ExecuteAsync(sql, new { jugador.Nombre_usuario, jugador.Nombre, jugador.Apellido, jugador.Correo, jugador.Rango_edad, jugador.Pais, jugador.Contrasenia });

            return result > 0;
        }

        public async Task<bool> UpdateInfoJugador(Jugador jugador)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE JUGADOR 
                        SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Rango_edad = @Rango_edad, Pais = @Pais, Contrasenia = @Contrasenia 
                        WHERE Nombre_usuario = @Nombre_usuario";
            var result = await db.ExecuteAsync(sql, new { jugador.Nombre_usuario, jugador.Nombre, jugador.Apellido, jugador.Correo, jugador.Rango_edad, jugador.Pais, jugador.Contrasenia });

            return result > 0;
        }

        public async Task<bool> DeleteJugador(Jugador jugador)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM JUGADOR
                        WHERE Nombre_usuario = @nombre_usuario";
            var result = await db.ExecuteAsync(sql, new { Nombre_usuario = jugador.Nombre_usuario });

            return result > 0;
        }
    }
}
