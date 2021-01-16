using System;
using MySql;
using PCLStorage;


namespace Entities
{

    public class AppSettings
    {
        public int CRetailIndex { get; set; }
        public string FileName { get; set; }
        public string DbUser { get; set; }
        public string DbPass { get; set; }

        public IFolder rootFolder = FileSystem.Current.LocalStorage;


        public enum FileType { noFile = 0, csv = 1, json = 2 }

        public enum DbType { MySql = 0, MsSql = 0, MongoDb = 2};



    }
}
