using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVdinámico
{
    class claseConectarBD
    {
        MySqlConnection conexion = new MySqlConnection();
        MySqlCommand comando;
        MySqlDataReader resultado;

        public claseConectarBD() { }

        public void conectarBD() {
            conexion.ConnectionString = "server=db4free.net;Database=dam2020;Uid=camachin2020;pwd=pruden2020;old guids=true";
            conexion.Open();
            conexion.Close();
        }

        public List<claseFruta> ListarFrutas()
        {
            String cadenaSql = "select * from frutas";
            conexion.Open();
            comando = new MySqlCommand(cadenaSql, conexion);
            resultado = comando.ExecuteReader();
            List<claseFruta> frutas = new List<claseFruta>();
            while (resultado.Read())
            {
                claseFruta fruta = new claseFruta();
                fruta.Id = Convert.ToInt32(resultado[0]);
                fruta.Nombre = Convert.ToString(resultado[1]);                
                fruta.Precio = Convert.ToDecimal(resultado[2]);
                fruta.Imagen = (byte[])resultado[3];
                fruta.Procedencia = Convert.ToString(resultado[4]);
                fruta.Stock = Convert.ToInt32(resultado[5]);                
                frutas.Add(fruta);
            }
            conexion.Close();
            return frutas;
        }


    }
}
