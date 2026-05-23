namespace ProjectDumpTruck.CollectionGenericObjects;

/// <summary>
/// Интерфейс описания действий для набора хранимых объектов
/// </summary> 
public interface ICollectionGenericObjects<T>
    where T : class
{
    /// <summary>
    /// Количество объектов в коллекции
    /// </summary>
    int CountObjects {  get; }

    /// <summary>
    /// Установка максимального количества элементов
    /// </summary>
    int MaxCount { set; }

    /// <summary>
    /// Получения объекта по позиции
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    T? GetObject(int position);

    /// <summary> 
    /// Добавление объекта в коллекцию 
    /// </summary> 
    /// <param name="obj">Добавляемый объект</param> 
    /// <returns>true - вставка прошлааааа удачно, false - вставка не удалась</returns>
    int InsertObject(T obj);

    /// <summary> 
    /// Добавление объекта в кооллекцию на конкретную позицию 
    /// </summary> 
    /// <param name="obj">Добавляемый объект</param> 
    /// <param name="position">Позиция</param> 
    /// <returns>true - вставка прошла удачно, false - вставка не удалась</returns>
    int InsertObject(T obj, int position);

    /// <summary> 
    /// Удаление объекта из коллекции с конкретной позиции 
    /// </summary> 
    /// <param name="position">Позиция</param> 
    /// <returns>true - удаление прошло удачно, false - удаление не удалось</returns>
    T? RemoveObject(int position);
}
