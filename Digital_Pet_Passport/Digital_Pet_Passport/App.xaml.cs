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

        public App()
        {
            InitializeComponent();
            Thread h = new Thread(new ThreadStart(InitContext));
            h.Start();
           //InitContext();
            MainPage = new NavigationPage(new MainPage());
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
            }
            
        }
    }
}
