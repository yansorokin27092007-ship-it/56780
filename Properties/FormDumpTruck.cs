using ProjectDumpTruck.Drawnings;
using ProjectDumpTruck.MovementTemplate;

namespace ProjectDumpTruck;

public partial class FormDumpTruck : Form
{
    /// <summary>
    /// Поле-объект полотно
    /// </summary>
    private readonly CanvasForCar _canvasForCar;

    /// <summary>
    /// Поле для фиксации состояния для следующего шага проверки выхода за границы
    /// </summary>
    private DirectionType _checkBordersState;

    /// <summary> 
    /// Шаблон перемещения 
    /// </summary> 
    private BaseTemplateMovement? _templateMovement;

    /// <summary>
    /// Инициализация формы
    /// </summary>
    public FormDumpTruck()
    {
        InitializeComponent();
        _canvasForCar = new CanvasForCar();
        _canvasForCar.SetPictureSize(pictureBoxDumpTruck.Width, pictureBoxDumpTruck.Height);
        _checkBordersState = DirectionType.None;
        _templateMovement = null;
        comboBoxPointOfDestination.Items.AddRange(TemplateMovementFactory.Values);
    }

    /// <summary>
    /// Получение самосвала
    /// </summary>
    public void SetDrawningCar(DrawningCar car) => InsertCarObject(car);

    /// <summary>
    /// Добавление на полотно самосвала
    /// </summary>
    /// <param name="car"></param>
    /// <param name="random"></param>
    public void InsertCarObject(DrawningCar car, Random? random = null)
    {
        random ??= new();
        if (_canvasForCar.InsertCar(car))
        {
            _canvasForCar.SetCarPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxPointOfDestination.Enabled = true;
            comboBoxPointOfDestination.SelectedIndex = -1;
            Draw();
        }
    }

    /// <summary>
    /// Метод прорисовки машины
    /// </summary>
    private void Draw() => pictureBoxDumpTruck.Image = _canvasForCar.DrawCanvas();

    /// <summary>
    /// Обработка нажатия кнопки "Создать"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        Random random = new();
        DrawningCar car = new(random.Next(100, 300), random.Next(1000, 3000), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        if (_canvasForCar.InsertCar(car))
        {
            _canvasForCar.SetCarPosition(random.Next(10, 100), random.Next(10, 100));
            Draw();
        }
    }

    /// <summary>
    ///  Обработка нажатия кнопки "Создать продвинутый самосвал" 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonCreateSportDumpTruck_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningDumpTruck));

    /// <summary>
    /// Создание объекта класса-перемещения
    /// </summary>
    /// <param name="type"></param>
    private void CreateObject(string type)
    {
        Random random = new();
        DrawningCar? drawningCar = null;
        switch (type)
        {
            case nameof(DrawningCar):
                drawningCar = new DrawningCar(random.Next(100, 300), random.Next(1000, 3000), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
                break;
            case nameof(DrawningDumpTruck):
                drawningCar = new DrawningDumpTruck(random.Next(100, 300), random.Next(1000, 3000), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
                break;
            default:
                return;
        }
        InsertCarObject(drawningCar, random);
    }

    /// <summary>
    /// Перемещение объекта по форме (нажатие кнопок навигации)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        if (_canvasForCar.MoveTransport(direction))
        {
            Draw();
        }
    }

    /// <summary>
    /// Проверка, что объект не выходит за границы при неверно заданных координатах
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCheckBorders_Click(object sender, EventArgs e)
    {
        Random random = new();
        switch (_checkBordersState)
        {
            case DirectionType.None:
            case DirectionType.Down:
                _canvasForCar.SetCarPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
                _checkBordersState = DirectionType.Left;
                break;
            case DirectionType.Left:
                _canvasForCar.SetCarPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
                _checkBordersState = DirectionType.Up;
                break;
            case DirectionType.Up:
                _canvasForCar.SetCarPosition(random.Next(10, 100) + pictureBoxDumpTruck.Width, random.Next(10, 100));
                _checkBordersState = DirectionType.Right;
                break;
            case DirectionType.Right:
                _canvasForCar.SetCarPosition(random.Next(10, 100), random.Next(10, 100) + pictureBoxDumpTruck.Height);
                _checkBordersState = DirectionType.Down;
                break;
        }
        Draw();
    }

    /// <summary>
    ///  Обработка выбора элемента из выпадающего списка
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ComboBoxPointOfDestination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_canvasForCar is null || _canvasForCar.DrawningCar is null)
        {
            return;
        }

        _templateMovement = TemplateMovementFactory.CreateTemplateMovement(comboBoxPointOfDestination.Text);
        if (_templateMovement is null)
        {
            return;
        }

        _templateMovement.SetData(new MoveableAdapterCar(_canvasForCar.DrawningCar), pictureBoxDumpTruck.Width, pictureBoxDumpTruck.Height);
        comboBoxPointOfDestination.Enabled = false;
    }

    /// <summary>
    /// Выполнение шага перемещения
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonMovementStep_Click(object sender, EventArgs e)
    {
        if (_templateMovement is null)
        {
            return;
        }

        _templateMovement.MakeStep();
        if (_templateMovement.IsFinishReached)
        {
            comboBoxPointOfDestination.Enabled = true;
            comboBoxPointOfDestination.SelectedIndex = -1;
        }

        Draw();
    }
}
