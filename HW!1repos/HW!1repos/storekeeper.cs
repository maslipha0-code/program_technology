using System;
using System.Collections.Generic;
using System.Text;

namespace HW_1repos

{
    public class Storekeeper
    {
        // Уникальный идентификатор кладовщика
        public int Id { get; set; }

        // ФИО кладовщика
        public string FullName { get; set; }

        // Смена ("Утренняя", "Вечерняя" и т.д.)
        public string Shift { get; set; }

        // Опыт работы в годах
        public int Experience { get; set; }

        // Вычисляемое свойство: утренняя ли смена
        public bool IsMorningShift => Shift == "Утренняя";

        // Метод для получения информации о кладовщике
        public string GetInfo()
        {
            return $"{FullName} ({Experience} лет опыта)";
        }
    }
}
