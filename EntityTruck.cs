namespace WinFormsApp2


{
	/// <summary>
	/// Класс-сущность "Самосвал"
	/// </summary>
	public class EntityTruck
	{
		/// <summary>
		/// Скорость
		/// </summary>
		public int Speed { get; private set; }

		/// <summary>
		/// Вес
		/// </summary>
		public double Weight { get; private set; }

		/// <summary>
		/// Основной цвет
		/// </summary>
		public Color BodyColor { get; private set; }

		/// <summary>
		/// Количество колёс
		/// </summary>
		public WheelCount Wheels { get; private set; }

		/// <summary>
		/// Шаг перемещения
		/// </summary>
		public double Step => Speed * 100 / Weight;

		/// <summary>
		/// Инициализация полей
		/// </summary>
		public void Init(int speed, double weight, Color bodyColor, WheelCount wheels)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
			Wheels = wheels;
		}
	}
}