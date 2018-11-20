using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class GrupoDao
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        static GrupoDao ()
        {
            try
            {
                string conexionStr = "Data Source = DESKTOP-PFDR43B; Inicial Catalog = mundial-sp-2018.bak; Integrated Security = True";
                GrupoDao.conexion = new SqlConnection(conexionStr);
                GrupoDao.comando = new SqlCommand();
                GrupoDao.comando.CommandType = CommandType.Text;
                GrupoDao.comando.Connection = GrupoDao.conexion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static SqlConnection Conexion
        {
            get
            {
                return GrupoDao.conexion;
            }

            set
            {
                GrupoDao.conexion = value;
            }
        }

        public static SqlCommand Comando
        {
            get
            {
                return GrupoDao.comando;
            }

            set
            {
                GrupoDao.comando = value; 
            }
        }

             

     
        
    }
}
