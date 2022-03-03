using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Pet_Passport.Model
{
    
    public class Marker : NotifyPropertyChange
    {
        private string nameMarker;
        private string pathImageMarker;

        public int Id { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        public string PathImageMarker { get => pathImageMarker; set { pathImageMarker = value; OnPropertyChange(nameof(PathImageMarker)); } }

        public string NameMarker { get => nameMarker; set { nameMarker = value; OnPropertyChange(nameof(NameMarker)); } }

    }
}
