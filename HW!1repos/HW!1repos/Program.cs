using HW_1repos;

using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace HW_1repos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выбираем источник данных
            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

            // Если файлов нет по пути сборки, можно задействовать InMemoryRepository для проверки:
            InMemoryRepository repo = new InMemoryRepository();
            List<Section> sections = repo.GetSections();
            List<Storekeeper> storekeepers = repo.GetStorekeepers();
            List<Item> items = repo.GetItems();

           

            // Поиск кладовщика товара
            Console.WriteLine(" Поиск кладовщика товара 'Болты М8':");
            Storekeeper sk = FindStorekeeper("Болты М8", items, storekeepers);
            if (sk != null)
                Console.WriteLine($"   Найден: {sk.GetInfo()}");
            else
                Console.WriteLine("   Не найдено — null");

            Console.WriteLine();

            //  Поиск раздела товара
            Console.WriteLine(" Поиск раздела товара 'Болты М8':");
            Section sec = FindSection("Болты М8", items, sections);
            if (sec != null)
                Console.WriteLine($"   Найден: {sec.GetInfo()}");
            else
                Console.WriteLine("   Не найдено — null");

            Console.WriteLine();

            // Общее количество товаров
            Console.WriteLine("Общее количество всех товаров на складе:");
            int allth = GetSummAllth(items);
            Console.WriteLine($"Общее количество: {allth} шт.");

            Console.WriteLine();

            //  Товары ниже порога
            int threshold = 100;
            Console.WriteLine($" Товары с остатком ниже {threshold} шт.:");
            List<Item> items_low = GetItemsBelowThreshold(items, threshold);
            foreach (var item in items_low)
            {
                Console.WriteLine($"   - {item.GetInfo()}");
            }

            Console.WriteLine();
            // Вывод всех товаров с расширенной информацией
            Console.WriteLine(" Полный список товаров:");
            PrintAllItems(items, sections, storekeepers);

            Console.ReadLine();
        }

        // Поиск кладовщика, отвечающего за указанный товар
        public static Storekeeper FindStorekeeper(string itemName, List<Item> items, List<Storekeeper> storekeepers)
        {
            Item foundItem = null;
            // Ищем товар по названию
            foreach (var item in items)
            {
                if (item.Name == itemName)
                {
                    foundItem = item;
                    break;
                }
            }

            if (foundItem == null) return null;

            // По найденному StorekeeperId ищем самого кладовщика
            foreach (var sk in storekeepers)
            {
                if (sk.Id == foundItem.StorekeeperId)
                {
                    return sk;
                }
            }

            return null;
        }

        //  Поиск секции
        public static Section FindSection(string itemName, List<Item> items, List<Section> sections)
        {
            Item foundItem = null;
            foreach (var item in items)
            {
                if (item.Name == itemName)
                {
                    foundItem = item;
                    break;
                }
            }

            if (foundItem == null) return null;

            // Ищем секцию по SectionId
            foreach (var sec in sections)
            {
                if (sec.Id == foundItem.SectionId)
                {
                    return sec;
                }
            }

            return null;
        }

        //  Расчет суммарного количества всех единиц товаров
        public static int GetSummAllth(List<Item> items)
        {
            if (items == null || items.Count == 0) return 0;

            int sum = 0;
            foreach (var item in items)
            {
                sum += item.Quantity;
            }
            return sum;
        }

        //  Фильтрация товаров, у которых количество меньше порога
        public static List<Item> GetItemsBelowThreshold(List<Item> items, int threshold)
        {
            List<Item> result = new List<Item>();
            foreach (var item in items)
            {
                if (item.IsLowStock(threshold))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //  Форматированный вывод всех товаров с привязанными именами секций и кладовщиков
        public static void PrintAllItems(List<Item> items, List<Section> sections, List<Storekeeper> storekeepers)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("-");
                return;
            }

            foreach (var item in items)
            {
                // Находим связанную секцию
                string sectionName = "-";
                foreach (var sec in sections)
                {
                    if (sec.Id == item.SectionId)
                    {
                        sectionName = sec.Name;
                        break;
                    }
                }

                // Находим связанного кладовщика
                string storekeeperName = "-";
                foreach (var sk in storekeepers)
                {
                    if (sk.Id == item.StorekeeperId)
                    {
                        storekeeperName = sk.FullName;
                        break;
                    }
                }

                Console.WriteLine($"{item.GetInfo()} — кладовщик {storekeeperName}, секция \"{sectionName}\"");
            }
        }
    }
}
