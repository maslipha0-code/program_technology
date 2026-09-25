
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_1repos 
{ 

        public class CsvRepository
        {
            private string _basePath;

            public CsvRepository(string basePath)
            {
                _basePath = basePath;
            }

            // Загрузка секций из файла
            public List<Section> GetSections()
            {
                List<Section> result = new List<Section>();
                string filePath = Path.Combine(_basePath, "sections.csv");

                if (!File.Exists(filePath)) return result;

                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length < 2) return result; // Если только заголовок или пусто

                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;

                    string[] parts = lines[i].Split(',');
                    if (parts.Length >= 3)
                    {
                        Section s = new Section();
                        s.Id = int.Parse(parts[0]);
                        s.Name = parts[1];
                        s.Area = int.Parse(parts[2]);
                        result.Add(s);
                    }
                }

                return result;
            }

            // Загрузка кладовщиков из файла
            public List<Storekeeper> GetStorekeepers()
            {
                List<Storekeeper> result = new List<Storekeeper>();
                string filePath = Path.Combine(_basePath, "storekeepers.csv");

                if (!File.Exists(filePath)) return result;

                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length < 2) return result;

                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split(',');
                if (parts.Length >= 4)
                {
                    Storekeeper sk = new Storekeeper();
                    sk.Id = int.Parse(parts[0]);
                    sk.FullName = parts[1];
                    sk.Shift = parts[2];
                    sk.Experience = int.Parse(parts[3]);
                    result.Add(sk);
                }
            }

            return result;
        }

        // Загрузка товаров из файла
        public List<Item> GetItems()
        {
            List<Item> result = new List<Item>();
            string filePath = Path.Combine(_basePath, "items.csv");

            if (!File.Exists(filePath)) return result;

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split(',');
                if (parts.Length >= 6)
                {
                    Item item = new Item();
                    item.Id = int.Parse(parts[0]);
                    item.Name = parts[1];
                    item.SectionId = int.Parse(parts[2]);
                    item.StorekeeperId = int.Parse(parts[3]);
                    item.Quantity = int.Parse(parts[4]);
                    item.Price = decimal.Parse(parts[5]);
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
