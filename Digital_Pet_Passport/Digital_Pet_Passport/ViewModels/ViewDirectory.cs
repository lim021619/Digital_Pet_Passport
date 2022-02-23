using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Digital_Pet_Passport.Enums;
using Digital_Pet_Passport.Logic;
using Digital_Pet_Passport.Model;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    /// <summary>
    /// Модель предстваления окна просмтора директории
    /// </summary>
    public class ViewDirectory : BaseMVVMViewPet
    {
        private DirectorysExternalstorage externalstorage;

        public string PathImage = string.Empty;
        private bool isEnableSelectImg;
        private ViewExternalStorageDirAndFil itemExternal;
        private string title = "Корневая директория";

        public event ChangePropBase IsEnableToolBarItemAddingImg;

        public ICommand OpenInnerDirectory { get; set; }

        public ICommand SelectImg { get; set; }

        public string Title { get => title; set { title = value; OnPropertyChange(nameof(Title)); } }

        public ViewExternalStorageDirAndFil ItemExternal { get => itemExternal; set { itemExternal = value; OnPropertyChange(nameof(ItemExternal)); } }

        public static string NamePet { get; set; }

        public DirectorysExternalstorage Externalstorage { get => externalstorage; set { externalstorage = value; OnPropertyChange(nameof(Externalstorage)); } }

        public bool IsEnableSelectImg
        {
            get => isEnableSelectImg;
            set
            {
                isEnableSelectImg = value;
                IsEnableToolBarItemAddingImg?.Invoke();
            }
        }

        public OptionDirectory Mode { get; set; }

        public ViewDirectory(OptionDirectory mode, string path = "")
        {
            InitView(mode, path);
        }

        protected virtual void InitView(OptionDirectory mode, string path = "")
        {
            Mode = mode;
            
            if (string.IsNullOrEmpty(path))
            {
                Externalstorage = new DirectorysExternalstorage();
            }
            else
            {
                Externalstorage = new DirectorysExternalstorage(path);
            }

            InitCommand();


        }

        protected virtual void InitCommand()
        {
            OpenInnerDirectory = new Command(OpenDir);
            SelectImg = new Command(Select);
        }

        private async void Select()
        {

            if (ItemExternal != null)
            {
                if (ItemExternal.IsFile)
                {
                    Title = $"Выбран файл {ItemExternal.Name}";
                    IsEnableSelectImg = true;

                    PathImage = ItemExternal.Path;
                    
                }
                else
                {
                    await Navigation.PushAsync(new View.ViewDirectory.DirectoryPage(Mode, ItemExternal.Path), true);
                }
            }

        }

        private void OpenDir(object obj)
        {
            Model.Image image = new Model.Image();
            if (!isEnableSelectImg)
            {
                return;
            }
            switch (Mode)
            {
                case OptionDirectory.Setting:

                    OtherModels.ImgDirectory.Fill
                        (
                           image.SaveImg(PathImage, NamePet),
                           new System.IO.FileInfo(PathImage).Name
                        );

                    break;
                case OptionDirectory.Create:
                    OtherModels.ImgDirectory.Fill(image.SaveImg(PathImage, NamePet));
                    break;
                default:
                    break;
            }

            ExitAllAPage();
        }

        protected virtual async void InitViewAsync(OptionDirectory mode, string path = "")
        {
            await System.Threading.Tasks.Task.Run(() => InitView(mode, path));
        }

        /// <summary>
        /// Закрытие всх окон просмотра директории кроме одного. От него идёт метод PopAsync
        /// </summary>
        async void ExitAllAPage()
        {

            var pages = Navigation.NavigationStack.Where(i => i is View.ViewDirectory.DirectoryPage).ToList();
            if (pages.Count != 1)
            {
                Navigation.RemovePage(pages.First());

                ExitAllAPage();
            }
            else
            {
                await Navigation.PopAsync(true);
            }

        }

        
    }
}
