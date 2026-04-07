namespace LAB03
{
    public class Rational
    {
        // Поля (Числитель и Знаменатель)
        private int numerator;
        private int denominator;

        // Свойства (Доступ к Полям)
        public int Numerator
        {
            get => numerator;
            set => numerator = value;
        }

        public int Denominator
        {
            get => denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                denominator = value;
            }
        }

        // Конструкторы
        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");

            /*
                TODO: Реализовать логику внутри конструктора
                числитель = аргументу функции (numerator), 
                знаменатель = аргументу функции (denominator)

                Сократить дробь в момент создания (вызвать Reduce())
                Нормализовать знаки (вызвать Normalize())
            */
            this.numerator = numerator;
            this.denominator = denominator;

            Normalize();
            Reduce();
        }

        public Rational(int numerator)
        {
            /*
                TODO: Реализовать логику внутри конструктора
                числитель = аргументу функции, знаменатель = 1
            */
            this.numerator = numerator;
            this.denominator = 1;
        }

        public Rational()
        {
            /*
                TODO: Реализовать логику внутри конструктора
                числитель = 0, знаменатель = 1
            */
            this.numerator = 0;
            this.denominator = 1;
        }

        // ToString
        public override string ToString()
        {
            /*
                TODO: Реализовать логику метода для вывода объектов дроби
                В виде numerator / denominator
                Если знаменатель равен 1 - выводить только числитель
            */
            if (denominator == 1)
                return $"{numerator}";
            else
                return $"{numerator} / {denominator}";
        }

        // Метод нормализации знака дроби
        private void Normalize()
        {
            /*
                TODO: Реализовать логику метода нирмализации знака
                Если знаменатель дроби < 0
                Домнажаем числитель и знаменатель на -1
            */
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        // НОД (алгоритм Евклида). Нужен для сокращения дроби
        private static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // Сокращение дроби (делим числитель и знаменатель на НОД)
        public void Reduce()
        {
            int gcd = GCD(this.numerator, this.denominator);
            this.numerator /= gcd;
            this.denominator /= gcd;
        }

        // Перегрузка операторов

        /* 
           Метод суммы (Суммой двух дробей (a и b) является новая Дробь)
           С числителем и знаменателем, расчитаным по формуле:
        */
        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(
                a.numerator * b.denominator + b.numerator * a.denominator,
                a.denominator * b.denominator
            );
        }

        public static Rational operator -(Rational a, Rational b)
        {
            // TODO: Реализовать перегрузку оператора - по примеру + (описан выше)
            return new Rational(
                a.numerator * b.denominator - b.numerator * a.denominator,
                a.denominator * b.denominator
            );
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(
                a.numerator * b.numerator,
                a.denominator * b.denominator
            );
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Деление на ноль");

            // TODO: Реализовать перегрузку оператора / по примеру * (описан выше)
            return new Rational(
                a.numerator * b.denominator,
                a.denominator * b.numerator
            );
        }

        // Сравнение

        public static bool operator ==(Rational a, Rational b)
        {
            /* 
                TODO: Реализовать перегрузку оператора =
                Дробь a = Дроби b, 
                если числители и знаменатели обеих дробей равны между собой
            */
            // Проверка на null
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.numerator == b.numerator && a.denominator == b.denominator;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }
    }
}