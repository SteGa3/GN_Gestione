using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Entities;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using DatalayerSQL;



namespace DataLayerSQL
{
    public class ClienteRetailDataLayer : DataLayerBase, IClienteRetailDatalayer
    {


        public void InserisciClienteRetail(Cliente_Retail cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {

              
                connection.Open();
                string commandText = "INSERT INTO Cliente_Retail (Nome, Nickname, ID_Cliente_Retail) VALUES (?Nome, ?Nickname, ?ID_Cliente_Retail) ;";
                using (MySqlCommand command = new MySqlCommand(commandText, connection))

                {
                    
                    command.Parameters.AddWithValue("?Nome", cliente.Cl_Ret_Name);
                    command.Parameters.AddWithValue("?Nickname", cliente.Cl_Ret_Nickname);
                    command.Parameters.AddWithValue("?ID_Cliente_Retail", cliente.Cl_Ret_Code);

                    command.ExecuteNonQuery();

                }

            }
        }
    }
}