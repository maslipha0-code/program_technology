using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryApp
{
   
    public class Spectrometer : LabEquipment, ICalibratable
    {
        // длина волны
        public double Wavelength { get; set; }

        /// <summary>
        /// Конструктор спектрометра.
        /// </summary>
        public Spectrometer(int id, string name, double accuracy, double wavelength)
            : base(id, name, accuracy)
        {
            Wavelength = wavelength;
        }

        /// <summary>
        ///работает ли в ультрафиолетовом диапазоне (меньше 380 нм).
        /// </summary>
        public bool IsUv => Wavelength < 380;

       
        public override void Measure()
        {
            Console.WriteLine($"{Name} измеряет образец");
        }

        public void Calibrate()
        {
            Console.WriteLine($"{Name} откалиброван");
        }

        public override string ToString()
        {
            return $"[спектометр] {Name}, длина волны={Wavelength}, статус: {Status}\n" +
                   $"точный? : {IsPrecise}";
        }
    }
}

