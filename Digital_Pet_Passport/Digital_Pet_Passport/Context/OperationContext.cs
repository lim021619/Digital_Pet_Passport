using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digital_Pet_Passport.Context
{

    /// <summary>
    /// Объект для с контекстом данных
    /// </summary>
    public class OperationContext
    {
        /// <summary>
        /// Экемпляр контекста данных.
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Конструктор инициализирует экземпляр класса, для работы с базой данных.
        /// </summary>
        public OperationContext()
        {
            lock (App.LokingContext)
            {
                Context = App.Contextdb;
            }         
        }

        /// <summary>
        /// Добавляет одного питомца в бд
        /// </summary>
        /// <param name="pet"></param>
        public void AddPet(Model.Pet pet)
        {
            if (pet != null)
            {
                lock (App.LokingContext)
                {
                    Context?.DetachAllEntities();
                    Context?.Birthdays.Add(pet.BirthDay);
                    Context?.Pets.Add(pet);
                    Context?.SaveChanges();
                    Context?.DetachAllEntities();
                }
            }
        }

        /// <summary>
        /// Добавляет список питомцев в бд
        /// </summary>
        /// <param name="pets"></param>
        public void AddPatRange(IEnumerable<Model.Pet> pets)
        {
            lock (App.LokingContext)
            {
                Context?.DetachAllEntities();

                foreach (Model.Pet pet in pets)
                {
                    AddPet(pet);
                }

                Context?.DetachAllEntities();
            }
        }

        /// <summary>
        /// Каскадно удаляет питомца из бд
        /// </summary>
        /// <param name="pet"></param>
        public void RemovePet(Model.Pet pet)
        {
            if (pet != null)
            {
                lock (App.LokingContext)
                {
                    Context?.DetachAllEntities();
                    Context?.Pets.Remove(pet);
                    Context.SaveChanges();
                    Context.DetachAllEntities();
                }
            }

        }

        /// <summary>
        /// Каскадно удаляет список питомцев 
        /// </summary>
        public void RemovePetRange(IEnumerable<Model.Pet> pets)
        {
            foreach (Model.Pet pet in pets)
            {
                RemovePet(pet);
            }
        }

        /// <summary>
        /// Находит питомца по номеру
        /// </summary>
        /// <param name="id">номер</param>
        /// <param name="downloadInerProp">нужно ли подгружать данные даты рождения</param>
        /// <returns></returns>
        public Model.Pet GetPetById(int id, bool downloadInerProp)
        {

            Model.Pet pet = new Model.Pet(String.Empty);

            if (id != 0)
            {
                lock (App.LokingContext)
                {
                    Context?.DetachAllEntities();
                    if (downloadInerProp)
                    {
                        pet = Context?.Pets?.Include(p => p.BirthDay).Include(p => p.Images).FirstOrDefault(i => i.Id == id);
                    }
                    else
                    {
                        pet = Context?.Pets?.FirstOrDefault(i => i.Id == id);
                    }
                    Context?.DetachAllEntities();
                }


            }
            if (pet != null)
            {
                return pet;
            }

            return null;
        }


        /// <summary>
        /// Находит питомца в бд по кличке. Поиск регистронезависим.
        /// </summary>
        /// <param name="name">кличка</param>
        /// <param name="downloadInerProp">нужно ли подгружать дату рождения</param>
        /// <returns></returns>
        public Model.Pet GetPetById(string name, bool downloadInerProp)
        {

            Model.Pet pet = new Model.Pet(String.Empty);

            if (name != string.Empty)
            {
                lock (App.LokingContext)
                {
                    Context?.DetachAllEntities();

                    if (downloadInerProp)
                    {
                        pet = Context?.Pets?.Include(p => p.BirthDay).Include(p => p.Images).FirstOrDefault(i => i.Name.ToUpper().Trim() == name.ToUpper().Trim());
                    }
                    else
                    {
                        pet = Context?.Pets?.FirstOrDefault(i => i.Name == name);
                    }

                    Context?.DetachAllEntities();
                }


            }
            if (pet != null)
            {
                return pet;
            }

            return null;
        }


        /// <summary>
        /// Возвращает список всех питомцев
        /// </summary>
        /// <param name="downloadInerProp">нужно ли подгружать данные даты рождения</param>
        /// <returns></returns>
        public List<Model.Pet> GetListPets(bool downloadInerProp)
        {
            List<Model.Pet> pets = new List<Model.Pet>();

            lock(App.LokingContext)
            {
                Context?.DetachAllEntities();
                if (downloadInerProp) pets = Context?.Pets.Include(p => p.BirthDay)?.Include(p => p.Images).ToList();
                else
                {
                    pets = Context?.Pets?.ToList();
                }
                Context?.DetachAllEntities();
            }

            return pets;
        }

    }
}

