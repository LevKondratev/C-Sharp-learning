using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme7
{
    struct Worker
    {
        /// <summary>
        /// Индекс работника
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateOfAddition { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Index">Индекс сотрудника</param>
        /// <param name="DateOfAddition">Дата добавления</param>
        /// <param name="FIO">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="BirthPlace">Место рождения</param>
        /// <param name="DateOfBirth">Дата рождения</param>
        public Worker(int Index, DateTime DateOfAddition, string FIO, int Age, int Height, string BirthPlace, DateTime DateOfBirth)
        {
            this.Index = Index;
            this.DateOfAddition = DateOfAddition;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.BirthPlace = BirthPlace;
            this.DateOfBirth = DateOfBirth;
        }
        #region Остальные конструкторы Worker
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Index">Индекс сотрудника</param>
        /// <param name="DateOfAddition">Дата добавления</param>
        /// <param name="FIO">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="BirthPlace">Место рождения</param>
        public Worker(int Index, DateTime DateOfAddition, string FIO, int Age, int Height, string BirthPlace): 
            this(Index, DateOfAddition, FIO, Age, Height, BirthPlace, DateTime.MinValue)
        { }
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Index">Индекс сотрудника</param>
        /// <param name="DateOfAddition">Дата добавления</param>
        /// <param name="FIO">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        public Worker(int Index, DateTime DateOfAddition, string FIO, int Age, int Height) :
            this(Index, DateOfAddition, FIO, Age, Height, "Не указан", DateTime.MinValue)
        { }
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Index">Индекс сотрудника</param>
        /// <param name="DateOfAddition">Дата добавления</param>
        /// <param name="FIO">ФИО</param>
        /// <param name="Age">Возраст</param>
        public Worker(int Index, DateTime DateOfAddition, string FIO, int Age) :
            this(Index, DateOfAddition, FIO, Age, 0, "Не указан", DateTime.MinValue)
        { }
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="Index">Индекс сотрудника</param>
        /// <param name="DateOfAddition">Дата добавления</param>
        /// <param name="FIO">ФИО</param>
        public Worker(int Index, DateTime DateOfAddition, string FIO) :
            this(Index, DateOfAddition, FIO, 18, 0, "Не указан", DateTime.MinValue)
        { }
        #endregion
    }
}
