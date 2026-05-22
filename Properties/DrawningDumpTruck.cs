using ProjectDumpTruck.Entities;

namespace ProjectDumpTruck.Drawnings;
/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта сущности
/// </summary>
public class DrawningDumpTruck : DrawningCar
{
    public bool HasTent => (_entityCar as EntityDumpTruck)?.Tent ?? false;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="weight"></param>
    /// <param name="bodyColor"></param>
    /// <param name="additionalColor"></param>
    /// <param name="body"></param>
    /// <param name="tent"></param>
    public DrawningDumpTruck(int speed, double weight, Color bodyColor, Color additionalColor, bool body, bool tent) : base(100, 68)
    {
        _entityCar = new EntityDumpTruck(speed, weight, bodyColor, additionalColor, body, tent);
    }
    public override void DrawTransport(Graphics g)
    {
        if (_entityCar is null || _entityCar is not EntityDumpTruck dumpTruck || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }
        int x = _startPosX.Value;
        int y = _startPosY.Value;
        Pen pen = new(Color.Black);
        Brush additionalBrush = new SolidBrush(dumpTruck.AdditionalColor);

        //кузов
        if (dumpTruck.Body)
        {
            using (SolidBrush bodyBrush = new SolidBrush(dumpTruck.BodyColor))
            {
                g.FillRectangle(bodyBrush, x, y + 30, 90, 25);
            }
        }
        _startPosX += 8;
        _startPosY += 18;
        base.DrawTransport(g);
        _startPosX -= 8;
        _startPosY -= 18;

        //тент
        if (dumpTruck.Tent)
        {
            using (SolidBrush tentBrush = new SolidBrush(dumpTruck.AdditionalColor))
            {
                g.FillRectangle(tentBrush, x, y + 5, 100, 10);
                g.FillRectangle(tentBrush, x + 15, y, 75, 10);
            }
        }
    }
}