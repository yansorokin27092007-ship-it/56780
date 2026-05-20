namespace WinFormsApp2
{
	/// <summary>
	/// Полотно для самосвала
	/// </summary>
	public class CanvasForTruck
	{
		/// <summary>
		/// Объект для прорисовки
		/// </summary>
		private DrawningTruck? _drawningTruck;

		/// <summary>
		/// Ширина полотна
		/// </summary>
		private int? _canvasWidth;

		/// <summary>
		/// Высота полотна
		/// </summary>
		private int? _canvasHeight;

		/// <summary>
		/// Установка границ поля
		/// </summary>
		public void SetPictureSize(int width, int height)
		{
			_canvasWidth = width;
			_canvasHeight = height;
		}

		/// <summary>
		/// Вставить самосвал
		/// </summary>
		public bool InsertTruck(DrawningTruck truck)
		{
			if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
				return false;

			if (truck.DrawingWidth > _canvasWidth || truck.DrawingHeight > _canvasHeight)
				return false;

			_drawningTruck = truck;
			return true;
		}

		/// <summary>
		/// Установка позиции самосвала
		/// </summary>
		public void SetTruckPosition(int x, int y)
		{
			if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningTruck is null)
				return;

			// Проверка выхода за границы
			if (x < 0) x = 0;
			if (y < 0) y = 0;
			if (x + _drawningTruck.DrawingWidth > _canvasWidth)
				x = _canvasWidth.Value - _drawningTruck.DrawingWidth;
			if (y + _drawningTruck.DrawingHeight > _canvasHeight)
				y = _canvasHeight.Value - _drawningTruck.DrawingHeight;

			_drawningTruck.SetPosition(x, y);
		}

		/// <summary>
		/// Перемещение самосвала
		/// </summary>
		public bool MoveTransport(DirectionType direction)
		{
			if (!_canvasWidth.HasValue || !_canvasHeight.HasValue
				|| _drawningTruck is null
				|| !_drawningTruck.PosX.HasValue || !_drawningTruck.PosY.HasValue
				|| !_drawningTruck.TruckStep.HasValue)
			{
				return false;
			}

			switch (direction)
			{
				case DirectionType.Left:
					if (_drawningTruck.PosX.Value - _drawningTruck.TruckStep.Value > 0)
					{
						_drawningTruck.MoveLeft();
						return true;
					}
					break;

				case DirectionType.Up:
					if (_drawningTruck.PosY.Value - _drawningTruck.TruckStep.Value > 0)
					{
						_drawningTruck.MoveUp();
						return true;
					}
					break;

				case DirectionType.Right:
					if (_drawningTruck.PosX.Value + _drawningTruck.TruckStep.Value
						+ _drawningTruck.DrawingWidth < _canvasWidth)
					{
						_drawningTruck.MoveRight();
						return true;
					}
					break;

				case DirectionType.Down:
					if (_drawningTruck.PosY.Value + _drawningTruck.TruckStep.Value
						+ _drawningTruck.DrawingHeight < _canvasHeight)
					{
						_drawningTruck.MoveDown();
						return true;
					}
					break;
			}

			return false;
		}

		/// <summary>
		/// Отрисовка полотна
		/// </summary>
		public Bitmap? DrawCanvas()
		{
			if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
				return null;

			Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
			Graphics graphics = Graphics.FromImage(bmp);
			_drawningTruck?.DrawTransport(graphics);
			return bmp;
		}
	}
}
