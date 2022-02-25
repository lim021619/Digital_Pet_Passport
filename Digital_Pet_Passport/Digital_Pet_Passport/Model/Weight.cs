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
        private int kg;
        private int gramm;
        private BirthDay dateWeight;

        public int Id { get; set; }

        public int Kg { get => kg; set { kg = value; OnPropertyChange(nameof(Kg)); } }

        public int Gramm { get => gramm; set { gramm = value; OnPropertyChange(nameof(Gramm)); } }

        public bool IsActive { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        public BirthDay DateWeight { get => dateWeight; set => dateWeight = value; }

        public Weight()
        {
            DateWeight = new BirthDay();
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
