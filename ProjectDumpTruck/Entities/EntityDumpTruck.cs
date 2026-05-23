using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDumpTruck.Entities;

/// <summary>
/// Класс-сущность "Самосвал"
/// </summary>
public class EntityDumpTruck : EntityCar
{ 
    /// <summary>
    /// Дополнительный цвет (для опциональных элементов)
    /// </summary>
    public Color AdditionalColor { get; init; }

    /// <summary>
    /// Признак (опция) наличия кузова
    /// </summary>
    public bool Body { get; init; }

    /// <summary>
    /// Признак (опция) наличия тента
    /// </summary>
    public bool  Tent { get; init; }


    /// <summary>
    /// Конструктор для инициализации полей объекта-класса самосвала
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="weight"></param>
    /// <param name="bodyColor"></param>
    /// <param name="additionalColor"></param>
    /// <param name="body"></param>
    /// <param name="tent"></param>
    public EntityDumpTruck(int speed, double weight, Color bodyColor, Color additionalColor, bool body, bool tent) : base (speed, weight, bodyColor)
    {
        AdditionalColor = additionalColor;
        Body = body;
        Tent = tent;
    }
}
