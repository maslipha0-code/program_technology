using System;
using System.Collections.Generic;

namespace LaboratoryApp
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // список 
            List<LabEquipment> equipmentList = new List<LabEquipment>
            {
                new Microscope(1, "Olympus ", 0.005, 1200),
                new Centrifuge(2, "Eppendorf", 0.05, 15000),
                new Spectrometer(3, "Thermo", 0.008, 250)
            };
            // Обход коллекции с применением полиморфизма и оператора 'is'
            foreach (var item in equipmentList)
            {
                Console.WriteLine(item.ToString());
                item.Measure();

                // Проверка 
                if (item is ICalibratable calibratableDevice)
                {
                    calibratableDevice.Calibrate();
                }
                else
                {
                    Console.WriteLine($"{item.Name} ERROR Calibrate");
                }
               
            }
        }
    }
}
