using ProjectDumpTruck.Drawnings;

namespace ProjectDumpTruck.CollectionGenericObjects;

public abstract class AbstractCompany
{
    /// <summary> 
    /// Размер места (ширина) 
    /// </summary> 
    protected readonly int _placeSizeWidth;

    /// <summary> 
    /// Размер места (высота) 
    /// </summary> 
    protected readonly int _placeSizeHeight;

    /// <summary> 
    /// Ширина окна 
    /// </summary> 
    protected readonly int _pictureWidth;

    /// <summary> 
    /// Высота окна 
    /// </summary> 
    protected readonly int _pictureHeight;

    /// <summary> 
    /// Коллекция 
    /// </summary> 
    protected ICollectionGenericObjects<DrawningCar> _collection;

    /// <summary> 
    /// Конструктор 
    /// </summary> 
    /// <param name="pictureWidth">Ширина окна</param> 
    /// <param name="pictureHeight">Высота окна</param> 
    /// <param name="placeSizeWidth">Размер места (ширина)</param> 
    /// <param name="placeSizeHeight">Размер места (высота)</param> 
    /// <param name="collection">Коллекция</param> 
    public AbstractCompany(int pictureWidth, int pictureHeight, int placeSizeWidth, int placeSizeHeight, ICollectionGenericObjects<DrawningCar> collection)
    {
        _pictureWidth = pictureWidth;
        _pictureHeight = pictureHeight;
        _placeSizeWidth = placeSizeWidth;
        _placeSizeHeight = placeSizeHeight;
        _collection = collection;
        _collection.MaxCount = CalcMaxCount();
    }

    /// <summary> 
    /// Перегрузка оператора сложения для класса 
    /// </summary> 
    /// <param name="company">Компания</param> 
    /// <param name="car">Добавляемый объект</param> 
    /// <returns>Компания с добавленным объектом</returns> 
    public static int operator +(AbstractCompany company, DrawningCar car) => company._collection.InsertObject(car);

    /// <summary> 
    /// Перегрузка оператора удаления для класса 
    /// </summary> 
    /// <param name="company">Компания</param> 
    /// <param name="position">Номер удаляемого объекта</param> 
    /// <returns>Компания с удалённым объектом</returns> 
    public static DrawningCar? operator -(AbstractCompany company, int position) => company._collection.RemoveObject(position);

    /// <summary> 
    /// Получение случайного объекта из коллекции 
    /// </summary> 
    /// <returns>Объект из коллекции</returns> 
    public DrawningCar? GetRandomObject()
    {
        Random random = new();
        int maxCount = CalcMaxCount();
        DrawningCar? drawningCar = null;
        int counter = 10;
        while (drawningCar is null)
        {
            drawningCar = _collection.GetObject(random.Next(0, maxCount));
            counter--;
            if (counter == 0)
            {
                break;
            }
        }

        return drawningCar;
    }

    /// <summary> 
    /// Вывод всей коллекции 
    /// </summary> 
    /// <returns></returns> 
    public Bitmap? Show()
    {
        Bitmap bitmap = new(_pictureWidth, _pictureHeight);
        Graphics graphics = Graphics.FromImage(bitmap);
        DrawBackground(graphics);
        DrawObjects(graphics);
        return bitmap;
    }

    /// <summary> 
    /// Вывод заднего фона 
    /// </summary> 
    /// <param name="g"></param> 
    protected abstract void DrawBackground(Graphics g);

    /// <summary> 
    /// Расстановка и прорисовка объектов 
    /// </summary> 
    /// <param name="g"></param> 
    protected abstract void DrawObjects(Graphics g);

    /// <summary> 
    /// Вычисление максимального количества элементов, который можно разместить в окне
    /// </summary> 
    private int CalcMaxCount() => (int)(Math.Truncate((double)_pictureWidth / _placeSizeWidth) * Math.Truncate((double)_pictureHeight / _placeSizeHeight));
}
