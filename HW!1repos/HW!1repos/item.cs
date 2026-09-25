using System;
using System.Collections.Generic;
using System.Text;

namespace HW_1repos
{
   
        public class Item
        {
            // Идентификатор товара айди
            public int Id { get; set; }

            // Название товара
            public string Name { get; set; }

            //  секция, в которой хранится товар
            public int SectionId { get; set; }

            //  кладовщик, отвечающий за товар
            public int StorekeeperId { get; set; }

            // количество товара на складе
            public int Quantity { get; set; }

            // цена за единицу товара децимал паматушта деньги
            public decimal Price { get; set; }

            // общая стоимость данного товара на складе
            public decimal TotalValue => Quantity * Price;

            // проверка ниже ли остаток заданного порога
            public bool IsLowStock(int threshold)
            {
                return Quantity < threshold;
            }

            // базовая информации о товаре
            public string GetInfo()
            {
                return $"{Name} ({Quantity} шт., {Price} руб.)";
            }
        }
    

}
