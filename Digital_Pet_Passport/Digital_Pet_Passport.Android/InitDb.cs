using System;
using System.IO;
using Xamarin.Forms;

namespace Digital_Pet_Passport.Droid
{
    public class InitDb
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
        }
    }
}