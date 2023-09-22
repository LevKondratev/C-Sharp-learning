 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository rep  = new Repository();
            rep.FileCreatedOrNot();
            ReadOrWrite(rep);

        }

        /// <summary>
        /// Метод основного меню, принимаем Repository для работы
        /// </summary>
        /// <param name="rep">Репозиторий</param>
        static void ReadOrWrite(Repository rep)
        {
            Console.WriteLine("Введите '1' если нужно просмотреть данные.\nВведите '2' если нужно заполнить или отредактировать данные.");

            string startPoint = Console.ReadLine();

            if (startPoint == "1")
            {
                ReadingFile(rep);
            }
            else if (startPoint == "2")
            {
                WriteingFile(rep);
            }
            else
            {
                Console.WriteLine("Введён неправильный символ.");
                ReadOrWrite(rep);
            }
        }

        /// <summary>
        /// Метод меню чтения данных.
        /// </summary>
        /// <param name="rep">Репозиторий</param>
        static void ReadingFile(Repository rep)
        {
            Console.WriteLine("\nВведите \n'1' - для просмотра всех записей \n'2' - для просмотра записи по ID \n'3' - для просмотра записей в выбранном диапазоне дат \n'0' - для возврата в главное меню");
            int choise = Convert.ToInt32(Console.ReadLine());

            switch (choise)
            {
                case 0: ReadOrWrite(rep); break;
                case 1: rep.WriteWorkers(rep.GetAllWorkers()); break;
                case 2: Console.WriteLine("Введите уникальный ID работника");
                    int iD = Convert.ToInt32(Console.ReadLine());
                    rep.WriteWorkers(rep.GetWorkerById(iD));
                    break;
                case 3: Console.WriteLine("Введите нижнюю границу даты и времени в формате --/--/---- --:--:--");
                    DateTime first = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите верхнюю границу даты и времени в формате --/--/---- --:--:--");
                    DateTime second = Convert.ToDateTime(Console.ReadLine());
                    rep.GetWorkersBetweenTwoDates(first, second);
                    break;
                default: Console.WriteLine("\nВвели неверное значение, возврат в меню чтения файла.");
                    ReadingFile(rep);
                    break;
            }
            Console.WriteLine("\nВведите любую цифру кроме нуля - для возврата в меню просмотра данных \n'0' - для возврата в главное меню");
            int close = Convert.ToInt32(Console.ReadLine());
            if (close == 0)
            {
                ReadOrWrite(rep);
            }
            else
            {
                ReadingFile(rep);
            }
        }

        /// <summary>
        /// Метод меню редактирования данных.
        /// </summary>
        /// <param name="rep">Репозиторий</param>
        static void WriteingFile(Repository rep)
        {
            Console.WriteLine("\nВведите \n'1' - для создания новой записи \n'2' - для удаления записи \n'0' - для возврата в главное меню\"");
            int choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
            {
                rep.AddWorker();
                Console.WriteLine("\nНовый сотрудник добавлен. Введите любую цифру кроме нуля - для возврата в меню редактирования данных \n'0' - для возврата в главное меню");
                int close = Convert.ToInt32(Console.ReadLine());
                if (close == 0)
                {
                    ReadOrWrite(rep);
                }
                else
                {
                    WriteingFile(rep);
                }
            }
            else if (choise == 2)
            {
                Console.WriteLine("Введите индекс (ID) удаляемого работника");
                int iD = Convert.ToInt32(Console.ReadLine());
                rep.DeleteWorker(iD);
                Console.WriteLine($"Работник с iD = {iD} удалён. Введите любую цифру кроме нуля - для возврата в меню редактирования данных \n'0' - для возврата в главное меню");
                int close = Convert.ToInt32(Console.ReadLine());
                if (close == 0)
                {
                    ReadOrWrite(rep);
                }
                else
                {
                    WriteingFile(rep);
                }
            }
            else if (choise == 0)
            {
                ReadOrWrite(rep);
            }
            else
            {
                Console.WriteLine("\nВведён неверный символ. Возврат в меню редактирования записи");
                WriteingFile(rep);
            }
        }
    }
}
