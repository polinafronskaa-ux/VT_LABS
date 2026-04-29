// Manager.cs
namespace OOP_COLLECTIONS
{
    // =======================
    // Производный класс управляющего
    // =======================

    public class Manager : Employee // Поведение наследуется от сотрудника
    {
        // =======================
        // Для каждого управляющего характерна оценка работы от 0 до 10
        // =======================
        public int PerformanceScore { get; set; }

        // =========================
        // В момент создания управляющего в поля Id, Name, BaseSalary
        // Записываются значения через конструктор базового класса
        // (Внутри конструктора не нужно ничего писать)
        // А вот оценку работы нужно установить (логика характерная только для управляющего)
        // =========================
        public Manager(string name, double baseSalary, int performanceScore)
            : base(name, baseSalary)
        {
            // TODO: задать значение поля PerformanceScore = performanceScore
            PerformanceScore = performanceScore;
        }

        public override void Work()
        {
            // TODO: Вывести в консоль информацию о сотруднике вида:
            // "{имя} has a score {оценка работы}"
            Console.WriteLine($"{Name} has a score {PerformanceScore}");
        }

        public override double CalculateSalary()
        {
            // TODO: Расчитать зарплату управляющего
            // =========================
            // Логика расчета
            // У каждого управляющего есть оценка его работы от 0 до 10
            // бонус = оценка * 200
            // Общая ЗП = Стратовая ЗП + бонус
            // =========================
            int bonus = PerformanceScore * 200;
            return BaseSalary + bonus;
        }

        // =========================
        // Система может выводить информацию для каждого управляющего
        // =========================
        public override void DisplayInfo()
        {
            // Базовая информация о сотруднике
            base.DisplayInfo();

            // TODO: Вывести в консоль информацию об управляющем вида:
            // "PerformanceScore: {оценка}"
            Console.WriteLine($"PerformanceScore: {PerformanceScore}");
        }
    }
}