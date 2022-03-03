using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public event ChangeProperty EmptyHistoryWeights;

        public const string Man = "Кастрация";
        public const string Wooman = "Стерелизация";
        public const string WordWoomanSter = "Стерелизована";
        public const string WordCast = "Кастрирован";



        private int age;
        private string outAge;
        private double weightValue;
        private bool sex;
        private bool castration;

        private string kind;
        private string breed;
        private int weight;
        private Weight weightNow;
        private string wordCastration = Man;
        private string resulteCastString = WordCast;

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

        public bool Castration { get => castration; set { castration = value; OnPropertyChanged(nameof(Castration)); } }
        
        public System.Collections.ObjectModel.ObservableCollection<Manipulaton> Manipulatons { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Weight> HistoryWeight { get; set; }
        
        public int LastWeightId { get => weight; set { weight = value; OnPropertyChanged(nameof(LastWeightId)); } }

        /// <summary>
        /// Строка которая представляет информацию о том кастрирован(стерелизван) ли питомцец
        /// </summary>
        public string ResulteCastString { get => resulteCastString; set { resulteCastString = value; OnPropertyChanged(nameof(ResulteCastString)); } }

        [NotMapped]
        public Weight WeightNow { get => weightNow; set { weightNow = value; OnPropertyChanged(nameof(WeightNow)); } }

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
        [NotMapped]
        public string WordCastration { get => wordCastration; set { wordCastration = value; OnPropertyChanged(nameof(WordCastration)); } }
        public Animal()
        {
            BirthDay = new BirthDay();
            HistoryWeight = new System.Collections.ObjectModel.ObservableCollection<Weight>();
            Manipulatons = new System.Collections.ObjectModel.ObservableCollection<Manipulaton>();
            WeightNow = new Weight();
            Weight searchActivWeight = HistoryWeight?.FirstOrDefault(w => w.IsActive);
            if (searchActivWeight != null) WeightNow = searchActivWeight;



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

        

        /// <summary>
        /// Добавляет новую отмету о весе животного
        /// </summary>
        public void AddWeightNow()
        {
            WeightNow.IsActive = true;
            HistoryWeight?.Add(WeightNow);
        }

        public void AddWeightNow(Weight weightNew)
        {
            weightNew.IsActive = true;
            WeightNow = weightNew;
            HistoryWeight?.Add(WeightNow);
        }

        public void ChangeWeightActive(Weight weightNew)
        {
            Weight weight = GetActiveWeight();
            if (weight != null)
            {
                GetActiveWeight(WeightNow.Id).IsActive = false;
                AddWeightNow(weightNew);
            }
            else
            {
                AddWeightNow();
            }
        }

        public Weight GetActiveWeight(bool chekAndNotify)
        {
            if (HistoryWeight?.Count != 0)
            {
                return HistoryWeight.FirstOrDefault(w => w.IsActive);
            }
            else
            {
                EmptyHistoryWeights?.Invoke();
                return weightNow;
            }
        }

        public Weight GetActiveWeight()
        {
            return HistoryWeight?.FirstOrDefault(w => w.IsActive);
        }

        public void SetWeightNow(Weight weight)
        {
            WeightNow = weight;
        }

        public void SetWeightNow()
        {
            WeightNow = GetActiveWeight(true);
        }
        public Weight GetActiveWeight(int byId)
        {
            return HistoryWeight?.FirstOrDefault(w => w.Id == byId);
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
