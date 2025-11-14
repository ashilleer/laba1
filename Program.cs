using System;
using System.Collections.Generic;

// Абстрактный базовый класс для бытовой техники
abstract class HomeAppliance
{
    // Защищенные поля для характеристик устройства
    protected string manufacturer;
    protected string model;
    protected double price;
    protected string color;

    // Свойство для производителя с проверкой
    public string Manufacturer
    {
        get { return manufacturer; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Производитель не может быть пустым");
            manufacturer = value;
        }
    }

    // Свойство для модели с проверкой
    public string Model
    {
        get { return model; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Модель не может быть пустой");
            model = value;
        }
    }

    // Свойство для цены с проверкой
    public double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Цена должна быть положительной");
            price = value;
        }
    }

    // Свойство для цвета с проверкой
    public string Color
    {
        get { return color; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Цвет не может быть пустым");
            color = value;
        }
    }

    // Конструктор с параметрами по умолчанию
    public HomeAppliance(string manufacturer = "Unknown", string model = "Unknown", double price = 0.0, string color = "White")
    {
        Manufacturer = manufacturer;
        Model = model;
        Price = price;
        Color = color;
    }

    // Виртуальный метод для вывода информации об устройстве
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Производитель: {Manufacturer}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Цена: ${Price}");
        Console.WriteLine($"Цвет: {Color}");
    }
}

// Производный класс для стиральной машины
class WashingMachine : HomeAppliance
{
    private int _loadCapacity; // Объем загрузки в кг
    private string _type; // Тип: автоматическая или полуавтоматическая

    // Свойство для объема загрузки с проверкой
    public int LoadCapacity
    {
        get { return _loadCapacity; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Объем загрузки должен быть положительным");
            _loadCapacity = value;
        }
    }

    // Свойство для типа с проверкой
    public string Type
    {
        get { return _type; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Тип не может быть пустым");
            _type = value;
        }
    }

    // Конструктор с параметрами
    public WashingMachine(string manufacturer = "Unknown", string model = "Unknown", double price = 0.0, string color = "White",
        int loadCapacity = 5, string type = "Автомат")
        : base(manufacturer, model, price, color)
    {
        LoadCapacity = loadCapacity;
        Type = type;
    }

    // Переопределение метода для вывода информации
    public override void PrintInfo()
    {
        Console.WriteLine("Стиральная машина:");
        base.PrintInfo();
        Console.WriteLine($"Объем загрузки: {LoadCapacity} кг");
        Console.WriteLine($"Тип: {Type}");
    }
}

// Производный класс для посудомоечной машины
class Dishwasher : HomeAppliance
{
    private int _capacity; // Вместимость в комплекте посуды
    private bool _hasDrying; // Наличие функции сушки

    // Свойство для вместимости с проверкой
    public int Capacity
    {
        get { return _capacity; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Вместимость должна быть положительной");
            _capacity = value;
        }
    }

    // Свойство для функции сушки
    public bool HasDrying
    {
        get { return _hasDrying; }
        set { _hasDrying = value; }
    }

    // Конструктор с параметрами
    public Dishwasher(string manufacturer = "Unknown", string model = "Unknown", double price = 0.0, string color = "White",
        int capacity = 12, bool hasDrying = true)
        : base(manufacturer, model, price, color)
    {
        Capacity = capacity;
        HasDrying = hasDrying;
    }

    // Переопределение метода для вывода информации
    public override void PrintInfo()
    {
        Console.WriteLine("Посудомоечная машина:");
        base.PrintInfo();
        Console.WriteLine($"Вместимость: {Capacity} комплектов");
        Console.WriteLine($"Сушка: {(HasDrying ? "Да" : "Нет")}");
    }
}

// Основная программа
class Program
{
    // Массив цветов для выбора
    static readonly string[] Colors = { "Белый", "Черный", "Серый", "Красный", "Синий" };

    static void Main()
    {
        // Список для хранения устройств
        List<HomeAppliance> applianceList = new List<HomeAppliance>();

        // Отображение меню с функциями создания устройств
        var creationFunctions = new Dictionary<int, Func<HomeAppliance>>()
        {
            {1, CreateWashingMachine},
            {2, CreateDishwasher}
        };

        while (true)
        {
            // Основное меню
            Console.WriteLine("\nВыберите опцию:");
            Console.WriteLine("1. Добавить стиральную машину");
            Console.WriteLine("2. Добавить посудомоечную машину");
            Console.WriteLine("3. Показать список устройств");
            Console.WriteLine("4. Выйти");

            // Обработка выбора пользователя
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова.");
                continue;
            }

            if (creationFunctions.ContainsKey(choice))
            {
                try
                {
                    // Создаем устройство по выбранной функции и добавляем в список
                    var appliance = creationFunctions[choice]();
                    applianceList.Add(appliance);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else if (choice == 3)
            {
                // Показ всех устройств
                if (applianceList.Count == 0)
                {
                    Console.WriteLine("в списке нет устройств");
                }
                else
                {
                    Console.WriteLine("\nСписок устройств:");
                    foreach (var item in applianceList)
                    {
                        item.PrintInfo();
                        Console.WriteLine();
                    }
                }
            }
            else if (choice == 4)
            {
                // Выход из программы
                Console.WriteLine("Выход из программы.");
                break;
            }
            else
            {
                Console.WriteLine("Недопустимый выбор, попробуйте снова.");
            }
        }
    }

    // Метод для создания стиральной машины с вводом данных
    static HomeAppliance CreateWashingMachine()
    {
        string manufacturer = ReadStringWithRetry("Введите производителя: ");
        string model = ReadStringWithRetry("Введите модель: ");
        double price = ReadDoubleWithRetry("Введите цену: ", 0.01);
        string color = ReadColor();
        int loadCapacity = ReadIntWithRetry("Введите объем загрузки (кг): ", 1);
        string type = ReadType();
        return new WashingMachine(manufacturer, model, price, color, loadCapacity, type);
    }

    // Метод для создания посудомоечной машины с вводом данных
    static HomeAppliance CreateDishwasher()
    {
        string manufacturer = ReadStringWithRetry("Введите производителя: ");
        string model = ReadStringWithRetry("Введите модель: ");
        double price = ReadDoubleWithRetry("Введите цену: ", 0.01);
        string color = ReadColor();
        int capacity = ReadIntWithRetry("Введите вместимость (комплектов): ", 1);
        bool hasDrying = ReadBoolWithRetry("Есть ли функция сушки? (1 — да, 0 — нет): ");
        return new Dishwasher(manufacturer, model, price, color, capacity, hasDrying);
    }

    // Метод для безопасного чтения строки с проверкой на пустоту
    static string ReadStringWithRetry(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: значение не может быть пустым. Попробуйте снова.");
            }
            else
            {
                return input;
            }
        }
    }

    // Метод для чтения и проверки числа с плавающей точкой
    static double ReadDoubleWithRetry(string prompt, double min = double.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!double.TryParse(input, out double result))
            {
                Console.WriteLine("Ошибка: введено не число. Попробуйте снова.");
                continue;
            }
            if (result < min)
            {
                Console.WriteLine($"Ошибка: число должно быть не меньше {min}. Попробуйте снова.");
                continue;
            }
            return result;
        }
    }

    // Метод для чтения и проверки целого числа
    static int ReadIntWithRetry(string prompt, int min = int.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Ошибка: введено не целое число. Попробуйте снова.");
                continue;
            }
            if (result < min)
            {
                Console.WriteLine($"Ошибка: число должно быть не меньше {min}. Попробуйте снова.");
                continue;
            }
            return result;
        }
    }

    // Метод для чтения булева значения (да/нет)
    static bool ReadBoolWithRetry(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == "1")
                return true;
            if (input == "0")
                return false;
            Console.WriteLine("Ошибка: ввод должен быть 1 или 0. Попробуйте снова.");
        }
    }

    // Метод для выбора цвета из списка
    static string ReadColor()
    {
        string[] colorOptions = { "Белый", "Черный", "Серый", "Красный", "Синий" };
        while (true)
        {
            Console.WriteLine("Выберите цвет:");
            for (int i = 0; i < colorOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {colorOptions[i]}");
            }
            Console.Write("Введите номер цвета: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > colorOptions.Length)
            {
                Console.WriteLine("Ошибка: некорректный выбор цвета. Попробуйте снова.");
                continue;
            }
            return colorOptions[index - 1];
        }
    }

    // Метод для выбора типа устройства
    static string ReadType()
    {
        string[] types = { "Автоматическая", "Полуавтоматическая" };
        while (true)
        {
            Console.WriteLine("Выберите тип:");
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {types[i]}");
            }
            Console.Write("Введите номер типа: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > types.Length)
            {
                Console.WriteLine("Ошибка: некорректный выбор. Попробуйте снова.");
                continue;
            }
            return types[index - 1];
        }
    }
}
