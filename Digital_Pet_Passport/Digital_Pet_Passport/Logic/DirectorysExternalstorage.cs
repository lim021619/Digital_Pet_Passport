using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Digital_Pet_Passport.Logic
{
    public class DirectorysExternalstorage : BaseWorkFiles
    {
        /// <summary>
        /// Список директорий.
        /// </summary>
        public List<DirectoryInfo> Directories { get; set; }
        /// <summary>
        /// Список файлов
        /// </summary>
        public List<FileInfo> Files { get; set; }

        public object lockobject = new object();

        public string Path { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Model.ViewExternalStorageDirAndFil> DirAndFils { get; set; }

        object lockScaning = new object();

        public DirectorysExternalstorage()
        {
            InitProp();

           
                ScaningStoragAsync();
            
            
        }

        public DirectorysExternalstorage(string path)
        {
            InitProp();
            Path = path;
            ScaningStoragAsync();


        }

        /// <summary>
        /// Инициализация экземпляра класса
        /// </summary>
        void InitProp()
        {
            Directories = new List<DirectoryInfo>();
            Files = new List<FileInfo>();
            DirAndFils = new System.Collections.ObjectModel.ObservableCollection<Model.ViewExternalStorageDirAndFil>();
            Path = string.Empty;
          
        }
        /// <summary>
        /// Асинхронно инициализирует свойства директории и файлы по найденным объктам из переданого пути. Если не передать путь то проинициализирует свойтсва экземпляра 
        /// объектами найденными в корневой папке устройства.
        /// </summary>
        public async void ScaningStoragAsync()
        {
            await System.Threading.Tasks.Task.Run(() => { 
            
                lock(lockobject)
                {
                    ScaningStorag(Path);
                }

            });
        }

        /// <summary>
        /// Инициализирует свойства директории и файлы по найденным объктам из переданого пути. Если не передать путь то проинициализирует свойтсва экземпляра 
        /// объектами найденными в корневой папке устройства.
        /// </summary>
        public void ScaningStorag(string path)
        {
            if (path == string.Empty)
            {
                path = Expath;
            }

            (Directories, Files) = ScaningStorageByPath(path);

                foreach (var item in Directories)
                {
                    DirAndFils.Add(new Model.ViewExternalStorageDirAndFil(item.FullName, false, item.Name));
                }
                foreach (var item in Files)
                {
                    DirAndFils.Add(new Model.ViewExternalStorageDirAndFil(item.FullName, true, item.Name));
                }
            
        }

        /// <summary>
        /// Асинхронно возвращает список файлов и директорий в виде кортежа списков, найденных их переданного пути.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private async System.Threading.Tasks.Task<(List<DirectoryInfo>, List<FileInfo>)> ScaningStorageByPathAsync(string path)
        {
            return await System.Threading.Tasks.Task.Run(() => ScaningStorageByPath(path));
        }

        /// <summary>
        /// Возвращает список файлов и директорий в виде кортежа списков, найденных их переданного пути.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private (List<DirectoryInfo>, List<FileInfo>) ScaningStorageByPath(string path)
        {
            
            DirectoryInfo dir = new DirectoryInfo(path);

            List<DirectoryInfo> directories = dir.GetDirectories().ToList();

            List<FileInfo> files = dir.GetFiles().ToList();


            return (directories, files);

        }


}
}
