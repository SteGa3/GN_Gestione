using System;
using Entities;
using DatalayerCSV;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace DataLayerCSV
{
    public class DatalayerCSVBase
    {

        public List<string[]> GetCSVBody(StreamReader streamReader, string separator)
        {
            List<string[]> results = new List<string[]>();
            using (streamReader) //
            {
                streamReader.ReadLine(); //skip headers

                while (!streamReader.EndOfStream)
                {
                    //Read lines of the stream
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(separator);
                    results.Add(values);

                }

            }
            return results;
        }


        public string[] GetCSVHeaders (StreamReader streamReader, string separator)
        {
            string line = streamReader.ReadLine();
            string[] values = line.Split(separator);
            return values;
        }



        public bool DeleteItem (StreamReader streamReader, string separator, string[] item, int sortPosition)
        {
            bool check= true;

            List<string[]> results = new List<string[]>();
            using (streamReader) //
            {
                streamReader.ReadLine(); //skip headers

                while (!streamReader.EndOfStream)
                {
                    //Read lines of the stream
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(separator);
                    results.Add(values);

                }

            }

            //cerca elemento
            var itemToRemove = results.SingleOrDefault(r => r == item);
            if (itemToRemove != null)
            {
                results.Remove(itemToRemove);
                var sortedList = results.OrderBy(r => r[sortPosition]);
                //var itemRemoved = results.SingleOrDefault(r => r == item);
                


            }



            return check;          

        }


        public int GetCSVNextId(StreamReader streamReader, string separator)
        {
            var toCheck = GetCSVBody(streamReader, separator);
            var highercode = toCheck.Max(r => Convert.ToInt32(r[0]));
            return highercode + 1;
        }
    }

}

            
            


 






