using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassLibrary2
{
    // Абстрактный базовый класс бытовой техники
    public abstract class HomeAppliance
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }

        public HomeAppliance(string manufacturer = "Unknown", string model = "Unknown", double price = 0.0, string color = "Белый")
        {
            if (!Validators.IsValidColor(color))
                throw new ArgumentException("Некорректный цвет");
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Color = color;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Цена: ${Price}");
            Console.WriteLine($"Цвет: {Color}");
        }
    }

    // Производный класс для стиральной машины
    public class WashingMachine : HomeAppliance
    {
        public int LoadCapacity { get; set; } // в кг
        public string Type { get; set; } // автоматическая или полуавтоматическая

        public WashingMachine(string manufacturer, string model, double price, string color, int loadCapacity, string type)
            : base(manufacturer, model, price, color)
        {
            if (loadCapacity <= 0)
                throw new ArgumentException("Объем загрузки должен быть положительным");
            if (!Validators.IsValidType(type))
                throw new ArgumentException("Некорректный тип");
            LoadCapacity = loadCapacity;
            Type = type;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Стиральная машина:");
            base.PrintInfo();
            Console.WriteLine($"Объем загрузки: {LoadCapacity} кг");
            Console.WriteLine($"Тип: {Type}");
        }
    }

    // Производный класс для посудомоечной машины
    public class Dishwasher : HomeAppliance
    {
        public int Capacity { get; set; } // в комплектах
        public bool HasDrying { get; set; } // наличие сушки

        public Dishwasher(string manufacturer, string model, double price, string color, int capacity, bool hasDrying)
            : base(manufacturer, model, price, color)
        {
            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть положительной");
            Capacity = capacity;
            HasDrying = hasDrying;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Посудомоечная машина:");
            base.PrintInfo();
            Console.WriteLine($"Вместимость: {Capacity} комплектов");
            Console.WriteLine($"Сушка: {(HasDrying ? "Да" : "Нет")}");
        }
    }

    // Валидаторы
    public static class Validators
    {
        public static bool IsValidColor(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return false;

            string[] validColors = { "Черный", "Белый", "Серый", "Красный", "Синий" };
            return validColors.Contains(color);
        }

        public static bool IsValidType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return false;

            string[] validTypes = { "Автоматическая", "Полуавтоматическая" };
            return validTypes.Contains(type);
        }

        public static bool IsValidLoadCapacity(int loadCapacity)
        {
            // допустимый диапазон: от 1 до 10 кг
            return loadCapacity >= 1 && loadCapacity <= 10;
        }
    }
}