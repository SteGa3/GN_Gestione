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
        bool CreateFile(string _filename);
        StreamReader FileRead(string _filename);
        bool UpdateTextFile(string _filename, string [] stringList);
    }
}
