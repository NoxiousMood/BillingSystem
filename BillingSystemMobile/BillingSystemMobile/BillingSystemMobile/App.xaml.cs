namespace BillingSystemMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // AppShell shows LoginPage first
            return new Window(new AppShell());
        }
    }
}
