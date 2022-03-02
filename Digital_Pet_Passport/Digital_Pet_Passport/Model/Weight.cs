using Digital_Pet_Passport.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{

    /// <summary>
    /// Класс отвечающий за вес животного
    /// </summary>
    public class Weight : NotifyPropertyChange, IContext
    {
        delegate void ValidationDataWeight();
        event ValidationDataWeight OnValidationDataWeight_KG;
        event ValidationDataWeight OnValidationDataWeight_GR;

        private int kg;
        private int gramm;
        private BirthDay dateWeight;
        private bool isActive = false;
        private int fixNumberCharToDatathiObject = StdFixNumber;

        public const int StdFixNumber = 3;
         [System.ComponentModel.DataAnnotations.Schema.NotMapped]   
        public int FixNumberCharToDatathiObject { get => fixNumberCharToDatathiObject; private set { fixNumberCharToDatathiObject = value; } }

        public int Id { get; set; }

        public int Kg { get => kg; set { kg = value; OnPropertyChange(nameof(Kg)); OnValidationDataWeight_KG?.Invoke(); } }

        public int Gramm { get => gramm; set { gramm = value; OnPropertyChange(nameof(Gramm)); OnValidationDataWeight_GR?.Invoke(); } }

        public bool IsActive { get => isActive; set => isActive = value; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public BirthDay DateWeight { get => dateWeight; set => dateWeight = value; }

        public int BirthDayId { get; set; }

        public Weight()
        {
            DateWeight = new BirthDay();
            DateWeight.SetAgeAsync(DateTime.Now);
            OnValidationDataWeight_GR += Weight_OnValidationDataWeight_GR;
            OnValidationDataWeight_KG += Weight_OnValidationDataWeight_KG;
        }

        private void Weight_OnValidationDataWeight_KG()
        {
            if (!ChekNumberChar(Kg))
            {
                Kg = FillArray(Kg);
            }
        }

        private void Weight_OnValidationDataWeight_GR()
        {
            if (!ChekNumberChar(Gramm))
            {
                Gramm = FillArray(Gramm);
            }
        }

        private int FillArray(int data)
        {
            char[] arr = data.ToString().ToCharArray();
            char[] arrNew = new char[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arrNew[i] = arr[i];
            }

            return Convert.ToInt32(arrNew.ToString());
        }

        private bool ChekNumberChar(int data)
        {
            
            if (data.ToString().Length > FixNumberCharToDatathiObject)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void InitObjct(string weightRow)
        {
            string[] arr = weightRow.Split(".");
            (int, bool)[] ps = new (int, bool)[2];

            if (arr.Length >= 3)
            {
                ps[0] = ChekChar(arr[0]);
                ps[1] = ChekChar(arr[1]);

            }
            else
            {
                arr = weightRow.Split(",");
                ps[0] = ChekChar(arr[0]);
                ps[1] = ChekChar(arr[1]);

            }

            Kg = ps[0].Item1;
            Gramm = ps[1].Item1;

        }

        public void Initobject(double weigthDouble)
        {
            string row = weigthDouble.ToString(".###");

            (int, bool) ps = ChekChar(row);
            (int, bool) ps2 = ChekChar(weigthDouble.ToString("#"));

            if (ps.Item2)
            {
                Gramm = ps.Item1;
            }
            if (ps2.Item2)
            {
                Kg = ps2.Item1;
            }

        }

        (int, bool) ChekChar(string x)
        {
            try
            {
                int i = Convert.ToInt32(x);

                return (i, true);
            }
            catch (Exception e)
            {

                return (0, false);
            }
        }


    }
}
