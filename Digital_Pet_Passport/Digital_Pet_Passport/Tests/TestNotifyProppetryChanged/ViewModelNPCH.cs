using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Digital_Pet_Passport.Tests.TestNotifyProppetryChanged
{
    public class ViewModelNPCH : INotifyPropertyChanged
    {
        private int number;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Number { get => number; set { number = value; OnPropertyChanged(nameof(Number)); } }

        public ObservableCollection<NPCH> Items { get; set; }


        public ViewModelNPCH()
        {
            Items = new ObservableCollection<NPCH>();
            InitObjects();
        }

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public async void InitObjects()
        {
            await System.Threading.Tasks.Task.Run(async () =>
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        await System.Threading.Tasks.Task.Delay(3000);
                        Items.Add(new NPCH() { Name = $"name_{i}" });
                    }

                }
                );
                

        }

    }
}
