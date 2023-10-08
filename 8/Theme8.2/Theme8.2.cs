using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic = AddNubmerFIO(dic);
            FindFIObyNubmer(dic);

            Console.ReadKey();
        }

        /// <summary>
        /// Принимает Dictionary, циклически добавляет пару <Номер_телефона, ФИО>, пока пользователь не введет пустую строку при вводе номера.
        /// </summary>
        /// <param name="dic">Словарь,Dictionary</param>
        /// <returns></returns>
        static Dictionary<string,string> AddNubmerFIO(Dictionary<string, string> dic)
        {
            Console.WriteLine("Для добавления, введите номер телефона. \nДля выхода оставьте пустую строку и нажмите 'Ввод'");
            string number = Console.ReadLine();

            if (number != string.Empty)
            {
                Console.WriteLine("Введите ФИО");
                dic.Add(number, Console.ReadLine());
                AddNubmerFIO(dic);
            }
            return dic;
        }

        /// <summary>
        /// Принимает исследуемый Dictionary, запрашивает номер телефона(ключ). Проверяет наличие и показывает, кому принадлежит номер.
        /// </summary>
        /// <param name="dic">Dictionary</param>
        static void FindFIObyNubmer(Dictionary<string, string> dic)
        {
            Console.WriteLine("Введите номер телефона ");
            string number = Console.ReadLine();
            string value;

            if (dic.TryGetValue(number, out value))
            {
                Console.WriteLine($"Номер {number} принадлежит {dic[number]}");
            }
            else
            {
                Console.WriteLine("Номер не найден. \n");
                FindFIObyNubmer(dic);
            }
            dic.ContainsKey(number);
        }
    }
}
