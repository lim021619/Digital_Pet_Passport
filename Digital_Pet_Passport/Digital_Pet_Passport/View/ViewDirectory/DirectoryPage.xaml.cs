
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Digital_Pet_Passport.View.ViewDirectory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectoryPage : ContentPage
    {
        Logic.DirectorysExternalstorage Externalstorage { get; set; }
        public ToolbarItem btnAdd { get; set; }

        public Page CreatPage { get; set; }

        string PathImage = string.Empty;
        
        
        public DirectoryPage(Page page)
        {

            CreatPage = page;

            Externalstorage = new Logic.DirectorysExternalstorage();
            InitializeComponent();
            Title = "Корневая папка";
            RootCont.BindingContext = this;
            lock (Externalstorage.lockobject)
            {
                ViewStorage.ItemsSource = Externalstorage.DirAndFils;
            }

            btnAdd = new ToolbarItem();
            btnAdd.Clicked += BtnAdd_Clicked;
            btnAdd.IsEnabled = false;
            btnAdd.Text = "Добавить";
            ToolbarItems.Add(btnAdd);
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            var creatp = CreatPage as View.ViewCreatePet.CreatePage;

            if (creatp != null)
            {
                
                Model.Image image = new Model.Image();
                creatp.ImagePathAvatar = creatp.Pet.Avatar = image.SaveImg(PathImage, creatp.NamePets);
              
            }
            else
            {
               var settingpet = CreatPage as View.SettingPet.ViewSettingPetPage;
                if (settingpet != null)
                {
                    Model.Image image = new Model.Image();
                    image.RemoveImage(settingpet.PathNewImage);
                    settingpet.PathNewImage = image.SaveImg(PathImage, settingpet.Pet.Name);
                    settingpet.ImageName = new FileInfo(settingpet.PathNewImage).Name;
                }
            }
            ExitAllAPage();
        }

        async void ExitAllAPage()
         {
           
            var pages = Navigation.NavigationStack.Where(i => i is DirectoryPage).ToList();
            if (pages.Count != 1)
            {
                Navigation.RemovePage(pages.First());

                ExitAllAPage();
            }
            else
            {
                await Navigation.PopAsync();
            }
           
        }

        public DirectoryPage(string path, Page page)
        {
            CreatPage = page;
            Externalstorage = new Logic.DirectorysExternalstorage(path);
            InitializeComponent();
            Title = "Файл не выбран";
            RootCont.BindingContext = this;
            lock (Externalstorage.lockobject)
            {
                ViewStorage.ItemsSource = Externalstorage.DirAndFils;
            }
            btnAdd = new ToolbarItem();
            btnAdd.Clicked += BtnAdd_Clicked;
            btnAdd.IsEnabled = false;
            btnAdd.Text = "Добавить";
            ToolbarItems.Add(btnAdd);
        }

        private async void ViewStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                Model.ViewExternalStorageDirAndFil dirAndFil = e.CurrentSelection[0] as Model.ViewExternalStorageDirAndFil;
                if (dirAndFil != null)
                {
                    if(dirAndFil.IsFile)
                    {
                      
                        Title = $"Выбран файл {dirAndFil.Name}";
                        btnAdd.IsEnabled = true;
                            
                            PathImage = dirAndFil.Path;
                        

                    }
                    else
                    {
                        await Navigation.PushAsync(new DirectoryPage(dirAndFil.Path, CreatPage));
                    }
                }
            }
        }
    }
}