using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdoPractica.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;
        protected void Conect()
        {
            

            try
            {
                cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prsolucionesti1\source\repos\AdoPractica\App_Data\PracticaAdo.mdf;Integrated Security=True");
                cnn.Open();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);     
            }


        }


        protected void disconnect()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            

        }




    }
}