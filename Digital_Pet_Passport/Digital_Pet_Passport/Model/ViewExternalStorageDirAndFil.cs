using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Клас представляющий один экземпляр файла или папки
    /// </summary>
    public class ViewExternalStorageDirAndFil : INotifyPropertyChanged
    {
        delegate void ChangeProp();
        event ChangeProp changeIsFile;
        private string path;
        private bool isFile;
        private string name;
        private string pathImg;
        

        /// <summary>
        /// Полный путь до объекта
        /// </summary>
        public string Path { get => path; set { path = value; OnPropertyChange(nameof(Path)); } }

        /// <summary>
        /// Является ли файлом
        /// </summary>
        public bool IsFile { get => isFile; set { isFile = value; OnPropertyChange(nameof(IsFile)); changeIsFile?.Invoke(); } }

        public string Name { get => name; set { name = value; OnPropertyChange(nameof(Name)); } }

        public string PathImg { get => pathImg; set { pathImg = value; OnPropertyChange(nameof(PathImg)); } }

        public ViewExternalStorageDirAndFil(string path, bool isFile, string name)
        {
            changeIsFile += ViewExternalStorageDirAndFil_changeIsFile;
            Path = path;
            IsFile = isFile;
            Name = name;

        }

        private void ViewExternalStorageDirAndFil_changeIsFile()
        {
            if (isFile)
            {
                PathImg = path;
                
            }
            else
            {
                PathImg = OtherModels.PathImgPets.PathAvatar;
            }
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
