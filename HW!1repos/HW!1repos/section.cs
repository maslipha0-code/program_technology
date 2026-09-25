using System;
using System.Collections.Generic;
using System.Text;

namespace HW_1repos
{
  
       public class Section
        {
            // Уникальный идентификатор секции
            public int Id { get; set; }

            // Название секции 
            public string Name { get; set; }

            // Площадь секции в кв. метрах
            public int Area { get; set; }

            // Вычисляемое свойство: большая ли секция (Area > 200)
            public bool IsBig => Area > 200;

            // Метод для получения строковой информации о секции
            public string GetInfo()
            {
                return $"{Name} ({Area} м²)";
            }
        }
    

}
