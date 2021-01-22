using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using PCLStorage;

namespace FileManager
{
    public interface IDeviceIO
    {
        bool FileExists(string _filename);
        bool FolderExists(string _foldername);

        bool CreateFile(string _filename);
        bool CreateFolder(string _foldername);

        bool DeleteFolder(string _foldername);
        bool DeleteFile(string _filename);

        StreamReader FileRead(string _filename);
        bool UpdateTextFile(string _filename, string [] stringList);
    }
}
