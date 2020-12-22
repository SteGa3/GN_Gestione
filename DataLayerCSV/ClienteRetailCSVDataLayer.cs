    using System;
    using Entities;
    using DatalayerCSV;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Reflection;
    using System.Security;
    using System.Linq;


    [assembly: SecurityRules(SecurityRuleSet.Level2)]

    namespace DataLayerCSV

    {
        public class ClienteRetailCSVDataLayer : DatalayerCSVBase, IClienteRetailCSVDatalayer
        {
            public List<Cliente_Retail> GetAllRetail()
            {

                List<Cliente_Retail> All = new List<Cliente_Retail>();

                //Read resource's csv file
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ListaClienti.csv";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                

           
                using (StreamReader reader = new StreamReader(stream))
                {
                    bool first = false;
            
                    while (!reader.EndOfStream)
                    {
                        if (first) {

                            //Read lines of the stream
                            string line = reader.ReadLine();
                            string[] values = line.Split(";");
                
                    
                            Cliente_Retail SingleRetail = new Cliente_Retail();

                            SingleRetail.Cl_Ret_CODE = Convert.ToInt32(values[0]);
                            SingleRetail.Cl_Ret_Name = values[1];
                            SingleRetail.Cl_Ret_Nickname = values[2];

                            if (values[3] == "") {SingleRetail.Cl_Ret_Tot = 0;}
                            else { SingleRetail.Cl_Ret_Tot = Int32.Parse(values[3]); }

                            if (values[4] == "") { SingleRetail.Cl_Ret_Act = 0; }
                            else { SingleRetail.Cl_Ret_Act = Convert.ToInt32(values[4]); }

                            SingleRetail.Cl_Ret_Comment = values[5];

                            All.Add(SingleRetail);
                    }
                        else {
                            string values = reader.ReadLine();
                            /*All.Add(new Cliente_Retail {
                              Cl_Ret_Name = "Nome"  }); */

                            first = true;
                          }
                      }
                    }
                    return All;
            }
           
        

            public List<string> GetAllHeaders()
            {
                List<string> headers = new List<string>();

                //Read resource's csv file
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ListaClienti.csv";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))

                using (StreamReader reader = new StreamReader(stream))
                {
                      //Read lines of the stream
                      string line = reader.ReadLine();
                      string[] values = line.Split(";");
                      var headersNumber = values.Count();
                        


                      Cliente_Retail SingleRetail = new Cliente_Retail();
                      for (int i = 0; i == headersNumber; i++ )
                      {

                          headers[i] = values[i];
                        
                      }
                    return headers;
                }
           

            }

            public void InsRetailCSV(Cliente_Retail cliente)
            {

                /** List<Cliente_Retail> clienteList = new List<Cliente_Retail>();
                 clienteList.Add(cliente);
                 //using (var stream = File.OpenWrite("/Users/damzSSD/Projects/ListaClienti.csv")) ;
                 //using (var reader = new StreamReader("/Users/damzSSD/Projects / ListaClienti.csv"), Encoding.UTF8);
                 using (var stream = File.OpenWrite("Utenti/damzSSD/Projects/GN_Gestione/ListaClienti.csv"))
                 {

                     using (var writer = new StreamWriter(stream))
                     {
                     }
                 }



                   **/
            }

       
        }
    }
