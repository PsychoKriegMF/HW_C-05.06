namespace HW_C_05._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задача 1
            var employees = new List<Employee>
            {
                new Employee{Name = "John", Department = "HR", Salary = 50000, PositionLevel = 3},
                new Employee{Name = "Alice", Department = "HR", Salary = 45000, PositionLevel = 2},
                new Employee{Name = "Bob", Department = "Finance", Salary = 80000, PositionLevel = 1},
                new Employee{Name = "Peter", Department = "Finance", Salary = 100000, PositionLevel = 3},
                new Employee{Name = "Max", Department = "SA", Salary = 120000, PositionLevel = 3},
                new Employee{Name = "Alex", Department = "SA", Salary = 110000, PositionLevel = 2},
                new Employee{Name = "Dima", Department = "IT", Salary = 50000, PositionLevel = 1},
                new Employee{Name = "Misha", Department = "IT", Salary = 60000, PositionLevel = 2},
                new Employee{Name = "Sasha", Department = "IT", Salary = 70000, PositionLevel = 3}
            };
            Console.WriteLine("Средняя зарплата по каждому отделу.");
            var averageSalary = employees
                .GroupBy(e => e.Department)
                .Select(s => new { Departament = s.Key, averageSalary = s.Average(x => x.Salary) });            
            foreach (var i in averageSalary)
            {
                Console.WriteLine($"{i.Departament} : {i.averageSalary}");
            }
            Console.WriteLine();
            Console.WriteLine("Отдел с самой высокой средней зарплатой: ");
            var maxAverageSalary = averageSalary
                .OrderByDescending(i => i.averageSalary).First();
            Console.WriteLine(maxAverageSalary.ToString());
            Console.WriteLine();
            Console.WriteLine("Работники с отделов с зарплатой выше средней: ");            
            var workersAverageSalary = employees
                .GroupBy(e => e.Department)
                .SelectMany(g => g.Where(e => e.Salary > g.Average(e => e.Salary)));
            foreach (var i in workersAverageSalary)
            {
                Console.WriteLine($"{i.Name},{i.Department} : {i.Salary}");
            }
            Console.WriteLine();
            Console.WriteLine("Суммарная зарплата для каждого уровня: ");
            var totalSum = employees
                .GroupBy(e => e.PositionLevel)
                .Select(e => new { PositionLevel = e.Key, totalSalary = e.Sum(e => e.Salary)});
            foreach (var i in totalSum)
            {
                Console.WriteLine($"{i.PositionLevel}: {i.totalSalary}");
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            //Задача 2
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, Amount = 100.10m, Date = new DateTime(2024,06,01) },
                new Transaction { TransactionId = 2, Amount = 110.20m, Date = new DateTime(2024,06,02) },
                new Transaction { TransactionId = 3, Amount = 120.30m, Date = new DateTime(2024,06,03) },
                new Transaction { TransactionId = 4, Amount = 130.40m, Date = new DateTime(2024,06,04) },
                new Transaction { TransactionId = 5, Amount = 140.50m, Date = new DateTime(2024,06,05) },
                new Transaction { TransactionId = 6, Amount = 150.60m, Date = new DateTime(2024,06,06) },
                new Transaction { TransactionId = 7, Amount = 106.70m, Date = new DateTime(2024,06,07) },
                new Transaction { TransactionId = 8, Amount = 107.80m, Date = new DateTime(2024,06,08) },
                new Transaction { TransactionId = 9, Amount = 108.90m, Date = new DateTime(2024,06,09) },
                new Transaction { TransactionId = 10, Amount = 109.23m, Date = new DateTime(2024,06,10) },
            };
            TransactionManager transactionManager = new TransactionManager();
            DateTime start = new DateTime(2024, 06, 03);
            DateTime stop = new DateTime(2024, 06, 07);

            decimal AverageAmount = transactionManager.AverageTransaction(transactions, start, stop);
            Console.WriteLine($"Средняя сумма транзакций с {start.ToShortDateString()} по {stop.ToShortDateString()} : {AverageAmount}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            List<object> objects = new List<object>
            {
                new Foo { Id = Guid.NewGuid(), Name = "Apple", Description = "A fruit" },
                new Foo { Id = Guid.NewGuid(), Name = "Banana", Description = "Yellow fruit" },
                new Foo { Id = Guid.NewGuid(), Name = "Grapes", Description = "Small fruit" },
                new Bar { Id = Guid.NewGuid(), Title = "Lorem", Description = "Lorem ipsum dolor" },
                new Bar { Id = Guid.NewGuid(), Title = "Ipsum", Description = "Ipsum dolor sit" }
            };

            var result = ObjectManager.AverageStringPropertyObject(objects);
            foreach(var i in result)
            {
                Console.WriteLine($"Тип: {i.Key.Name}, Средняя длина строки: {i.Value}");
            }

        }
    }
}
