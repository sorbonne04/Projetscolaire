using WinFormsApp2.Views;

using WinFormsApp2.Views;

namespace WinFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}