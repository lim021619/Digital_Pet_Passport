﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Digital_Pet_Passport
{
    public partial class MainPage : ContentPage
    {

        public System.Collections.ObjectModel.ObservableCollection<Model.Pet> PetsCollection { get; set; }
        public Context.OperationContext OperationContext { get; set; }
        public MainPage()
        {
            InitializeComponent();

            SetValue(NavigationPage.BarBackgroundColorProperty, Color.Red);
            PetsCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Pet>();
            Content.BindingContext = this;
            Pets.ItemsSource = PetsCollection;
            OperationContext = new Context.OperationContext();
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Общая информация"});
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "Связь с разработчиком"});
            ToolbarItems.Add(new ToolbarItem() { Order = ToolbarItemOrder.Secondary, Text = "О приложении"});
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            PetsCollection.Clear();

            DownloadPets();


        }

        void InitPorp()
        {
            
        }

        
        void DownloadPets()
        {

            foreach (Model.Pet item in OperationContext.GetListPets(false))
            {
                var f = item;
                if (item.Avatar == String.Empty || item.Avatar == null)
                {
                    f.Avatar = "DefoultPetImage.png";    
                }
                if (f.Sex)
                {
                    f.PathSex = "FemaleIcone.png";
                }
                else
                {
                    f.PathSex = "MaleImage.png";
                }


                PetsCollection.Add(f);
            }

            
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
                
        }
    }
}
