namespace LAB03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа 3. ООП C# (Базовые концепции) ===\n");

            // Задание 1.1 (Код проверки пишем ниже)
            Rational r1 = new Rational(3, 8);
            Console.WriteLine($"new Rational(3, 8) = {r1}");
            Console.WriteLine($"Ожидаемый результат: 3 / 8\n");

            // Задание 1.2 (Код проверки пишем ниже)
            Rational r2 = new Rational(4);
            Console.WriteLine($"new Rational(4) = {r2}");
            Console.WriteLine($"Ожидаемый результат: 4\n");

            // Задание 1.3 (Код проверки пишем ниже)
            Rational r3 = new Rational();
            Console.WriteLine($"new Rational() = {r3}");
            Console.WriteLine($"Ожидаемый результат: 0\n");

            // Задание 1.4 (Код проверки пишем ниже)
            try
            {
                Rational r4 = new Rational(-3, 0);
                Console.WriteLine($"new Rational(-3, 0) = {r4}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка (как и ожидалось): {ex.Message}");
            }
            Console.WriteLine();

            // Задание 2.1 (Код проверки пишем ниже)
            Rational r5 = new Rational(4, 8);
            Console.WriteLine($"new Rational(4, 8) = {r5}");
            Console.WriteLine($"Ожидаемый результат: 1 / 2\n");

            // Задание 2.2 (Код проверки пишем ниже)
            Rational r6 = new Rational(4, -9);
            Console.WriteLine($"new Rational(4, -9) = {r6}");
            Console.WriteLine($"Ожидаемый результат: -4 / 9");

            Rational r7 = new Rational(-2, -10);
            Console.WriteLine($"new Rational(-2, -10) = {r7}");
            Console.WriteLine($"Ожидаемый результат: 1 / 5\n");

            // Задание 3.1 (Код проверки пишем ниже)
            Rational a = new Rational(1, 2);
            Rational b = new Rational(1, 3);

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}\n");

            Rational sum = a + b;
            Console.WriteLine($"a + b = {sum}");
            Console.WriteLine($"Ожидаемый результат: 5 / 6");

            Rational diff = a - b;
            Console.WriteLine($"a - b = {diff}");
            Console.WriteLine($"Ожидаемый результат: 1 / 6");

            Rational product = a * b;
            Console.WriteLine($"a * b = {product}");
            Console.WriteLine($"Ожидаемый результат: 1 / 6");

            Rational quotient = a / b;
            Console.WriteLine($"a / b = {quotient}");
            Console.WriteLine($"Ожидаемый результат: 3 / 2 или 1 / 1? Фактически: 3/2");
            Console.WriteLine($"Проверка: 1/2 : 1/3 = 1/2 * 3/1 = 3/2\n");

            // Задание 3.2 (Код проверки пишем ниже)
            Rational r8 = new Rational(1, 2);
            Rational r9 = new Rational(1, 2);
            Rational r10 = new Rational(2, 4); // Сокращенная форма 1/2
            Rational r11 = new Rational(2, 3);

            Console.WriteLine($"r8 = {r8}");
            Console.WriteLine($"r9 = {r9}");
            Console.WriteLine($"r10 = {r10}");
            Console.WriteLine($"r11 = {r11}\n");

            Console.WriteLine($"r8 == r9: {r8 == r9} (Ожидается: True)");
            Console.WriteLine($"r8 == r10: {r8 == r10} (Ожидается: True)");
            Console.WriteLine($"r8 == r11: {r8 == r11} (Ожидается: False)");
            Console.WriteLine($"r8 != r11: {r8 != r11} (Ожидается: True)\n");

          
        }
    }
}