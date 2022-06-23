using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TPSoft015
{
    public class Control_Alumnos : Connection
    {
        public List<Object> consulta(string filtro)
        {
            MySqlDataReader reader;
            List<Object> listProduc = new List<object>();
            string sql;

            if (filtro == null)
            {
                sql = "SELECT id, codigo, nombre, apa, ama, anotacion, nota1, nota2, nota3 FROM alumnos";
            }
            else
            {
                sql = "SELECT id, codigo, nombre, apa, ama, anotacion, nota1, nota2, nota3 FROM alumnos WHERE codigo LIKE '%" + filtro + "%'";
            }

            try
            {
                MySqlConnection cnBD = base.connection();
                cnBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnBD);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alumnos alumn = new Alumnos();
                    alumn.Id = int.Parse(reader.GetString("id"));
                    alumn.Codigo = reader.GetString("codigo");
                    alumn.Nombre = reader.GetString("nombre");
                    alumn.Apa = reader.GetString("apa");
                    alumn.Ama = reader.GetString("ama");
                    alumn.Anotacion = reader.GetString("anotacion");
                    alumn.Nota1 = int.Parse(reader.GetString("nota1"));
                    alumn.Nota2 = int.Parse(reader.GetString("nota2"));
                    alumn.Nota3 = int.Parse(reader.GetString("nota3"));
                    listProduc.Add(alumn);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return listProduc;
        }

        public bool insertar(Alumnos alumn)
        {
            bool sentinela = false;
            string sql = "INSERT INTO alumnos (codigo, nombre, apa, ama, anotacion, nota1, nota2, nota3) VALUES ('" + alumn.Codigo + "', '" + alumn.Nombre + "','" + alumn.Apa + "','" + alumn.Ama + "', '" + alumn.Anotacion + "', '" + alumn.Nota1 + "', '" + alumn.Nota2 + "', '" + alumn.Nota3 + "')";

            try
            {
                MySqlConnection cnBD = base.connection();
                cnBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnBD);
                cmd.ExecuteNonQuery();
                sentinela = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                sentinela = false;
            }
            return sentinela;
        }

        public bool actualizar(Alumnos alumn)
        {
            bool sentinela = false;
            string sql = "UPDATE alumnos SET codigo='" + alumn.Codigo + "', nombre='" + alumn.Nombre + "', apa='" + alumn.Apa + "', ama='" + alumn.Ama + "', anotacion='" + alumn.Anotacion + "', nota1='" + alumn.Nota1 + "', nota2='" + alumn.Nota2 + "', nota3='" + alumn.Nota3 + "' WHERE id='" + alumn.Id + "'";

            try
            {
                MySqlConnection cnBD = base.connection();
                cnBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnBD);
                cmd.ExecuteNonQuery();
                sentinela = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                sentinela = false;
            }
            return sentinela;
        }

        public bool eliminar(int id)
        {
            bool sentinela = false;
            string sql = "DELETE FROM alumnos WHERE id=" + id + "";

            try
            {
                MySqlConnection cnBD = base.connection();
                cnBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, cnBD);
                cmd.ExecuteNonQuery();
                sentinela = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                sentinela = false;
            }
            return sentinela;
        }
    }
}
