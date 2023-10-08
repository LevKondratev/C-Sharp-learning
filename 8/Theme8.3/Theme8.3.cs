 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            AddNewNumber(set);
        }

        /// <summary>
        /// Циклично принимает Хэш-коллекцию, запрашивает ввод числа для добавления и проверки на повтор.
        /// </summary>
        /// <param name="set">HeshSet коллекция</param>
        static void AddNewNumber(HashSet<int> set)
        {
            Console.WriteLine("Введите число для добавления в коллекцию");
            int newNumber = Convert.ToInt32(Console.ReadLine());

            if (set.Add(newNumber))
            {
                Console.WriteLine("Число добавлено в коллекцию.");
                AddNewNumber(set);
            }
            else
            {
                Console.WriteLine("Число не добавлено. Введённое число уже содержится в коллекции.");
                AddNewNumber(set);
            }
        }
    }
}
