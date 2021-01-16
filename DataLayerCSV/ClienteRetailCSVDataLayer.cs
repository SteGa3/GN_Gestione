using System;
using Entities;
using DatalayerCSV;
using FileManager;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PCLStorage;


namespace DataLayerCSV

{
    public class ClienteRetailCSVDataLayer : IClienteRetailCSVDatalayer
    {

        public List<Cliente_Retail> GetAllRetail()
        {
            List<Cliente_Retail> All = new List<Cliente_Retail>();
            var resourceName = "ListaClienti.csv";

            //Read resource's csv file as StreamReader
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            StreamReader reader = fileManager.FileRead(resourceName);

            //Populating List with Customers
            if (reader == null || reader.EndOfStream)
            {
                Cliente_Retail error = new Cliente_Retail();
                error.Cl_Ret_Name = "Errore Lettura Stream";

                All.Add(error);
                return All;
            }
            
            using (reader)
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    //Read lines of the stream
                    string line = reader.ReadLine();
                    string[] values = line.Split(";"); //csv format

                    Cliente_Retail SingleRetail = new Cliente_Retail();

                    SingleRetail.Cl_Ret_CODE = Convert.ToInt32(values[0]);
                    SingleRetail.Cl_Ret_Name = values[1];
                    SingleRetail.Cl_Ret_Nickname = values[2];

                    if (values[3] == "") { SingleRetail.Cl_Ret_Act = 0; }
                    else { SingleRetail.Cl_Ret_Act = Convert.ToInt32(values[3]); }

                    if (values[4] == "") { SingleRetail.Cl_Ret_Tot = 0; }
                    else { SingleRetail.Cl_Ret_Tot = Convert.ToInt32(values[4]); }

                    SingleRetail.Cl_Ret_Comment = values[5];

                    All.Add(SingleRetail);
                }

                return All;
            }

        } 
                
           
        public List<String> GetAllHeaders()
        {
            //Read resource's csv file
            var resourceName = "ListaClienti.csv";

            List<string> headers = new List<string>();

            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            StreamReader reader = fileManager.FileRead(resourceName);

            if (reader == null || reader.EndOfStream is true)
            {
               
                string error = "Errore Lettura Stream";

                headers.Add(error);
                return headers;
            }
            
            using (reader)
            {
                //Read lines of the stream
                string line = reader.ReadLine();
                string[] values = line.Split(";");
                
                foreach (string str in values)
                {
                    headers.Add(str);
                }
                return headers;
            }
        }


        public int InsRetailCSV(Cliente_Retail cliente)
        {
            var resourceName = "ListaClienti.csv";

            string line;
            List<string> values = new List<string>();


            int checkInsLista;
            Cliente_Retail ClToAdd = cliente;
            List<Cliente_Retail> ListToSort = GetAllRetail();

            //check available id
            ClToAdd.Cl_Ret_CODE = GetId(ListToSort);

            //add new customer with proper id
            ListToSort.Add(ClToAdd);
            List<Cliente_Retail> SortedList = ListToSort.OrderBy(o => o.Cl_Ret_Name).ToList();

            //check if inserted
            List<Cliente_Retail> results = SortedList.FindAll(x => x.Cl_Ret_CODE == cliente.Cl_Ret_CODE);
            if (results.Count == 0)
            {
                checkInsLista = (int)InsResultsCodes.NotCreatedAfterIns;
            }
            else { checkInsLista = (int)InsResultsCodes.Created; }

            AppSettings appSettings = new AppSettings();
            IFolder folder = appSettings.rootFolder;

            //Write on string List
            foreach (Cliente_Retail c in SortedList)
            {
                line =  Convert.ToString(c.Cl_Ret_CODE) + ";" +
                        Convert.ToString(c.Cl_Ret_Name) + ";" +
                        Convert.ToString(c.Cl_Ret_Nickname) + ";" +
                        Convert.ToString(c.Cl_Ret_Tot) + ";" +
                        Convert.ToString(c.Cl_Ret_Act) + ";" +
                        Convert.ToString(c.Cl_Ret_Comment);

                values.Add(line);
            }

            String[] str = values.ToArray();
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            fileManager.UpdateTextFile(resourceName,str);

            return checkInsLista;
        }


        public int GetId(List<Cliente_Retail> ListaClienti)
        {
            int idresult;
            var highercode = ListaClienti.Max(r => r.Cl_Ret_CODE);
            idresult = Convert.ToInt32(highercode);
            return idresult+1;
        }


        enum InsResultsCodes
        {   
            ErrorIns = 0,
            NotCreatedAfterIns = 1,
            Created = 2
        } 
    }
}








