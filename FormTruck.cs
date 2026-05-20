using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp2;

namespace ConsoleApp2
{
	public partial class FormTruck : Form
	{
		/// <summary>
		/// Полотно
		/// </summary>
		private readonly CanvasForTruck _canvas;

		/// <summary>
		/// Для проверки границ
		/// </summary>
		private DirectionType _checkBordersState;

		public FormTruck()
		{
			InitializeComponent();

			_canvas = new CanvasForTruck();
			_canvas.SetPictureSize(pictureBoxTruck.Width, pictureBoxTruck.Height);
			_checkBordersState = DirectionType.None;
		}

		/// <summary>
		/// Метод прорисовки самосвала
		/// </summary>
		private void Draw() => pictureBoxTruck.Image = _canvas.DrawCanvas();

		/// <summary>
		/// Обработка нажатия кнопки "Создать"
		/// </summary>
		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			Random random = new();
			DrawningTruck truck = new();

			WheelCount randomWheels = (WheelCount)random.Next(2, 5); // 2, 3, 4

			truck.Init(
				random.Next(100, 300),
				random.Next(1000, 3000),
				Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)),
				randomWheels
			);

			if (_canvas.InsertTruck(truck))
			{
				_canvas.SetTruckPosition(random.Next(10, 100), random.Next(10, 100));
				Draw();
			}
		}

		/// <summary>
		/// Перемещение объекта (кнопки навигации)
		/// </summary>
		private void ButtonMove_Click(object sender, EventArgs e)
		{
			string name = ((Button)sender)?.Name ?? string.Empty;
			DirectionType direction = DirectionType.None;

			switch (name)
			{
				case "buttonUp":
					direction = DirectionType.Up;
					break;
				case "buttonDown":
					direction = DirectionType.Down;
					break;
				case "buttonLeft":
					direction = DirectionType.Left;
					break;
				case "buttonRight":
					direction = DirectionType.Right;
					break;
			}

			if (_canvas.MoveTransport(direction))
			{
				Draw();
			}
		}

		/// <summary>
		/// Проверка выхода за границы
		/// </summary>
		private void ButtonCheckBorders_Click(object sender, EventArgs e)
		{
			Random random = new();

			switch (_checkBordersState)
			{
				case DirectionType.None:
				case DirectionType.Down:
					_canvas.SetTruckPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
					_checkBordersState = DirectionType.Left;
					break;
				case DirectionType.Left:
					_canvas.SetTruckPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
					_checkBordersState = DirectionType.Up;
					break;
				case DirectionType.Up:
					_canvas.SetTruckPosition(
						random.Next(10, 100) + pictureBoxTruck.Width,
						random.Next(10, 100));
					_checkBordersState = DirectionType.Right;
					break;
				case DirectionType.Right:
					_canvas.SetTruckPosition(
						random.Next(10, 100),
						random.Next(10, 100) + pictureBoxTruck.Height);
					_checkBordersState = DirectionType.Down;
					break;
			}

			Draw();
		}
	}
}