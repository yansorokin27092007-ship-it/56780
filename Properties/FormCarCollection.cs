using ProjectDumpTruck.CollectionGenericObjects;
using ProjectDumpTruck.Drawnings;
using System.Windows.Forms;

namespace ProjectDumpTruck
{

    /// <summary>
    /// Форма для работы с коллекцией
    /// </summary>
    public partial class FormCarCollection : Form
    {
        /// <summary>
        /// Компания
        /// </summary>
        private readonly AbstractCompany _company;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormCarCollection()
        {
            InitializeComponent();
            _company = new CarSharingService(pictureBox.Width, pictureBox.Height, new MassiveGenericObjects<DrawningCar>());
        }

        /// <summary>
        /// Добавление обычного самосвала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDumpTruck_Click(object sender, EventArgs e) => CreateAndAddObjectCollection(nameof(DrawningCar));

        /// <summary>
        /// Добавление продвинутого самосвала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddAdvancedDumpTruck_Click(object sender, EventArgs e) => CreateAndAddObjectCollection(nameof(DrawningDumpTruck));

        /// <summary>
        /// Создание объект класса-перемещения и добавление его в коллекцию
        /// </summary>
        /// <param name="type"></param>
        private void CreateAndAddObjectCollection(string type)
        {
            Random random = new();
            DrawningCar car;
            switch (type)
            {
                case nameof(DrawningCar):
                    car = new DrawningCar(random.Next(100, 300), random.Next(1000, 3000), GetColor(random));
                    break;
                case nameof(DrawningDumpTruck):
                    //создание продвинутого объекта
                    ColorDialog bodyColorDialog = new();
                    ColorDialog additionalColorDialog = new();
                    bool hasBody = Convert.ToBoolean(random.Next(0, 2));
                    bool hasTent = Convert.ToBoolean(random.Next(0, 2));

                    car = new DrawningDumpTruck(random.Next(100, 300), random.Next(1000, 3000), GetColor(random), GetColor(random), hasBody, hasTent);
                    break;
                default:
                    return;
            }
            int result = _company + car;
            if (result != -1)
            {
                MessageBox.Show("Объект добавлен");
                pictureBox.Image = _company.Show();
            }
            else
            {
                MessageBox.Show("Не удалось добавить объект");
            }
        }

        /// <summary>
        /// Получение цвета
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        private static Color GetColor(Random random)
        {
            ColorDialog dialog = new();
            return dialog.ShowDialog() == DialogResult.OK ?
                dialog.Color :
                Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveDumpTruck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxPosition.Text))
            {
                return;
            }

            if (MessageBox.Show("Удалить объект?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int pos = Convert.ToInt32(maskedTextBoxPosition.Text);
            DrawningCar? removedCar = _company - pos;
            if (removedCar is not null)
            {
                MessageBox.Show("Объект удален");
                pictureBox.Image = _company.Show();
            }
            else
            {
                MessageBox.Show("Не удалось удалить объект");
            }
        }

        /// <summary>
        /// Передача объекта в другую форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGoToCheck_Click(object sender, EventArgs e)
        {
            if (_company.GetRandomObject() is not DrawningCar car)
            {
                MessageBox.Show("Не удалось получить объект");
                return;
            }

            FormDumpTruck formSportCar = new();
            formSportCar.SetDrawningCar(car);
            formSportCar.ShowDialog();
        }

        /// <summary>
        /// Перерисовка коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, EventArgs e) => pictureBox.Image = _company.Show();
    }
}
