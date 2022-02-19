using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Digital_Pet_Passport.Logic.Collections
{
    public class CollectionPetsDigital<T>: ObservableCollection<T>
    {
        public Model.Pet LastAddPet { get; set; }

        public CollectionPetsDigital()
        {
            LastAddPet = new Model.Pet();
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                LastAddPet = e.NewItems[e.NewItems.Count-1] as Model.Pet;
                MainPage.ViewModel_Pets.Pets.Add(LastAddPet);
                
            }

        }
    }
}
