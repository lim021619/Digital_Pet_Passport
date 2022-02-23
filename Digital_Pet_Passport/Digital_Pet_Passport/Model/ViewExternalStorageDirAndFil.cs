using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Клас представляющий один экземпляр файла или папки
    /// </summary>
    public class ViewExternalStorageDirAndFil : INotifyPropertyChanged
    {
        private string path;
        private bool isFile;
        private string name;

        /// <summary>
        /// Полный путь до объекта
        /// </summary>
        public string Path { get => path; set { path = value; OnPropertyChange(nameof(Path)); } }

        /// <summary>
        /// Является ли файлом
        /// </summary>
        public bool IsFile { get => isFile; set { isFile = value; OnPropertyChange(nameof(IsFile)); } }

        public string Name { get => name; set { name = value; OnPropertyChange(nameof(Name)); } }

        public ViewExternalStorageDirAndFil(string path, bool isFile, string name)
        {
            Path = path;
            IsFile = isFile;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
