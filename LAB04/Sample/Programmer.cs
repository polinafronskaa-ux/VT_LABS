// Programmer.cs
namespace OOP_COLLECTIONS
{
    // =======================
    // Производный класс программиста
    // =======================


    public class Programmer : Employee // Поведение наследуется от сотрудника
    {
        // =======================
        // Для каждого программиста характерен уровень ("Junior", "Middle", "Senoir", "Lead")
        // =======================
        public string Level { get; set; }

        // =========================
        // В момент создания программиста в поля Id, Name, BaseSalary
        // Записываются значения через конструктор базового класса
        // (Внутри конструктора не нужно ничего писать)
        // А вот уровень нужно установить (логика характерная только для программиста)
        // =========================
        public Programmer(string name, double baseSalary, string level)
            : base(name, baseSalary)
        {
            // TODO: задать значение поля Level = level
            Level = level;
        }

        public override void Work()
        {
            // TODO: Вывести в консоль информацию о сотруднике вида:
            // "{имя} is working as a {уровень} developer."
            Console.WriteLine($"{Name} is working as a {Level} developer.");
        }

        public override double CalculateSalary()
        {
            // TODO: Расчитать зарплату программиста
            // =========================
            // Логика расчета
            // У каждого рабочего есть уровень
            // За каждый уровень он получает бонус
            // "Junior" = 300
            // "Mid" = 600
            // "Senior" = 1000
            // "Lead" = 1500
            // иначе без бонуса
            // Общая ЗП = Стратовая ЗП + бонус
            // =========================
            double bonus = 0;

            // рассчитать бонус исходя из описанной выше логики
            switch (Level)
            {
                case "Junior":
                    bonus = 300;
                    break;
                case "Middle":
                    bonus = 600;
                    break;
                case "Senior":
                    bonus = 1000;
                    break;
                case "Lead":
                    bonus = 1500;
                    break;
                default:
                    bonus = 0;
                    break;
            }

            return BaseSalary + bonus;
        }

        // =========================
        // Система может выводить информацию для каждого программиста
        // =========================
        public override void DisplayInfo()
        {
            // Базовая информация о сотруднике
            base.DisplayInfo();

            // TODO: Вывести в консоль информацию о программисте вида:
            // "Level: {уровень}"
            Console.WriteLine($"Level: {Level}");
        }
    }
}