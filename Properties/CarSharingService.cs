
using ProjectDumpTruck.Drawnings;
using ProjectDumpTruck.CollectionGenericObjects;
namespace ProjectDumpTruck.CollectionGenericObjects
{
    /// <summary>
    /// Реализация компании-сервис каршеринга (автопарк)
    /// </summary>

    public class CarSharingService : AbstractCompany
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        /// <param name="collection"></param>
        public CarSharingService(int pictureWidth, int pictureHeight, ICollectionGenericObjects<DrawningCar> collection) : base(pictureWidth, pictureHeight, 110, 70, collection)
        {

        }
        protected override void DrawBackground(Graphics g)
        {
            g.Clear(Color.White);

            int cols = _pictureWidth / _placeSizeWidth;
            int rows = _pictureHeight / _placeSizeHeight;
            int offset = 40; // Отступ от краев

            using (Pen pen = new Pen(Color.Black, 1))
            {

                for (int col = 0; col <= cols; col++)
                {
                    int x = offset + col * _placeSizeWidth;
                    g.DrawLine(pen, x, offset, x, offset + rows * _placeSizeHeight);
                }

                // Рисуем горизонтальные линии с учетом отступа
                for (int row = 0; row <= rows; row++)
                {
                    int y = offset + row * _placeSizeHeight;
                    g.DrawLine(pen, offset, y, offset + cols * _placeSizeWidth, y);
                }
                pen.Dispose();
            }

        }

        protected override void DrawObjects(Graphics g)
        {
            int cols = _pictureWidth / _placeSizeWidth;
            int rows = _pictureHeight / _placeSizeHeight;
            int offset = 40;

            for (int i = 0; i < cols * rows; i++)
            {
                var obj = _collection.GetObject(i);
                if (obj == null) continue;

                int col = i % cols;
                int row = i / cols;

                // Вычисляем координаты ячейки с учетом отступа
                int cellX = offset + col * _placeSizeWidth;
                int cellY = offset + row * _placeSizeHeight;

                // Центрируем объект внутри ячейки
                int x = cellX + (_placeSizeWidth - obj.DrawningCarWidth) / 2;
                int y = cellY + (_placeSizeHeight - obj.DrawningCarHeight) / 2;

                obj.SetPosition(x, y);
                obj.DrawTransport(g);
            }
        }
    }
}




