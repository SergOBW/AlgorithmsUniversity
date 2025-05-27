using LABA1_SortMethods.Frontend;

namespace LABA1_SortMethods;

/*
    Вариант №16.
    Программно реализовать следующие методы сортировки данных в оперативной памяти: сортировка прямым выбором; сортировка прямыми обменами.
    Оценить быстродействие указанных методов и степень естественности их поведения.
 */

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}