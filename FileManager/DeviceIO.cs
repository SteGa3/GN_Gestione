using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using PCLStorage;

namespace FileManager
{
    public class DeviceIO : IDeviceIO
    {
        
        public bool FileExists(string _filename)
        {

            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string fileName = rootFolder.Path.ToString() + "/" + _filename;
            bool existResult = File.Exists(fileName);

            //ExistenceCheckResult exist = await rootFolder.CheckExistsAsync(_filename);

            //string converter = rootFolder.Path.ToString();

            // create a folder, if one does not exist already
            //IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);

            return existResult;

        }


        public bool CreateFile(string _filename)
        {
            bool check = FileExists(_filename);
            if (!check)
            {
                IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
                string fileName = rootFolder.Path.ToString() + "/" + _filename;
                File.Create(fileName);
            }
            else { check = false; }

            return check;
        }


        public bool DeleteFile(string _filename)
        {
            bool check = FileExists(_filename);
            if (!check)
            {
                IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
                string fileName = rootFolder.Path.ToString() + "/" + _filename;
                File.Delete(fileName);
            }
            else { check = false; }

            return check;
        }


        public StreamReader FileRead(string _filename)
        {
            StreamReader streamReaded = null;
            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string path = rootFolder.Path.ToString() + "/" + _filename;
            bool existResult = File.Exists(path);
            if (existResult)
            {


                var stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                var reader = new StreamReader(stream);

                return reader;
            }

            else
            {

                return streamReaded;
            }

        }


        //Check type
        public bool UpdateTextFile(string _filename, string[] stringList)
        {
            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string path = rootFolder.Path.ToString() + "/" + _filename;
            bool existResult = File.Exists(path);

            bool check;

            if (existResult)
            {
                TextWriter tw = new StreamWriter(path);
                var lngt = stringList.Length;

                if (stringList != null || lngt != 0)
                {
                    foreach (string s in stringList)
                    {
                        tw.WriteLine(s);
                    }

                    tw.Close();
                    check = true;
                }
                else { check = false; }

            }
            
        
            else { check = false; }

            
            return check;
        }

    }
}
