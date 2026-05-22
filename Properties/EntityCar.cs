using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDumpTruck.Entities;
/// <summary>
/// Класс-сущность "Самосвал"
/// </summary>
public class EntityCar
{
    /// <summary>
    /// Скорость
    /// </summary>
    public int Speed { get; init; }

    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; init; }

    /// <summary>
    /// Основной цвет
    /// </summary>
    public Color BodyColor { get; init; }

    /// <summary>
    /// Шаг перемещения объекта
    /// </summary>
    public double Step => Speed * 100 / Weight;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес автомобиля</param>
    /// <param name="bodyColor">Основной цвет</param>
    public EntityCar(int speed, double weight, Color bodyColor)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
    }
}

