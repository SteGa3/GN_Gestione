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

        internal List<string[]> GetCSVBody(StreamReader streamReader)
        {
            List<string[]> results = new List<string[]>();
            using (streamReader) //
            {
                streamReader.ReadLine(); //skip headers

                while (!streamReader.EndOfStream)
                {
                    //Read lines of the stream
                    string line = streamReader.ReadLine();
                    //results.Add(line);
                    string[] values = line.Split(";");
                    results.Add(values);

                }

            }
            return results;
        }


        internal string[] GetCSVHeaders (StreamReader streamReader)
        {
            string line = streamReader.ReadLine();
            string[] values = line.Split(";");
            return values;
        }


        internal int GetCSVid(StreamReader streamReader)
        {
            var toCheck = GetCSVBody(streamReader);
            var highercode = toCheck.Max(r => Convert.ToInt32(r[0]));
            return highercode + 1;
        }
    }

}

            
            


 






