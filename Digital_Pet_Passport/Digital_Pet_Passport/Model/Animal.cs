using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Животоное
    /// </summary>
    public class Animal : IContext, INotifyPropertyChanged
    {
        public delegate void ChangeProperty();

        public event ChangeProperty EventChangeSex;

        private int age;
        private string outAge;
        private double weightValue;
        private bool sex = false;
        private string castration;
        private string kind;
        private string breed;
        private int weight;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        /// <summary>
        /// Порода
        /// </summary>
        public string Breed { get => breed; set { breed = value; OnPropertyChanged(nameof(Breed)); } }
        /// <summary>
        /// Вид
        /// </summary>
        public string Kind { get => kind; set { kind = value; OnPropertyChanged(nameof(Kind)); } }
        /// <summary>
        /// Возраст питомца в днях
        /// </summary>
        public int Age
        {
            get => age; set
            {

                age = value;
                OnPropertyChanged(nameof(Age));

            }
        }
        /// <summary>
        /// Вес животного
        /// </summary>
        public double WeightValue { get => weightValue; set { weightValue = value; OnPropertyChanged(nameof(WeightValue)); } }
        /// <summary>
        /// Определяет пол животного False - кабель, True - сука
        /// </summary>
        public bool Sex { get => sex; set { sex = value; OnPropertyChanged(nameof(Sex)); EventChangeSex?.Invoke(); } }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public BirthDay BirthDay { get; set; }

        public string Castration { get => castration; set { castration = value; OnPropertyChanged(nameof(Castration)); } }

        public List<Manipulaton> Manipulatons { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Weight> HistoryWeight { get; set; }

        public int LastWeightId { get => weight; set { weight = value; OnPropertyChanged(nameof(LastWeightId)); } }

        [NotMapped]
        public string OutAge
        {
            get { return outAge; }
            set
            {

                outAge = value;
                OnPropertyChanged("OutAge");

            }
        }
        public Animal()
        {   
            BirthDay = new BirthDay();
            HistoryWeight = new System.Collections.ObjectModel.ObservableCollection<Weight>();
            
        }

        virtual protected void InitObjct()
        {
            InitProp();
        }

        virtual protected void InitProp()
        {
            BirthDay = new BirthDay();
            BirthDay.Animal = this;
            
        }

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
