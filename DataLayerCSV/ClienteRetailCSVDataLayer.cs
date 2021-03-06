﻿using System;
using Entities;
using DatalayerCSV;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace DataLayerCSV

{
    public class ClienteRetailCSVDataLayer: DatalayerCSVBase, IClienteRetailCSVDatalayer
    {
        

        public List<Cliente_Retail> GetAllRetail()
        {
            List<Cliente_Retail> All = new List<Cliente_Retail>();
            var resourceName = "ListaClienti.csv";

            //Read resource's csv file as StreamReader
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            StreamReader reader = fileManager.FileRead(resourceName); //

            //Populating List with Customers
            if (reader == null || reader.EndOfStream) //
            {
                Cliente_Retail error = new Cliente_Retail();
                error.Cl_Ret_Name = "Errore Lettura Stream";

                All.Add(error);
                return All;
            }

           
            List<string[]> v = GetCSVBody(reader, ";");

            reader.Close();
            
            foreach (var values in v)
            {
                //string[] values = s.Split(";"); //csv format

                Cliente_Retail SingleRetail = new Cliente_Retail();

                SingleRetail.Cl_Ret_Code = Convert.ToInt32(values[0]);
                SingleRetail.Cl_Ret_Name = values[1];
                SingleRetail.Cl_Ret_Nickname = values[2];

                if (values[3] == "") { SingleRetail.Cl_Ret_Tot = 0; }
                else { SingleRetail.Cl_Ret_Tot = Convert.ToInt32(values[3]); }

                if (values[4] == "") { SingleRetail.Cl_Ret_Act = 0; }
                else { SingleRetail.Cl_Ret_Act = Convert.ToInt32(values[4]); }

                SingleRetail.Cl_Ret_Comment = values[5];


                All.Add(SingleRetail);
            }

            return All;
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


            var values = GetCSVHeaders(reader,";");

            foreach (string str in values)
            {

                headers.Add(str);

            }

            reader.Close();

            return headers;
        }
        
        public int InsRetailCSV(Cliente_Retail cliente)
        {
            var resourceName = "ListaClienti.csv";

            string line;
            List<string> values = new List<string>();
            Cliente_Retail ClToAdd = new Cliente_Retail();

            Cliente_Retail oldElement = new Cliente_Retail();
            int idSave = 0;

            int checkInsLista;
            
            //Get headers and customers list
            List<string> headersList = GetAllHeaders();
            List<Cliente_Retail> ListToSort = GetAllRetail();
            


            //Insert headers in list to write 
            var headersInsert = string.Join(";", headersList);
            values.Add(headersInsert);

            //check if element already exists
            bool containsItem = ListToSort.Any(item => item.Cl_Ret_Code == cliente.Cl_Ret_Code);

            List<Cliente_Retail> SortedList = new List<Cliente_Retail>();

            if (!containsItem)
            {
                //check available id
                ClToAdd = cliente;
                ClToAdd.Cl_Ret_Code = GetId(ListToSort);
                idSave = ClToAdd.Cl_Ret_Code;
               
            }

            else
            {
                List<Cliente_Retail> check = ListToSort.FindAll(x => x.Cl_Ret_Code == cliente.Cl_Ret_Code);
                oldElement = check[0];
                idSave = check[0].Cl_Ret_Code;
                var itemToRemove = ListToSort.Single(r => r.Cl_Ret_Code == cliente.Cl_Ret_Code);
                ListToSort.Remove(itemToRemove);
                ClToAdd.Cl_Ret_Code = oldElement.Cl_Ret_Code; //
                ClToAdd.Cl_Ret_Name = cliente.Cl_Ret_Name;
                ClToAdd.Cl_Ret_Nickname = cliente.Cl_Ret_Nickname;
                ClToAdd.Cl_Ret_Tot = cliente.Cl_Ret_Tot; //
                ClToAdd.Cl_Ret_Act = cliente.Cl_Ret_Act;
                ClToAdd.Cl_Ret_Comment = cliente.Cl_Ret_Comment;
            }

            //add new customer with proper id
            ListToSort.Add(ClToAdd);
            SortedList = ListToSort.OrderBy(o => o.Cl_Ret_Name).ToList();

             //check if inserted in list
            List<Cliente_Retail> results = SortedList.FindAll(x => x.Cl_Ret_Code == idSave);
            if (results.Count == 0)
            {
                checkInsLista = (int)InsResultsCodes.NotCreatedAfterIns;
                return checkInsLista;
            }

            else { checkInsLista = (int)InsResultsCodes.ListNewElementCreated; }


            //Write on string List
            foreach (Cliente_Retail c in SortedList)
            {
                line = Convert.ToString(c.Cl_Ret_Code) + ";" +
                       Convert.ToString(c.Cl_Ret_Name) + ";" +
                       Convert.ToString(c.Cl_Ret_Nickname) + ";" +
                       Convert.ToString(c.Cl_Ret_Tot) + ";" +
                       Convert.ToString(c.Cl_Ret_Act) + ";" +
                       Convert.ToString(c.Cl_Ret_Comment);
                        //Convert.ToString(c.Cl_Ret_Comment);

                values.Add(line);
            }

            string[] str = values.ToArray();
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            var checkIO = fileManager.UpdateTextFile(resourceName,str);
            if (checkIO == true)
            {
                checkInsLista = (int)InsResultsCodes.ElementAddedSaveOnFile;
            }
            else { checkInsLista = (int)InsResultsCodes.ElementNotAddedOnFile; }


            return checkInsLista;
        }

        public int DeleteRetailCSV(Cliente_Retail cliente)
        {
            var resourceName = "ListaClienti.csv";

            string line;
            List<string> values = new List<string>();
            Cliente_Retail ClToDel = cliente;

            int checkInsLista;

            //Get headers and customers list
            List<string> headersList = GetAllHeaders();
            List<Cliente_Retail> CustomersList = GetAllRetail();

            //Insert headers in list to write 
            var headersInsert = string.Join(";", headersList);
            values.Add(headersInsert);

            //delete customer from list           
            var itemToRemove = CustomersList.Single(r => r.Cl_Ret_Code == cliente.Cl_Ret_Code);
            CustomersList.Remove(itemToRemove);

            //check if inserted
            List<Cliente_Retail> results = CustomersList.FindAll(x => x.Cl_Ret_Code == cliente.Cl_Ret_Code);
            if (results.Count > 0)
            {
                checkInsLista = (int)DelResultsCodes.ListElementNotDeleted;
                return checkInsLista;
            }
            else { checkInsLista = (int)DelResultsCodes.ListElementDeleted; }


            //Write on string List
            foreach (Cliente_Retail c in CustomersList)
            {
                line = Convert.ToString(c.Cl_Ret_Code) + ";" +
                       Convert.ToString(c.Cl_Ret_Name) + ";" +
                       Convert.ToString(c.Cl_Ret_Nickname) + ";" +
                       Convert.ToString(c.Cl_Ret_Tot) + ";" +
                       Convert.ToString(c.Cl_Ret_Act) + ";" +
                       Convert.ToString(c.Cl_Ret_Comment);

                values.Add(line);
            }

            String[] str = values.ToArray();
            FileManager.DeviceIO fileManager = new FileManager.DeviceIO();
            var checkIO = fileManager.UpdateTextFile(resourceName, str);
            if (checkIO == true)
            {
                checkInsLista = (int)DelResultsCodes.ElementDeletedOnFile;
            }
            else { checkInsLista = (int)DelResultsCodes.ElementNotDeletedOnFile; }


            return checkInsLista;
        }

        public int GetId(List<Cliente_Retail> ListaClienti)
        {
            int idresult;
            var highercode = ListaClienti.Max(r => r.Cl_Ret_Code);
            idresult = Convert.ToInt32(highercode);
            return idresult+1;
        }

        //Errors enum
        public enum DelResultsCodes
        {
            ElementNotFound= 0,
            ListElementNotDeleted = 1,
            ListElementDeleted = 2,
            ElementNotDeletedOnFile = 3,
            ElementDeletedOnFile = 4
        }


        public enum InsResultsCodes
        {   
            ErrorIns = 0,
            NotCreatedAfterIns = 1,
            ListNewElementCreated = 2,
            ElementNotAddedOnFile = 3,
            ElementAddedSaveOnFile = 4
        } 
    }
}








