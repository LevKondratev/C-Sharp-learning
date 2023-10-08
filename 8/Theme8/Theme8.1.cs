using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list = FillWithRandom(list, 100);
            Console.WriteLine("Исходная коллекция:");
            PrintOnScreen(list);

            list = DeleteFromList(list, 25, 50);
            Console.WriteLine("\n Коллекция после удаления элементов:");
            PrintOnScreen(list);
            Console.ReadKey();
        }

        /// <summary>
        /// Принимает лист и возвращает лист с указанным кол-вом случайных чисел от 0 до 100
        /// </summary>
        /// <param name="list">Лист</param>
        /// <param name="capscity">кол-во случайных чисел</param>
        /// <returns></returns>
        static public List<int> FillWithRandom(List<int> list, int capscity)
        {
            Random random = new Random();
            for (int i = 0; i < capscity; i++)
            {
                list.Add(random.Next(0, 101));
            }
            return list;
        }

        /// <summary>
        /// Принимает лист и выводит в консоль содержимое
        /// </summary>
        /// <param name="list">Лист</param>
        static public void PrintOnScreen (List<int> list)
        {
            foreach (int j in list)
            {
                Console.Write($"{j} ");
            }
        }

        /// <summary>
        /// Удаляет из листа числа, которые больше минимального значения и меньше максимального
        /// </summary>
        /// <param name="list"></param>
        /// <param name="minNumber">минимальное значение</param>
        /// <param name="maxNumber">максимальное значение</param>
        /// <returns></returns>
        static public List<int> DeleteFromList(List<int> list, int minNumber, int maxNumber)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] > minNumber && list[i] < maxNumber)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }
    }
}
