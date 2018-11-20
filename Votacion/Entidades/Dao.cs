using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Entidades
{
    public class Dao : IArchivos<Votacion>
    {
        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            bool todoOk = false;
            String connectionStr = "Data Source=DESKTOP-PFDR43B;Initial Catalog=votacion-sp-2018.bak;Integrated Security=True";
            SqlConnection conexion = null;
            SqlCommand comando; 

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;

                string consulta = String.Format("INSERT INTO Votaciones (nombreLey, afirmativos, negativos, abstenciones) VALUES ('{0}', {1}, {2}, {3})", objeto.NombreLey, objeto.ContadorAfirmativo, objeto.ContadorNegativo, objeto.ContadorAbstencion);
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                todoOk = true; 

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return todoOk;
        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
