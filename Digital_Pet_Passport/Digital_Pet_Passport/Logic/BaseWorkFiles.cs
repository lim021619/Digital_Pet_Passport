using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;

namespace Digital_Pet_Passport.Logic
{
    public class BaseWorkFiles
    {
        /// <summary>
        /// Путь к внешнему хранилищу
        /// </summary>
        public static string ExPath { get; set; }
        /// <summary>
        /// Путь к внешнему хранилищу
        /// </summary>
        public string Expath { get; set; }
        /// <summary>
        /// Путь к внутрениму хранилищу
        /// </summary>
        public string InRootPath { get; set; }
        /// <summary>
        /// Путь к папке DCIM
        /// </summary>
        public string DCIM { get; set; }

        public BaseWorkFiles()
        {
            Expath = ExPath;
            InRootPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            
        }
    }
}
