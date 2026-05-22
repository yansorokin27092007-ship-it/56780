namespace ProjectDumpTruck.CollectionGenericObjects;

/// <summary>
/// Параметризованный набор объектов
/// </summary>
/// <typeparam name="T"></typeparam>
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T>
 where T : class
{
    /// <summary> 
    /// Массив объектов, которые храним 
    /// </summary> 
    private T?[] _collection;

    public int CountObjects
    {
        get
        {
            int count = 0;
            for (int i = 0; i < _collection.Length; ++i)
            {
                if (_collection[i] is not null)
                {
                    count++;
                }
            }
            return count;
        }
    }

    public int MaxCount
    {
        set
        {
            if (value > 0)
            {
                Array.Resize(ref _collection, value);
            }
        }
    }

    /// <summary> 
    /// Конструктор 
    /// </summary> 
    public MassiveGenericObjects()
    {
        _collection = [];
    }

    //Проверка, что позиция не выходит за границы массива 
    public T? GetObject(int position)
    {
        if (position >= _collection.Length)
        {
            return null;
        }
        return _collection[position];
    }

    //вставка в начало коллекции
    public int InsertObject(T obj)
    {
        if (_collection.Length == 0)
        {
            return -1;
        }

        for (int i = 0; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return i;
            }
        }
        return -1;
    }

    // проверка, что позиция не выходит за границы массива 
    // проверка, что элемент массива по этой позиции пустой, если пустой, то вставляем туда
    // если нет, то ищется свободное место после этой позиции и идет вставка туда
    // если нет такого места после, то ищется свободное место перед позицией до начала массива и идет вставка туда
    // если в массиве нет пустых мест, то результатом операций будет false
    public int InsertObject(T obj, int position)
    {
        if (position >= _collection.Length)
        {
            return -1;
        }

        // Проверка, что элемент массива по этой позиции пустой
        if (_collection[position] is null)
        {
            _collection[position] = obj;
            return position;
        }

        // Если занято - ищем свободное место ПОСЛЕ этой позиции
        for (int i = position + 1; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return i;
            }
        }

        // Если после нет - ищем свободное место ДО этой позиции
        for (int i = position - 1; i >= 0; i--)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return i;
            }
        }
        // Если в массиве нет пустых мест
        return -1;
    }

    // проверка, что позиция не выходит за границы массива 
    // удаление объекта из массива, присвоив элементу массива значение null
    public T? RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Length)
        {
            return null;
        }

        T? obj = _collection[position];
        _collection[position] = null;
        return obj;
    }
}