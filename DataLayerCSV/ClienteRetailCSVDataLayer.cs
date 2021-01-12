    using System;
    using Entities;
    using DatalayerCSV;
    using FileManager;
    using CsvHelper;
    using System.IO;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Text;
    using System.Data;
    using System.Reflection;
    using System.Security;
    using System.Linq;
   
    using PCLStorage;

using System.Globalization;


    [assembly: SecurityRules(SecurityRuleSet.Level2)]

    namespace DataLayerCSV

    {
        public class ClienteRetailCSVDataLayer : DatalayerCSVBase, IClienteRetailCSVDatalayer
        {
            
            public List<Cliente_Retail> GetAllRetail()
            {
                List<Cliente_Retail> All = new List<Cliente_Retail>();
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
                
                
                //Read resource's csv file
                //var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ListaClienti.csv";
                //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                

                //Populating List with Customers
                using (StreamReader reader = fileManager.FileRead(resourceName))
                {
                    bool first = false;
            
                    while (!reader.EndOfStream)
                    {
                        if (first) {

                            //Read lines of the stream
                            string line = reader.ReadLine();
                            string[] values = line.Split(";");
                
                    
                            Cliente_Retail SingleRetail = new Cliente_Retail();

                            SingleRetail.Cl_Ret_CODE = int.Parse(values[0]);
                            SingleRetail.Cl_Ret_Name = values[1];
                            SingleRetail.Cl_Ret_Nickname = values[2];
                                                        
                            if (values[3] == "") { SingleRetail.Cl_Ret_Act = 0; }
                            else { SingleRetail.Cl_Ret_Act = Convert.ToInt32(values[3]); }

                            if (values[4] == "") { SingleRetail.Cl_Ret_Tot = 0; }
                            else { SingleRetail.Cl_Ret_Tot = Convert.ToInt32(values[4]); }

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
           
            public List<String> GetAllHeaders()
            {
                

                //Read resource's csv file
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ListaClienti.csv";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))

                using (StreamReader reader = new StreamReader(stream))
                {
                    //Read lines of the stream
                    string line = reader.ReadLine();
                    string[] values = line.Split(";");
                    List<string> headers = new List<string>();
                    foreach (string str in values)
                    {
                        headers.Add(str);
                    }
            
                    return headers;
                }
           

            }

            public void InsRetailCSV(Cliente_Retail cliente)
            {
                List<Cliente_Retail> ListToSort = GetAllRetail();
                ListToSort.Add(cliente);
                List<Cliente_Retail> SortedList = ListToSort.OrderBy(o => o.Cl_Ret_Name).ToList();
                int nElementi = SortedList.Count;
                


               /* IFolder folder = FileSystem.Current.LocalStorage;

                IFile file = folder.GetFileAsync(folder + "ListaClienti.csv");

                string path = file.Path;
                using (StreamWriter writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(SortedList);
                }*/

            /**
            using (var stream = File.OpenWrite("/Users/damzSSD/Projects/ListaClienti.csv")) ;
            using (var reader = new StreamReader("/Users/damzSSD/Projects / ListaClienti.csv"), Encoding.UTF8);
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
