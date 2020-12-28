using System;
using System.IO;
using System.Threading.Tasks;
using PCLStorage;


namespace DatalayerCSV
{
    public interface IFileManagerCSVDataLayer
    {
        bool FileExists(string _filename);
        Task<IFile> ReadTextFileAsync(string _filename);
        Task<string> WriteTextFileAsync(string _filename, string _content);
        bool WriteTextFile(string _filename);

    }
}
