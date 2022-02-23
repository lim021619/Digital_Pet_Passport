using Digital_Pet_Passport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Digital_Pet_Passport.ViewModels
{
    public class BaseMVVMViewPet : NotifyPropertyChange
    {
        private Pet pet;

        public delegate void ChangePropBase();
        public delegate void EmptyProp(OtherModels.Msg msg);

        private bool emptyName;
        public event EmptyProp EmptyNameEvent;
        public bool EmptyName { get => emptyName; protected set { emptyName = value; if (!emptyName) EmptyNameEvent?.Invoke(Msg); } }

        public Pet Pet { get => pet; set { pet = value; OnPropertyChange(nameof(Pet)); } }
        public INavigation Navigation { get; set; }
        protected OtherModels.Msg Msg { get; set; }
        protected OtherModels.LogicWindows logicWindows { get; set; }

        public BaseMVVMViewPet()
        {
            Pet = new Pet();
            logicWindows = new OtherModels.LogicWindows();
            Msg = new OtherModels.Msg();
              
        }

        /// <summary>
        /// Проверяет кличку питомца возвращает истину если кличка прошла валидацию. В противном случае лож.
        /// </summary>
        protected bool ChekName()
        {
            if (string.IsNullOrEmpty(Pet.Name)) return false;
            
            return true;
        }
        /// <summary>
        /// Проверяет кличку питомца возвращает истину если кличка прошла валидацию. В противном случае лож.
        /// И если если параметр OnEventEmptyName то вызывает событие EmptyNameEvent о том что кличка не прошла валидацию.
        /// </summary>
        /// <param name="OnEventEmptyName"></param>
        /// <returns></returns>
        protected bool ChekName(bool OnEventEmptyName)
        {
            if (string.IsNullOrEmpty(Pet.Name)) EmptyName = false;
            else EmptyName = true;

            return emptyName;
        }

    }
}
