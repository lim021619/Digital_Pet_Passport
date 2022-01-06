using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Клас представляющий один экземпляр файла или папки
    /// </summary>
    public class ViewExternalStorageDirAndFil
    {
        /// <summary>
        /// Полный путь до объекта
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Является ли файлом
        /// </summary>
        public bool IsFile { get; set; }

        public string Name { get; set; }

        public ViewExternalStorageDirAndFil(string path, bool isFile, string name)
        {
            Path = path;
            IsFile = isFile;
            Name = name;
        }

    }
}
