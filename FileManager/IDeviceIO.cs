using System;
using System.Threading.Tasks;
using System.IO;
using PCLStorage;

namespace FileManager
{
    public interface IDeviceIO
    {
        bool FileExists(string _filename);
        Task<IFile> ReadTextFileAsync(string _filename);
        Task<string> WriteTextFileAsync(string _filename, string _content);
        void WriteTextFile(string _filename);
    }
}
