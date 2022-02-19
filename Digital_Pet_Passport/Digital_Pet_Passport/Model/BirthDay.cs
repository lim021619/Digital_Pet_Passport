using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Pet_Passport.Model
{
    /// <summary>
    /// Дата рождения
    /// </summary>
    public class BirthDay : NotifyPropertyChange, IContext
    {
        private int allDaysLive;
        private int yearLive;
        private int mouthLive;
        private int daysLive;
        private string nowFullAge;
        private bool initLiveAgeFlag;
        private int year;
        private int mounth;
        private int day;
        private bool fillPropyDate;
        private bool OnDay = false;
        private bool OnMonth = false;
        private bool OnYear = false;
        private DateTime birthDatebinding;
        private string shortLiveNow;
        private string birthDayDate;

        public delegate void FillProp();
        public delegate void FillBithDay(BirthDay birthDay);

        protected event FillProp OnFillYear;
        protected event FillProp OnFillMouth;
        protected event FillProp OnFillDay;
        protected event FillProp OnFillPropDate;
        protected event FillProp OnLiveMonth;
        protected event FillProp OnLiveDay;
        protected event FillProp OnLiveYear;


        public event FillBithDay OnFillBirthDate;

        public int Id { get; set; }
        /// <summary>
        /// Год рождения
        /// </summary>
        public int Year
        {
            get => year; set
            {
                year = value;
                if (year != 0)
                    OnFillYear?.Invoke();
            }
        }
        /// <summary>
        /// Месяц рождения
        /// </summary>
        public int Mounth
        {
            get => mounth; set
            {
                mounth = value;
                if (mounth != 0)
                    OnFillMouth?.Invoke();
            }
        }
        /// <summary>
        /// День рождения
        /// </summary>
        public int Day
        {
            get => day; set
            {
                day = value;
                if (day != 0)
                    OnFillDay?.Invoke();
            }
        }
        /// <summary>
        /// Id питомца
        /// </summary>
        public int AnimalId { get; set; }
        /// <summary>
        /// Питомец
        /// </summary>
        public Animal Animal { get; set; }

        public string BirthDayDate { get => birthDayDate; set { birthDayDate = value; OnPropertyChange(nameof(BirthDayDate)); } }

        [NotMapped]
        public bool FillPropDate { get => fillPropyDate; set { fillPropyDate = value; if (fillPropyDate) OnFillPropDate?.Invoke(); } }

        /// <summary>
        /// Кол-во прожитых дней(всего дней)
        /// </summary>
        [NotMapped]
        public int AllDaysLive { get => allDaysLive; set { allDaysLive = value; OnPropertyChange(nameof(AllDaysLive)); } }
        /// <summary>
        /// Кол-во прожитых лет
        /// </summary>
        [NotMapped]
        public int YearLive { get => yearLive; set { yearLive = value; OnPropertyChange(nameof(YearLive)); OnLiveYear?.Invoke(); } }
        /// <summary>
        /// Кол-во прожитых месяцев
        /// </summary>
        [NotMapped]
        public int MouthLive { get => mouthLive; set { mouthLive = value; OnPropertyChange(nameof(MouthLive)); OnLiveMonth?.Invoke(); } }
        /// <summary>
        /// Кол-во прожитых дней(дней с учетом вычета лет и месяцев)
        /// </summary>
        [NotMapped]
        public int DaysLive { get => daysLive; set { daysLive = value; OnPropertyChange(nameof(DaysLive)); OnLiveDay?.Invoke(); } }
        /// <summary>
        /// Строка представляющаяя информацию о возрасте
        /// </summary>
        [NotMapped]
        public string NowFullAge { get => nowFullAge; set { nowFullAge = value; OnPropertyChange(nameof(NowFullAge)); } }
        /// <summary>
        /// Флаг информирует были ли проиницализированы свойства возраста
        /// </summary>
        [NotMapped]
        public bool InitLiveAgeFlag { get => initLiveAgeFlag; set { initLiveAgeFlag = value; OnPropertyChange(nameof(InitLiveAgeFlag)); } }
        [NotMapped]
        public DateTime BirthDatebinding
        {
            get => birthDatebinding; set
            {
                birthDatebinding = value; OnPropertyChange(nameof(BirthDatebinding));

                OnFillBirthDate?.Invoke(this);

                OnDay = false;
                OnMonth = false;
                OnYear = false;
                InitLiveAgeFlag = false;
                FillPropDate = false;

            }
        }
        /// <summary>
        /// Замок инициализации свойств возраста
        /// </summary>
        object LockLiveAge { get; set; }
        [NotMapped]
        public string ShortLiveNow { get => shortLiveNow; set { shortLiveNow = value; OnPropertyChange(nameof(ShortLiveNow)); } }
        [NotMapped]
        public bool MonthLiveFlag { get; private set; }
        [NotMapped]
        public bool YearLiveFlag { get; private set; }

        public BirthDay()
        {
            InitEvents();
            if (Year != 0 && Mounth != 0 && Day != 0) InitBirthDayDate();
            InitLiveAgeFlag = false;
            LockLiveAge = new object();
            BirthDatebinding = DateTime.Now;
            MonthLiveFlag = false;
            YearLiveFlag = false;

        }



        protected virtual async void InitEvents()
        {
            OnFillDay += BirthDay_OnFillDay;
            OnFillMouth += BirthDay_OnFillMouth;
            OnFillYear += BirthDay_OnFillYear;
            OnFillPropDate += BirthDay_OnFillPropDate;

            OnLiveYear += BirthDay_OnLiveYear;
            OnLiveMonth += BirthDay_OnLiveMonth;
            OnLiveDay += BirthDay_OnLiveDay;

        }

        private void BirthDay_OnLiveDay()
        {
            if (!MonthLiveFlag && !YearLiveFlag)
            {
                ShortLiveNow = $"{AllDaysLive} д.";
            }
        }

        private void BirthDay_OnLiveMonth()
        {
            if (MouthLive != 0)
            {
                ShortLiveNow += $"{MouthLive} м.";
                MonthLiveFlag = true;
            }
        }

        private void BirthDay_OnLiveYear()
        {
            if (YearLive != 0)
            {
                ShortLiveNow += $"{YearLive} г.";
                YearLiveFlag = true;

            }
        }

        /// <summary>
        /// Событие которое инициализирует возраст
        /// </summary>
        private async void BirthDay_OnFillPropDate()
        {
            FullAgeAsync();

        }

        private void BirthDay_OnFillYear()
        {
            OnYear = true;
            ChekEventFill();

        }

        private void BirthDay_OnFillMouth()
        {
            OnMonth = true;
            ChekEventFill();

        }

        private void BirthDay_OnFillDay()
        {
            OnDay = true;
            ChekEventFill();
        }

        /// <summary>
        /// Осуществляет проверку наличия значния в свойствах Year, Mounth, Day
        /// </summary>
        void ChekEventFill()
        {
            if (OnDay && OnMonth && OnYear)
            {
                FillPropDate = true;
            }
        }


        /// <summary>
        /// Возвращает дату рождения питомца
        /// </summary>
        /// <returns></returns>
        public DateTime GetBirthDay()
        {
            return new DateTime(Year, Mounth, Day);

        }

        /// <summary>
        /// Метод инициализирующий возраст животоного
        /// </summary>
        /// <returns></returns>
        public void SetAge(DateTime dateTime)
        {
            Day = dateTime.Day;
            Year = dateTime.Year;
            Mounth = dateTime.Month;
            InitBirthDayDate();

        }
        /// <summary>
        /// Инициализиурет свойство BirthDayDate и возвращает его
        /// </summary>
        /// <returns></returns>
        public string InitBirthDayDate()
        {
            return BirthDayDate = GetBirthDayDateTime().ToLongDateString();

        }

        /// <summary>
        /// Возвращает структуру DateTima с данными из объекта
        /// </summary>
        /// <returns></returns>
        public DateTime GetBirthDayDateTime()
        {
            return new DateTime(Year, Mounth, Day);
        }

        /// <summary>
        /// Асинхронно возващает строку возраста
        /// </summary>
        /// <returns></returns>
        protected async Task<string> FullAgeAsync()
        {
            return await Task.Run(FullAge);
        }

        /// <summary>
        /// Инициалзирует свойства NowFullAge и возвращает строку возраста
        /// </summary>
        /// <returns></returns>
        protected string FullAge()
        {
            if (InitLiveAgeFlag)
            {
                return NowFullAge = $"{YearLive} г.{MouthLive} м.{Math.Abs(DaysLive)} дн. {AllDaysLive} всего дней";
            }
            else
            {
                InitBirthDayDate();
                InitLiveAge();
                return NowFullAge = $"{YearLive} г.{MouthLive} м.{Math.Abs(DaysLive)} дн. {AllDaysLive} всего дней";
            }

        }

        /// <summary>
        /// Асинхронно инициализурует свойства возраста
        /// </summary>
        /// <returns></returns>
        protected async Task InitLiveAgeAsync()
        {
            await Task.Run(InitLiveAge);
        }

        /// <summary>
        /// Инициализирует свойства возраста.
        /// </summary>
        private void InitLiveAge()
        {
            lock (LockLiveAge)
            {
                ReCulculateDays();

                int days = AllDaysLive, year = Year, yearCount = 0, month = Mounth, numberMounth = 0;

                while (true)
                {
                    if (month == 13)
                    {
                        month = 1;
                    }
                    int daystomounththis = DateTime.DaysInMonth(year, month);

                    days -= daystomounththis;

                    if (days >= 0)
                    {
                        if (numberMounth < 12)
                        {
                            numberMounth++;

                        }
                        else
                        {
                            numberMounth = 1;
                            yearCount++;
                            year++;
                        }

                        month++;
                    }
                    else
                    {
                        days += daystomounththis;
                        break;
                    }
                }

                YearLive = yearCount;
                MouthLive = numberMounth;
                DaysLive = Math.Abs(days);
                if (!InitLiveAgeFlag)
                {
                    InitLiveAgeFlag = true;
                }

            }

        }
        /// <summary>
        /// Возвращает клоличество прожитых лет
        /// </summary>
        /// <returns></returns>
        public int GetYear()
        {
            if (InitLiveAgeFlag)
            {
                return YearLive;
            }
            else
            {
                InitLiveAge();
                return YearLive;
            }

        }

        public int GetMouth()
        {
            if (InitLiveAgeFlag)
            {
                return MouthLive;
            }
            else
            {
                InitLiveAge();
                return MouthLive;

            }
        }

        public int GetDaysLive()
        {
            if (InitLiveAgeFlag)
            {
                return DaysLive;
            }
            else
            {
                InitLiveAge();
                return DaysLive;
            }
        }

        public int GetAllDaysLive()
        {
            if (AllDaysLive != 0)
            {
                return AllDaysLive;
            }
            else
            {
                ReCulculateDays();
                return AllDaysLive;
            }
        }


        /// <summary>
        /// Высчиывает общее кол-во прожитых дней
        /// </summary>
        /// <returns>Кол-во прожитых дней</returns>
        protected int ReCulculateDays()
        {
            TimeSpan timeSpan = TimeSpan.Zero;
            DateTime birthday = GetBirthDay();
            timeSpan = DateTime.Now.Date - birthday.Date;
            return AllDaysLive = ((int)timeSpan.TotalDays);

        }

        /// <summary>
        /// Высчитывает кол-во прожитых дней и если initPropAge = true инициализирует все свойсва возраста NowFullAge.
        /// В противном случае просто высчитывает кол-во прожитых дней.
        /// </summary>
        /// <param name="initPropAge">Флаг надо ли пересчитать свойство NowFullAge </param>
        /// <returns>Кол-во прожитых дней</returns>
        public int ReculateDays(bool initPropAge = false)
        {
            ReculateDays();

            if (!initPropAge)
            {
                return AllDaysLive;
            }

            FullAge();

            return AllDaysLive;

        }



    }

}
