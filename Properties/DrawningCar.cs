using ProjectDumpTruck.Entities;

namespace ProjectDumpTruck.Drawnings;
/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawningCar
{
    /// <summary>
    /// Класс-сущность
    /// </summary>
    protected EntityCar? _entityCar;

    /// <summary>
    /// Левая координата прорисовки самосвала
    /// </summary>
    protected int? _startPosX;

    /// <summary>
    /// Верхняя координата прорисовки самосвала
    /// </summary>
    protected int? _startPosY;

    /// <summary>
    /// Ширина прорисовки самосвала
    /// </summary>
    private readonly int _drawningCarWidth = 90;

    /// <summary>
    /// Высота прорисовки самосвала
    /// </summary>
    private readonly int _drawningCarHeight = 50;

    // <summary>
    /// Левая координата прорисовки самосвала
    /// </summary>
    public int? PosX => _startPosX;
    /// <summary>
    /// Верхняя координата прорисовки самосвала
    /// </summary>
    public int? PosY => _startPosY;

    /// <summary>
    /// Шаг перемещения
    /// </summary>
    public double? CarStep => _entityCar?.Step;

    /// <summary>
    /// Ширина прорисовки самосвала
    /// </summary>
    public int DrawningCarWidth => _drawningCarWidth;

    /// <summary>
    /// Высота прорисовки самосвала
    /// </summary>
    public int DrawningCarHeight => _drawningCarHeight;

    /// <summary>
    /// Конструктор без параметров для инициализации простых полей
    /// </summary>
    private DrawningCar()
    {
        _startPosX = null;
        _startPosY = null;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    public DrawningCar(int speed, double weight, Color bodyColor) : this()
    {
        _entityCar = new EntityCar(speed, weight, bodyColor);
    }

    /// <summary>
    /// Конструктор для изменения константных полей
    /// </summary>
    /// <param name="drawningCarWidth"></param>
    /// <param name="drawningCarHeight"></param>
    protected DrawningCar(int drawningCarWidth, int drawningCarHeight) : this()
    {
        _drawningCarWidth = drawningCarWidth;
        _drawningCarHeight = drawningCarHeight;
    }

    /// <summary>
    /// Установка позиции
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    /// <summary>
    /// Сдвиг изображения влево
    /// </summary>
    public void MoveLeft()
    {
        if (_entityCar is null || !_startPosX.HasValue)
        {
            return;
        }
        _startPosX -= (int)_entityCar.Step;
    }

    /// <summary>
    /// Сдвиг изображения вправо
    /// </summary>
    public void MoveRight()
    {
        if (_entityCar is null || !_startPosX.HasValue)
        {
            return;
        }
        _startPosX += (int)_entityCar.Step;
    }

    /// <summary>
    /// Сдвиг изображения вверх
    /// </summary>
    public void MoveUp()
    {
        if (_entityCar is null || !_startPosY.HasValue)
        {
            return;
        }
        _startPosY -= (int)_entityCar.Step;
    }

    /// <summary>
    /// Сдвиг изображения вниз
    /// </summary>
    public void MoveDown()
    {
        if (_entityCar is null || !_startPosY.HasValue)
        {
            return;
        }
        _startPosY += (int)_entityCar.Step;
    }

    /// <summary>
    /// Прорисовка объекта
    /// </summary>
    /// <param name="g"></param>
    public virtual void DrawTransport(Graphics g)
    {
        if (_entityCar is null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }

        int x = _startPosX.Value;
        int y = _startPosY.Value;
        Color bodyColor = _entityCar.BodyColor;

        // Кузов
        using (SolidBrush bodyBrush = new SolidBrush(bodyColor))
        {
            g.FillRectangle(bodyBrush, x, y + 20, 90, 15);
        }

        // Кабина 
        using (SolidBrush cabinBrush = new SolidBrush(Color.FromArgb(100, 150, 200)))
        {
            g.FillRectangle(cabinBrush, x + 60, y, 30, 20);
        }

        // Колёса 
        using (SolidBrush wheelBrush = new SolidBrush(Color.Black))
        {
            g.FillEllipse(wheelBrush, x, y + 30, 20, 20);
            g.FillEllipse(wheelBrush, x + 27, y + 30, 20, 20);
            g.FillEllipse(wheelBrush, x + 70, y + 30, 20, 20);
        }


    }
}



