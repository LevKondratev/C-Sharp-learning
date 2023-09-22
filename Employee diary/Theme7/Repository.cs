using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme7
{
    internal class Repository
    {
        private string Path = "Сотрудники.csv";
        /// <summary>
        /// Конструкт класса Репозиторий
        /// </summary>
        public Repository()
        {
        }
        /// <summary>
        /// Метод проверки создан ли файл
        /// </summary>
        public void FileCreatedOrNot()
        {
            FileInfo fileInfo = new FileInfo(Path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"\nФайл {Path} уже существует. Путь: {fileInfo.FullName}\n");
            }
            else
            {
                fileInfo.Create().Close();
                Console.WriteLine($"\nФайл {Path} создан. Путь: {fileInfo.FullName}\n");
            }
        }
        /// <summary>
        /// Производит чтение файла и запись в (возвращает) workers[]
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            string[] lines = File.ReadAllLines(Path);
            Worker[] workers = new Worker[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split('#'); //заполняем строку data разделённой строкой[i]

                workers[i].Index = Convert.ToInt32(data[0]);
                workers[i].DateOfAddition = Convert.ToDateTime(data[1]);
                workers[i].FIO = Convert.ToString(data[2]);
                workers[i].Age = Convert.ToInt32(data[3]);
                workers[i].Height = Convert.ToInt32(data[4]);
                workers[i].DateOfBirth = Convert.ToDateTime(data[5]);
                workers[i].BirthPlace = Convert.ToString(data[6]);
            }
            return workers;
        }
        /// <summary>
        /// Производит печать принимаемых worker[]
        /// </summary>
        /// <param name="workers"></param>
        public void WriteWorkers(Worker[] workers)
        {
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"ID: {worker.Index}");
                Console.WriteLine($"Дата и время добавления записи: {worker.DateOfAddition}");
                Console.WriteLine($"Ф.И.О.: {worker.FIO}");
                Console.WriteLine($"Возраст: {worker.Age}");
                Console.WriteLine($"Рост: {worker.Height}");
                Console.WriteLine($"Дата рождения: {worker.DateOfBirth}");
                Console.WriteLine($"Место рождения: {worker.BirthPlace}");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Читает файл и возвращает Worker с запрашиваемым ID
        /// </summary>
        /// <param name="id">ID работника</param>
        /// <returns></returns>
        public Worker[] GetWorkerById(int id)
        {
            Worker[] workers_all = GetAllWorkers();
            Worker[] workerById = new Worker[1];

            for (int i = 0; i < workers_all.Length; i++)
            {
                if (workers_all[i].Index != id)
                {
                    continue;
                }
                else
                {
                    workerById[0] = workers_all[i];
                }
            }
            return workerById;

        }
        /// <summary>
        /// Считывает файл, перезаписывает файл без воркера с выбранным ID
        /// </summary>
        /// <param name="id">ID удаляемого работника</param>
        public void DeleteWorker(int id)
        {
            Worker[] workers_all = GetAllWorkers();
            using (StreamWriter writer = new StreamWriter(Path, false))
            {
                for (int i = 0; i < workers_all.Length; i++)
                {
                    if (workers_all[i].Index == id)
                    {
                        continue;
                    }
                    string workerLine = string.Join("#",
                                workers_all[i].Index,
                                workers_all[i].DateOfAddition,
                                workers_all[i].FIO,
                                workers_all[i].Age,
                                workers_all[i].Height,
                                workers_all[i].DateOfBirth,
                                workers_all[i].BirthPlace);
                    writer.WriteLine(workerLine);
                }
            }
        }
        /// <summary>
        /// Присваиваем ID и дописываем в файл
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker()
        {
            Worker worker = new Worker();
            int indexOfLines = NewID();
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine($"{indexOfLines}#{DateTime.Now}{DataParser(worker)}");
            }
            Console.WriteLine("Данные записаны.");
        }

        /// <summary>
        /// Происходит чтение файла, фильтрация по датам и возврат массива Worker
        /// </summary>
        /// <param name="dateFrom">Дата "ОТ"</param>
        /// <param name="dateTo">Дата "ДО"</param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers_all = GetAllWorkers();
            List<Worker> newWorkersList = new List<Worker>();

            for (int i = 0; i < workers_all.Length; i++)
            {
                if (workers_all[i].DateOfAddition < dateFrom || workers_all[i].DateOfAddition > dateTo)
                {
                    continue;
                }
                else
                {
                    newWorkersList.Add(workers_all[i]);
                }
            }
            return newWorkersList.ToArray();
        }
        /// <summary>
        /// Считывает файл и возвращает новый ID на основе Worker.Index последней строки
        /// </summary>
        /// <returns></returns>
        public int NewID()
        {
            Worker[] workers_all = GetAllWorkers();
            int lastLineIndex = workers_all.Length - 1;
            int newID = workers_all[lastLineIndex].Index + 1;
            return newID;
        }
        /// <summary>
        /// Метод запроса данных для ввода и передачи (возврат) готовой строки.
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        static string DataParser(Worker worker)
        {
            Console.WriteLine("\nВведите ФИО сотрудника");
            worker.FIO = Console.ReadLine();
            Console.WriteLine("\nВведите Возраст сотрудника");
            worker.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите Рост сотрудника");
            worker.Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите Дату рождения сотрудника");
            worker.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("\nВведите Место рождения сотрудника");
            worker.BirthPlace = Console.ReadLine();

            string newData = $"#{worker.FIO}#{worker.Age}#{worker.Height}#{worker.DateOfBirth}#город {worker.BirthPlace}";
            return newData;
        }
    }
}
