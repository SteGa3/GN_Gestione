using System;
using System.IO;
using System.Threading.Tasks;
using DatalayerCSV;
using PCLStorage;
using Xamarin.Essentials;


namespace DataLayerCSV
{
    public class FileManagerCSVDataLayer : DatalayerCSVBase, IFileManagerCSVDataLayer
    {
        //check file existence
        public bool FileExists (string _filename)
        {
            
            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string fileName = rootFolder.Path.ToString() +"/" + _filename;
            bool existResult = File.Exists(fileName);
           
            //ExistenceCheckResult exist = await rootFolder.CheckExistsAsync(_filename);

            //string converter = rootFolder.Path.ToString();

            // create a folder, if one does not exist already
            //IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);

            return existResult;
            
        }

        // read a text file from the app's local folder
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

        // write a text file to the app's local folder
        public async Task<string> WriteTextFileAsync(string _filename, string _content)
        {
            // declare an empty variable to be filled later
            string result = null;
            try
            {
                // get hold of the file system
                IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;

                // create a folder, if one does not exist already
                //IFolder folder = await rootFolder.CreateFolderAsync("DailyBibleReading", CreationCollisionOption.OpenIfExists);

                // create a file, overwriting any existing file
                IFile file = await rootFolder.CreateFileAsync(_filename, CreationCollisionOption.FailIfExists);

                // populate the file with some text
                await file.WriteAllTextAsync(_content);

                result = _content;
            }
            // if there was a problem
            catch (Exception ex)
            {
                // Output to debugger

            }

            // return the contents of the file
            return result;
        }

        public bool WriteTextFile(string _filename)
        {
            bool check=false;
            IFolder rootFolder = PCLStorage.FileSystem.Current.LocalStorage;
            string folder = rootFolder.ToString();
            string fileName = rootFolder.Path.ToString() + "/" + _filename;

            File.Create(fileName);
            check = FileExists(_filename);

            return check;
        }


    }
}

