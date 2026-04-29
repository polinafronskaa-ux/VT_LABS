using OOP_COLLECTIONS;
using System;

class Program
{
    static void Main(string[] args)
    {
        // =========================
        // 1. Cоздать отдел с названием "IT"
        // =========================
        Department itDepartment = new Department("IT");

        // =========================
        // 2. Cоздать 2-х рабочих
        // =========================
        Worker worker1 = new Worker("Alex", 1000, 22);
        Worker worker2 = new Worker("Maria", 1100, 18);

        // =========================
        // 3. Cоздать 2-х программистов
        // =========================
        Programmer programmer1 = new Programmer("Ivan", 1500, "Middle");
        Programmer programmer2 = new Programmer("Elena", 2000, "Senior");

        // =========================
        // 4. Cоздать 1-го менеджера
        // =========================
        Manager manager1 = new Manager("Dmitry", 1800, 7);

        // =========================
        // 5. Добавить всех сотрудников в отдел
        // =========================
        itDepartment.AddEmployee(worker1);
        itDepartment.AddEmployee(worker2);
        itDepartment.AddEmployee(programmer1);
        itDepartment.AddEmployee(programmer2);
        itDepartment.AddEmployee(manager1);

        // =========================
        // 6. Вывести всех сотрудников отдела
        // =========================
        Console.WriteLine("=== Все сотрудники отдела ===");
        itDepartment.ShowAllEmployees();

        // =========================
        // 7. Найти сотрудников с Id 1, 3, 7 и вывести информацию о них
        // =========================
        Console.WriteLine("\n=== Тестируем поиск сотрудника ===");
        int[] idsToFind = { 1, 3, 7 };
        foreach (int id in idsToFind)
        {
            Employee emp = itDepartment.FindEmployeeById(id);
            if (emp != null)
            {
                emp.DisplayInfo();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.\n");
            }
        }

        // =========================
        // 8. Удалить сотрудника с Id = 2
        // =========================
        Console.WriteLine("\n=== Тестируем удаление сотрудника ===");
        bool removed = itDepartment.RemoveEmployeeById(2);
        Console.WriteLine($"Employee with ID 2 removed: {removed}");

        // =========================
        // 9. Вывести всех сотрудников отдела после удаления
        // =========================
        Console.WriteLine("\n=== После удаления ===");
        itDepartment.ShowAllEmployees();

        // =========================
        // 10. Вывести на экран сводную информацию об отделе
        // =========================
        Console.WriteLine("\n=== Статистика Отдела ===");
        itDepartment.GetDepartmentInfo();

        // Чтобы консоль не закрывалась сразу
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}