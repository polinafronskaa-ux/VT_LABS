namespace OOP_COLLECTIONS
{
    // =======================
    // Класс отдела
    // =======================

    public class Department
    {
        // =========================
        // У каждого отдела в системе есть
        // - Имя
        // - Список сотрудников
        // =========================
        public string Name { get; set; }
        public List<Employee> Employees { get; private set; }

        // =========================
        // В момент создания отдела ему:
        // 1) Задается Имя
        // 2) Создается Пустой Список, в который будут добавлены сотрудники
        // =========================
        public Department(string name)
        {
            Name = name;
            // TODO: Создать пустой список сотрудников
            Employees = new List<Employee>();
        }

        // =========================
        // Для каждого отдела характерна логика добавления сотрудника
        // НЕЛЬЗЯ ДОБАВИТЬ В ОТДЕЛ БОЛЕЕ 1 УПРАВЛЯЮЩЕГО (Manager)
        // =========================
        public void AddEmployee(Employee employee)
        {
            // TODO: Реализовать следующую логику
            // С помощью метода Add добавить в список сотрудников (Employees)
            // сотрудника (employee)
            // * НЕ ОБЯЗЯТЕЛЬНО (Подумать как реализовать логику невозможности добавить в отдел)
            // Второго менеджера, одного и того же сотрудника 2 раза

            // Проверка: нельзя добавить более одного менеджера
            if (employee is Manager)
            {
                foreach (var emp in Employees)
                {
                    if (emp is Manager)
                    {
                        Console.WriteLine($"Cannot add manager {employee.Name}. Only one manager allowed per department.");
                        return;
                    }
                }
            }

            // Проверка: нельзя добавить одного и того же сотрудника дважды
            if (Employees.Contains(employee))
            {
                Console.WriteLine($"Employee {employee.Name} already exists in the department.");
                return;
            }

            Employees.Add(employee);
            Console.WriteLine($"Employee {employee.Name} added to department {Name}.");
        }

        // =========================
        // Для каждого отдела характерна логика поиска сотрудника по Id
        // =========================
        public Employee FindEmployeeById(int id)
        {
            // TODO: Реализовать следующую логику
            // С помощью цикла foreach пробежаться по списку сотрудников
            // Если идентификатор текущего сотрудника = id - вернуть текущего сотрудника

            foreach (Employee emp in Employees)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }

            return null;
        }

        // =========================
        // Для каждого отдела характерна логика удаления сотрудника по Id
        // =========================
        public bool RemoveEmployeeById(int id)
        {
            // TODO: Реализовать следующую логику
            // Найти сотрудника по id
            Employee emp = FindEmployeeById(id);

            // если такой сотрудник существует (emp != null)
            // удалить его из списка сотрудников методом Remove
            // вернуть true

            if (emp != null)
            {
                Employees.Remove(emp);
                return true;
            }

            return false;
        }

        // =========================
        // Для каждого отдела характерна логика обзора всех сотрудников
        // =========================
        public void ShowAllEmployees()
        {
            Console.WriteLine($"\nDepartment: {Name}");

            // Пробежаться по списку всех сотрудников
            foreach (Employee emp in Employees)
            {
                // TODO: Реализовать следующую логику

                // 1. Показать информацию о текущем сотруднике DisplayInfo()
                emp.DisplayInfo();

                // 2. Показать, чем текущий сотрудник занимается Work()
                emp.Work();

                // 3. Вывести в консоль зарплату текущего сотрудника CalculateSalary()
                Console.WriteLine($"Total Salary: {emp.CalculateSalary()}");

                Console.WriteLine("----------------------");
            }
        }

        // =========================
        // Для каждого отдела характерна логика вывода сводной информации
        // =========================
        public void GetDepartmentInfo()
        {
            // TODO: Реализовать следующую логику
            // 1. Вычислить количество сотрудников отдела (метод Count для списка)
            int totalEmployees = Employees.Count;

            // TODO: Реализовать следующую логику
            // 2. Расчитать суммарную зарплату отдела
            // и количество сотрудников разного типа
            double totalSalary = 0;
            int workers = 0, programmers = 0, managers = 0;

            // Для этого пробежать по списку всех сотрудников
            foreach (Employee emp in Employees)
            {
                // к общей суммарной зарплате прибавить суммарную зарплату текущего сотрудника
                totalSalary += emp.CalculateSalary();

                // Если текущий сотрудник - рабочий
                if (emp is Worker)
                {
                    // увеличить число рабочих на 1
                    workers++;
                }
                // Иначе если текущий сотрудник - программист
                if (emp is Programmer)
                {
                    // увеличить число программистов на 1
                    programmers++;
                }
                // Иначе если текущий сотрудник - управляющий
                if (emp is Manager)
                {
                    // увеличить число управляющих на 1
                    managers++;
                }
            }

            // TODO: Реализовать следующую логику
            // 3. Расчитать среднюю зарплату отдела как:
            // Суммарная зарплата отдела / число сотрудников в отделе
            double avgSalary = totalEmployees > 0 ? totalSalary / totalEmployees : 0;

            Console.WriteLine($"\n=== Department Info: {Name} ===");
            Console.WriteLine($"Total Employees: {totalEmployees}");
            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {avgSalary:F2}");

            Console.WriteLine("\nBy Type:");
            Console.WriteLine($"Workers: {workers}");
            Console.WriteLine($"Programmers: {programmers}");
            Console.WriteLine($"Managers: {managers}");
        }
    }
}