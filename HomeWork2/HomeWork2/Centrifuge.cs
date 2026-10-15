using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryApp
{
    /// <summary>
    /// Класс Центрифуга, наследующий LabEquipment.
    /// </summary>
    public class Centrifuge : LabEquipment
    {
        /// <summary>
        /// Автосвойство для количества оборотов в минуту (рпм).
        /// </summary>
        public int Rpm { get; set; }

        /// <summary>
        /// Конструктор центрифуги.
        /// </summary>
        public Centrifuge(int id, string name, double accuracy, int rpm)
            : base(id, name, accuracy)
        {
            Rpm = rpm;
        }

        /// <summary>
        /// является ли центрифуга скоростной (рпм > 10000).
        /// </summary>
        public bool IsFast => Rpm > 10000;

        public override void Measure()
        {
            Console.WriteLine($"{Name} измеряет образец");
        }

    
        public override string ToString()
        {
            return $"[Центрифуга] {Name}, рпм={Rpm}, статус: {Status}\n" +
                   $"точный?: {IsPrecise}";
        }
    }
}
