using LABA1_SortMethods.Frontend;

namespace LABA2_FIleSortMethods;

static class Program
{
    /*
    Вариант №16.
    Для получения оценки «отлично» необходимо программно реализовать следующие методы сортировки данных во внешней памяти: 
    сортировка прямым слиянием; многофазная сортировка. Оценить быстродействие указанных методов и степень естественности их поведения.
 */
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}