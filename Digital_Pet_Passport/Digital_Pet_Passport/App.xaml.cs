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
        public static Context.OperationContext OperationContext { get; set; }
        
        public static int CountPets { get; set; }
        public App()
        {
        
            InitializeComponent();
            Thread h = new Thread(new ThreadStart(InitContext));
            h.Start();

            //InitContext();
            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.LightGray };
            //MainPage = new NavigationPage(new Tests.TestNotifyProppetryChanged.TestViewNPCH()) { BarBackgroundColor = Color.LightGray };
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
                OperationContext = new Context.OperationContext(Contextdb);
            }
            
        }
    }
}
    