using System.Diagnostics.Metrics;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Создать и вывести информацию о часах");
                Console.WriteLine("2. Подсчитать количество созданных объектов и коллекций");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Demo();
                        break;
                    case "2":
                        Collections();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void Demo()
        {
            DialClock clock1 = new DialClock();
            clock1.PrintInfo();

            DialClock clock2 = new DialClock(9, 1);
            clock2++;
            clock2--;
            clock2.PrintInfo();

            DialClock clock3 = new DialClock(clock2);
            clock3.PrintInfo();

            DialClock clock = new DialClock(10, 90);

            double angle1 = DialClock.CalculateAngleStatic(10, 90);
            Console.WriteLine($"Угол (статический метод): {angle1}");

            double angle2 = clock.CalculateAngle();
            Console.WriteLine($"Угол (метод класса): {angle2}");

            Console.WriteLine($"Кол-во созданных объектов: {DialClock.GetObjectCount()}");
        }

        static void Collections()
        {
            // создание массива с помощью случайной генерации
            Console.WriteLine("Введите длину массива: ");
            DialClockArray array1 = new DialClockArray(5);
            Console.WriteLine("Массив, созданный случайной генерацией:");
            array1.Show();
            Console.WriteLine();

            // создание массива с помощью ручного ввода
            DialClockArray array2 = new DialClockArray(3);
            Console.WriteLine("Введите значения для массива (формат: часы минуты):");

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                string[] input = Console.ReadLine().Split(' ');
                int hours = int.Parse(input[0]);
                int minutes = int.Parse(input[1]);
                array2[i] = new DialClock(hours, minutes);
            }

            Console.WriteLine("Массив, созданный с помощью ручного ввода:");
            array2.Show();
            Console.WriteLine();

            // создание новой коллекции на основе существующей
            DialClockArray copiedArray = new DialClockArray(array2);
            Console.WriteLine("Новая коллекция, созданная на основе существующей:");
            copiedArray.Show();
            Console.WriteLine();

            // пример индексатора
            Console.WriteLine("Примеры работы индексатора:");

            try
            {
                // получение объекта с существующим индексом
                Console.WriteLine("Объект с индексом 1: " + array1[1]);
                // получение объекта с несуществующим индексом
                Console.WriteLine("Объект с индексом 10: " + array1[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка: выход за границу массива");
            }

            // запись объекта по несуществующему индексу
            array1[10] = new DialClock(12, 0);
            DialClockArray[] arrays = new DialClockArray[2];
            arrays[0] = new DialClockArray(3);
            arrays[1] = new DialClockArray(4);
            EditedArray(arrays);
        }

        // Функция для обработки массива
        static void EditedArray(DialClockArray[] arr)
        {
            int objCount = 0;
            int collCount = 0;

            DialClock maxAngleClock = null; // с максимальным углом
            double maxAngle = 0; // максимальный угол

            foreach (var array in arr)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    DialClock currentClock = array[i];
                    double currentAngle = currentClock.CalculateAngle();

                    if (currentAngle > maxAngle)
                    {
                        maxAngle = currentAngle;
                        maxAngleClock = currentClock;
                    }
                }

                // подсчет кол-ва созданных DialClock
                objCount += array.Length;

                // подсчет кол-ва созданных DialClockArray
                collCount++;
            }

            Console.WriteLine($"Количество созданных объектов DialClock: {objCount}");
            Console.WriteLine($"Количество созданных коллекций DialClockArray: {collCount}");

            // проверка наличия объекта с максимальным углом
            if (maxAngleClock != null)
            {
                Console.WriteLine($"Объект DialClock с максимальным углом ({maxAngle} градусов): {maxAngleClock}");
            }
            else
            {
                Console.WriteLine("В массиве нет объектов DialClock.");
            }
        }
    }
}
    