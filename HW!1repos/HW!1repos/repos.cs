using HW_1repos;

using System;
using System.Collections.Generic;
using System.Text;

namespace HW_1repos
{

    public class InMemoryRepository
    {
        private List<Section> _sections;
        private List<Storekeeper> _storekeepers;
        private List<Item> _items;
        public InMemoryRepository()
        {
            // Инициализируем тестовый список секций
            _sections = new List<Section>
            {
                new Section { Id = 1, Name = "Метизы", Area = 300 },
                new Section { Id = 2, Name = "Сантехника", Area = 150 },
                new Section { Id = 3, Name = "Электротовары", Area = 250 }
            };

            // Инициализируем тестовый список кладовщиков
            _storekeepers = new List<Storekeeper>
            {
                new Storekeeper { Id = 1, FullName = "Петров П.П.", Shift = "Утренняя", Experience = 5 },
                new Storekeeper { Id = 2, FullName = "Иванов И.И.", Shift = "Вечерняя", Experience = 2 },
                new Storekeeper { Id = 3, FullName = "Сидоров С.С.", Shift = "Утренняя", Experience = 10 }
            };

            // Инициализируем тестовый список товаров
            _items = new List<Item>
            {
                new Item { Id = 1, Name = "Болты М8", SectionId = 1, StorekeeperId = 1, Quantity = 1000, Price = 5m },
                new Item { Id = 2, Name = "Гайки М8", SectionId = 1, StorekeeperId = 1, Quantity = 50, Price = 3m },
                new Item { Id = 3, Name = "Смеситель", SectionId = 2, StorekeeperId = 2, Quantity = 15, Price = 2500m },
                new Item { Id = 4, Name = "Кабель ВВГ", SectionId = 3, StorekeeperId = 3, Quantity = 500, Price = 80m }
            };
        }

        public List<Section> GetSections() => _sections;
        public List<Storekeeper> GetStorekeepers() => _storekeepers;
        public List<Item> GetItems() => _items;
    }
}

