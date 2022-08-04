using AdoPractica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AdoPractica.Datos
{
    public class Productos : Conexion
        
    {
        /// <summary>
        /// metodo que trae todos los productos
        /// </summary>
        /// <returns></returns>
        
        public IEnumerable<ProductoModel> GetAll()
        {     
            Conect();
            List<ProductoModel> list = new List<ProductoModel>();

            try
            {
                SqlCommand Cmd = new SqlCommand("[dbo].[ProcedureGetAll]", cnn);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductoModel model = new ProductoModel()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Nombre= reader[1]+"",
                        Descripcion= reader[2]+"",
                        Cantidad = int.Parse(reader[3].ToString())
                    };

                    list.Add(model);
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            finally
            {
                disconnect();
            }

            return list;

        }

        /// <summary>
        /// Guarda Un Nuevo Producto
        /// </summary>
        /// <param name="model"></param>
        public void  NewProduct(ProductoModel model)
        {
            Conect();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ProcedureNew]", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("@cantidad", model.Cantidad);
                cmd.ExecuteNonQuery();

                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            finally
            {

                disconnect();
            }     

        } 


        /// <summary>
        /// Buscar producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductoModel GetId(int id)
        {
            Conect();
            ProductoModel model = new ProductoModel();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ProcedureGetId]", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    ProductoModel prod = new ProductoModel
                    {
                        Id = int.Parse(read[0].ToString()),
                        Nombre = read[1] + "",
                        Descripcion = read [2] +"",
                        Cantidad = int.Parse(read[3].ToString())
                    };

                    
                    model = prod;
                }
               
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return model;
        }


        /// <summary>
        /// Edita un producto
        /// </summary>
        /// <param name="model"></param>
        public void Edit(ProductoModel model)
        {
            Conect();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ProcedureModify]", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("@cantidad", model.Cantidad);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            finally
            {
                disconnect();
            }

        } 




        public void Delete(ProductoModel model)
        {
            Conect();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ProcedureDelete]", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.ExecuteReader();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            finally
            {

                disconnect();
            }
            
           

        }


        /// <summary>
        /// Busca producto por id + sell
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SellModel Sell(int id)
        {
            Conect();
            SellModel model = new SellModel();

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ProcedureGetId]", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    SellModel prod = new SellModel
                    {
                        Id = int.Parse(read[0].ToString()),
                        Nombre = read[1] + "",
                        Descripcion = read[2] + "",
                        Cantidad = int.Parse(read[3].ToString())
                    };


                    model = prod;
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return model;
        }



        /// <summary>
        /// Vende la cantidad de productos
        /// </summary>
        /// <param name="model"></param>
        public void Sell(SellModel model)
        {
            Conect();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Productos SET Cantidad=(@cantidad - @sell) where Id=@id", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@cantidad", model.Cantidad);
                cmd.Parameters.AddWithValue("@sell", model.Ventas);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            finally
            {
                disconnect();
            }

        }



    }

}







