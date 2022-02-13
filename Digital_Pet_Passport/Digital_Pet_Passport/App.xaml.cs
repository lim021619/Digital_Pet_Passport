using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Digital_Pet_Passport
{
    public partial class App : Application
    {
        /// <summary>
        /// Объект базы данных
        /// </summary>
        public static Context.Context Contextdb { get; set; }
        /// <summary>
        /// Замок базы данных
        /// </summary>
        public static object LokingContext = new object();

        public static ObservableCollection<Model.Pet> AllPets { get; set; }
        public static int CountPets { get; set; }
        public App()
        {
            AllPets = new ObservableCollection<Model.Pet>();
            InitializeComponent();
            Thread h = new Thread(new ThreadStart(InitContext));
            h.Start();

            //InitContext();
            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.LightGray};
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void Init() 
        {
            InitContextAsync();
        }

        async void InitContextAsync()
        {
            await Task.Run(() => InitContext());
        }

        void InitContext()
        {
            lock (LokingContext) {

                Contextdb = new Context.Context();
                foreach (Model.Pet pet in new Context.OperationContext().GetListPets(true))
                {
                    pet.ReCalculateAge();
                    AllPets.Add(pet);
                }
                CountPets = AllPets.Count(); /*Contextdb.Pets.ToList().Count;*/

            }
            
        }
    }
}
