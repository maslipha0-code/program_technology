using System;
using System.Collections.Generic;
using System.Text;
namespace LaboratoryApp
{
    /// <summary>
    /// Абстрактный базовый класс, описывающий лабораторное оборудование
    /// </summary>
    // абстрактный потому что он род класс с константн оборудованием 
    public abstract class LabEquipment
    {
        private int _id;// айди 

        public string Name { get; set; } // имя 

        public double Accuracy { get; set; }// точность 

        /// <summary>
        /// Статус оборудования с иниц по умолчанию 
        /// </summary>
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Ready;

        // является ли прибор высокоточным (точность меньше 0.01).
        
        public bool IsPrecise => Accuracy < 0.01;

        /// <summary>
        /// Основной конструктор с параметрами.
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <param name="accuracy">Точность</param>
        public LabEquipment(int id, string name, double accuracy)
        {
            _id = id;
            Name = name;
            Accuracy = accuracy;
        }

        /// <summary>
        /// Перегруженный конструктор, вызывающий основной через this(...) с дефолтными значениями (id = 0, accuracy = 1.0).
        /// </summary>
        /// <param name="name">Название оборудования</param>
        public LabEquipment(string name) : this(0, name, 1.0) { }

        /// <summary>
        /// Абстрактный метод оценки (измерения), подлежащий реализации в наследниках.
        /// </summary>
        public abstract void Measure();
    }
}
