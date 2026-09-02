namespace BillingSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
<<<<<<< HEAD
        static void Main()//test
=======
        static void Main() //ayoko na sir
>>>>>>> c007b9c254c9b2c1d70f4088798b3d26348598d9
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}