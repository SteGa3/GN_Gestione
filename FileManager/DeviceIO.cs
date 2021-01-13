using System;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
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


        public async Task<IFile> ReadTextFileAsync(string _filename)
        {
            // declare an empty variable to be filled later
            IFile result = null;

            // see if the file exists
            try
            {
                // get hold of the file system
                IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;

                var existCheck = FileExists(_filename);


                // create a folder, if one does not exist already
                //IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);


                // create a file, opening any existing file
                IFile file = await rootFolder.CreateFileAsync(_filename, CreationCollisionOption.OpenIfExists);
            }



            // populate the file with some text

            // if the file doesn't exist
            catch (Exception ex)
            {
                // Output to debugger

            }

            // return the contents of the file
            return result;
        }


        public void WriteTextFile(string _filename)
        {
            bool check = false;
            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string folder = rootFolder.ToString();
            string fileName = rootFolder.Path.ToString() + "/" + _filename;

            File.Create(fileName);
            check = FileExists(_filename);

            
        }

        public Task<string> WriteTextFileAsync(string _filename, string _content)
        {
            throw new NotImplementedException();
        }

      
    }
}
