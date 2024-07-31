namespace RickAndMortyApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();           
        }
        public static void InitializeServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
