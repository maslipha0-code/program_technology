using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryApp
{
    /// <summary>
    /// Интерфейс для оборудования, поддерживающего калибровку.
    /// </summary>
    public interface ICalibratable
    {
        //Выполняет калибровку устройства.
        void Calibrate();
    }
}
