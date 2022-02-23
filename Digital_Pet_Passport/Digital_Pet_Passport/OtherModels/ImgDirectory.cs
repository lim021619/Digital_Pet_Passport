using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.OtherModels
{
    /// <summary>
    /// Статический класс использующися для сохраниненя изображения независимо от окна вызова директории.
    /// </summary>
    public static class ImgDirectory
    {
        public delegate void Change();
        public static event Change changeName;
        public static event Change changePath;
        private static string nameImg;
        private static string pathImg;

        static object loking { get; set; } = new object();
        public static string NameImg { get => nameImg; set
            {
                nameImg = value; changeName?.Invoke();
            }
        }
        public static string PathImg { get => pathImg; set
            {
                pathImg = value;
                changePath?.Invoke();
            }
        }

        /// <summary>
        /// Заполняет свойства статического класса
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public static void Fill(string path, string name)
        {
            pathImg =
                nameImg = string.Empty;

            NameImg = name;
            PathImg = path;
        }
        /// <summary>
        /// Заполняет свойство пути к изображению
        /// </summary>
        /// <param name="path"></param>
        public static void Fill(string path)
        {
            pathImg = string.Empty;
            PathImg = path;
        }

        public async static void DropeDataAsync()
        {
            await System.Threading.Tasks.Task.Run(DropeData);
        }

        public static void DropeData()
        {
            lock (loking)
            {
                pathImg = nameImg = String.Empty;
            }
        }

        public static void DropEvent()
        {
            changePath = null;
            changeName = null;
        }


    }
}
