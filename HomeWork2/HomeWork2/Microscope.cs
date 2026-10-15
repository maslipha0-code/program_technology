using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryApp
{
   
    public class Microscope : LabEquipment, ICalibratable
    {
        // Автосвойство для увеличения микроскопа.

        public int Magnification { get; set; }

        // Конструктор полный для микроскопа.
        
        public Microscope(int id, string name, double accuracy, int magnification)
            : base(id, name, accuracy)
        {
            Magnification = magnification;
        }

        // Конструктор по умолчанию для микроскопа.
      
        public Microscope(string name) : base(name)
        {
            Magnification = 100;
        }
        // определяет, является ли микроскоп мощным (увеличение больше 1000).
     
        public bool IsHighPower => Magnification > 1000;

        public override void Measure()
        {
            Console.WriteLine($"{Name} измеряет образец");
        }
       
        public void Calibrate()
        {
            Console.WriteLine($"{Name} откалиброван");
        }

      
        //  вывод информации об объекте.
       
        public override string ToString()
        {
            return $"[Микроскоп] {Name}, точность ={Accuracy}, статус: {Status}\n" +
                   $"точный? : {IsPrecise}";
        }
    }
}
