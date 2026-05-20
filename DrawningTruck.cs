namespace WinFormsApp2

{
	/// <summary>
	/// Класс, отвечающий за прорисовку и перемещение самосвала
	/// </summary>
	public class DrawningTruck
	{
		/// <summary>
		/// Объект-сущность "Самосвал"
		/// </summary>
		private EntityTruck? _entityTruck;

		/// <summary>
		/// Левая координата прорисовки
		/// </summary>
		private int? _startPosX;

		/// <summary>
		/// Верхняя координата прорисовки
		/// </summary>
		private int? _startPosY;

		/// <summary>
		/// Ширина прорисовки
		/// </summary>
		private readonly int _drawningWidth = 130;

		/// <summary>
		/// Высота прорисовки
		/// </summary>
		private readonly int _drawningHeight = 85;

		// Свойства для доступа из CanvasForTruck
		public int? PosX => _startPosX;
		public int? PosY => _startPosY;
		public double? TruckStep => _entityTruck?.Step;
		public int DrawingWidth => _drawningWidth;
		public int DrawingHeight => _drawningHeight;

		/// <summary>
		/// Инициализация свойств
		/// </summary>
		public void Init(int speed, double weight, Color bodyColor, WheelCount wheels)
		{
			_entityTruck = new EntityTruck();
			_entityTruck.Init(speed, weight, bodyColor, wheels);
			_startPosX = null;
			_startPosY = null;
		}

		/// <summary>
		/// Установка позиции
		/// </summary>
		public void SetPosition(int x, int y)
		{
			_startPosX = x;
			_startPosY = y;
		}

		/// <summary>
		/// Сдвиг влево
		/// </summary>
		public void MoveLeft()
		{
			if (_entityTruck is null || !_startPosX.HasValue)
				return;
			_startPosX -= (int)_entityTruck.Step;
		}

		/// <summary>
		/// Сдвиг вправо
		/// </summary>
		public void MoveRight()
		{
			if (_entityTruck is null || !_startPosX.HasValue)
				return;
			_startPosX += (int)_entityTruck.Step;
		}

		/// <summary>
		/// Сдвиг вверх
		/// </summary>
		public void MoveUp()
		{
			if (_entityTruck is null || !_startPosY.HasValue)
				return;
			_startPosY -= (int)_entityTruck.Step;
		}

		/// <summary>
		/// Сдвиг вниз
		/// </summary>
		public void MoveDown()
		{
			if (_entityTruck is null || !_startPosY.HasValue)
				return;
			_startPosY += (int)_entityTruck.Step;
		}

		/// <summary>
		/// Прорисовка самосвала
		/// </summary>
		public void DrawTransport(Graphics g)
		{
			if (_entityTruck is null || !_startPosX.HasValue || !_startPosY.HasValue)
				return;

			int x = _startPosX.Value;
			int y = _startPosY.Value;

			Pen pen = new(Color.Black);

			// --- КАБИНА (левая часть) ---
			Brush cabBrush = new SolidBrush(Color.LightGray);
			g.FillRectangle(cabBrush, x, y + 25, 40, 45);
			g.DrawRectangle(pen, x, y + 25, 40, 45);

			// Окно кабины
			Brush glassBrush = new SolidBrush(Color.LightBlue);
			g.FillRectangle(glassBrush, x + 5, y + 30, 30, 15);
			g.DrawRectangle(pen, x + 5, y + 30, 30, 15);

			// --- КУЗОВ (правая часть) ---
			Brush bodyBrush = new SolidBrush(_entityTruck.BodyColor);
			g.FillRectangle(bodyBrush, x + 40, y + 5, 85, 65);
			g.DrawRectangle(pen, x + 40, y + 5, 85, 65);

			// --- ТЕНТ (линия или полоска сверху кузова) ---
			Brush tentBrush = new SolidBrush(Color.DarkGray);
			g.FillRectangle(tentBrush, x + 45, y, 75, 10);
			g.DrawRectangle(pen, x + 45, y, 75, 10);

			// --- КОЛЁСА ---
			int wheelRadius = 10;
			int wheelY = y + 65;

			Brush wheelBrush = new SolidBrush(Color.Black);

			// Переднее колесо
			g.FillEllipse(wheelBrush, x + 5, wheelY, wheelRadius * 2, wheelRadius * 2);
			g.DrawEllipse(pen, x + 5, wheelY, wheelRadius * 2, wheelRadius * 2);

			// Заднее колесо
			g.FillEllipse(wheelBrush, x + 100, wheelY, wheelRadius * 2, wheelRadius * 2);
			g.DrawEllipse(pen, x + 100, wheelY, wheelRadius * 2, wheelRadius * 2);

			// Доп. колёса при 3 или 4
			if (_entityTruck.Wheels == WheelCount.Three || _entityTruck.Wheels == WheelCount.Four)
			{
				g.FillEllipse(wheelBrush, x + 50, wheelY, wheelRadius * 2, wheelRadius * 2);
				g.DrawEllipse(pen, x + 50, wheelY, wheelRadius * 2, wheelRadius * 2);
			}

			if (_entityTruck.Wheels == WheelCount.Four)
			{
				g.FillEllipse(wheelBrush, x + 75, wheelY, wheelRadius * 2, wheelRadius * 2);
				g.DrawEllipse(pen, x + 75, wheelY, wheelRadius * 2, wheelRadius * 2);
			}
		}
	}
}
