using System;
using MySql;
using PCLStorage;


namespace Entities
{

    public class AppSettings
    {
        public bool isFile { get; set; }
        public bool isDb { get; set; }


        public string DbUser { get; set; }
        public string DbPass { get; set; }

        public IFolder rootFolder = FileSystem.Current.LocalStorage;


        public enum FileType { noFile = 0, csv = 1, json = 2 }

        public enum DbType { noDb = 0, MySql = 1, MsSql = 2, MongoDb = 3 };

        public AppSettings()
        {
        }



    }
}
