using ProjectDumpTruck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2;

namespace ProjectDumpTruck.Drawnings;
public class CanvasForCar
{
    /// <summary> 
    /// Поле-объект для прорисовки объекта 
    /// </summary> 
    private DrawningCar? _drawningCar;

    /// <summary> 
    /// Ширина полотна 
    /// </summary>
    private int? _canvasWidth;

    /// <summary> 
    /// Высота полотна 
    /// </summary> 
    private int? _canvasHeight;

    /// <summary>
    /// Прорисовываемый объект
    /// </summary>
    public DrawningCar? DrawningCar => _drawningCar;

    /// <summary> 
    /// Установка границ поля 
    /// </summary> 
    /// <param name="width">Ширина поля</param> 
    /// <param name="height">Высота поля</param> 
    public void SetPictureSize(int width, int height)
    {
        _canvasWidth = width;
        _canvasHeight = height;
    }

    /// <summary> 
    /// Вставить объект "самосвал" 
    /// </summary> 
    /// <param name="car">Объект "самосвала"</param> 
    /// <returns>true - объект сохранен, false - объект нельзя поместить в имеющиеся размеры формы</returns>
    public bool InsertCar(DrawningCar car)
    {
        // если не удается - завершаем работу метода 
        if (car == null)
        {
            return false;
        }

        // если размеры форм есть, то проверяем, что по размерам объект можно поместить в поле
        if (car.DrawningCarWidth > _canvasWidth.Value || car.DrawningCarHeight > _canvasHeight.Value)
        {
            return false;
        }

        // если размеры форм не заданы, то завершаем работу метода 
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
        {
            return false;
        }

        // если можно, то сохраняем ссылку на объект 
        _drawningCar = car;
        return true;
    }

    /// <summary> 
    /// Установка позиции объекта 
    /// </summary> 
    /// <param name="x">Координата X</param> 
    /// <param name="y">Координата Y</param> 
    public void SetCarPosition(int x, int y)
    {
        // если размеры форм не заданы или не задан объект DrawningCar, то завершаем работу метода
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningCar is null)
        {
            return;
        }

        int correctedX = x;
        int correctedY = y;

        // Проверка левой границы
        if (correctedX < 0)
        {
            correctedX = 0;
        }
        // Проверка правой границы 
        else if (correctedX + _drawningCar.DrawningCarWidth > _canvasWidth.Value)
        {
            correctedX = _canvasWidth.Value - _drawningCar.DrawningCarWidth;
        }

        //Проверка нижней границы
        if (correctedY < 0)
        {
            correctedY = 0;
        }

        //Проверка верхней границы
        else if (correctedY + _drawningCar.DrawningCarHeight > _canvasHeight.Value)
        {
            correctedY = _canvasHeight.Value - _drawningCar.DrawningCarHeight;
        }
        _drawningCar.SetPosition(correctedX, correctedY);
    }

    /// <summary> 
    /// Изменение направления перемещения 
    /// </summary> 
    /// <param name="direction">Направление</param> 
    /// <returns>true - перемещение выполнено, false - перемещение невозможно</returns>
    public bool MoveTransport(DirectionType direction)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningCar is null || !_drawningCar.PosX.HasValue || !_drawningCar.PosY.HasValue ||
      !_drawningCar.CarStep.HasValue)
        {
            return false;
        }
        bool hasTent = _drawningCar is DrawningDumpTruck dumpTruck && dumpTruck.HasTent;
        switch (direction)
        {

            //влево 
            case DirectionType.Left:
                if (_drawningCar.PosX.Value - _drawningCar.CarStep.Value > 0)
                {
                    _drawningCar.MoveLeft();
                    return true;
                }
                break;

            //вверх 
            case DirectionType.Up:
                if (hasTent)
                {
                    if (_drawningCar.PosY.Value - _drawningCar.CarStep.Value - 15 >= 0)
                    {
                        _drawningCar.MoveUp();
                        return true;
                    }
                }
                else
                {

                    if (_drawningCar.PosY.Value - _drawningCar.CarStep.Value > 0)
                    {
                        _drawningCar.MoveUp();
                        return true;
                    }
                }
                break;

            // вправо 
            case DirectionType.Right:
                if (_drawningCar.PosX.Value + _drawningCar.CarStep.Value + _drawningCar.DrawningCarWidth < _canvasWidth.Value)
                {
                    _drawningCar.MoveRight();
                    return true;
                }
                break;

            //вниз 
            case DirectionType.Down:
                if (_drawningCar.PosY.Value + _drawningCar.CarStep.Value + _drawningCar.DrawningCarHeight <= _canvasHeight.Value)
                {
                    _drawningCar.MoveDown();
                    return true;
                }

                break;
        }
        return false;
    }

    /// <summary> 
    /// Прорисовка полотна 
    /// </summary> 
    /// <returns></returns> 
    public Bitmap? DrawCanvas()
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
        {
            return null;
        }

        Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
        Graphics graphics = Graphics.FromImage(bmp);
        _drawningCar?.DrawTransport(graphics);
        return bmp;
    }
}
