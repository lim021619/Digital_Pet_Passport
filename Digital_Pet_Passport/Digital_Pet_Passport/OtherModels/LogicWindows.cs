
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Digital_Pet_Passport.OtherModels
{
    /// <summary>
    /// Класс призван упростить раоту с вызовами окон. При дальнейшем изменении предствалений.
    /// Проедставляет в себе логику открытия всех ключевый окон.
    /// </summary>
    public class LogicWindows
    {
        /// <summary>
        /// Открыть окно просмтора питомца
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="pet"></param>
        public async void OpenDetaile(INavigation navigation, Model.Pet pet)
        {
            await navigation.PushAsync(new View.ViewDetailePet.DetailePage(pet));
        }
        /// <summary>
        /// Открыть окно создания нового питомца
        /// </summary>
        /// <param name="navigation"></param>
        public async void OpenCreate(INavigation navigation)
        {
            await navigation.PushAsync(new View.ViewCreatePet.CreatePage());
        }
        /// <summary>
        /// Открыть окно просмотра будещего питомца перед добавленем в приложение
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="pet"></param>
        public async void OpenDetaileCreate(INavigation navigation, Model.Pet pet)
        {
            await navigation.PushAsync(new View.ViewCreatePet.DetaileCreatePage(pet));
        }
        /// <summary>
        /// Открыть окно редактирования питомца
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="pet"></param>
        public async void OpenSettingPet(INavigation navigation, Model.Pet pet)
        {
            await navigation.PushAsync(new View.SettingPet.ViewSettingPetPage(pet));
        }

        public async void OpenRootWindow(INavigation navigation)
        {
            await navigation.PopToRootAsync();
        }
       
    }
}
