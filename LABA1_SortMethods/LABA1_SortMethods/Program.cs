using LABA1_SortMethods.Frontend;

namespace LABA1_SortMethods;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}