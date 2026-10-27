using System;

namespace Lab2_Task3B
{
    
    class RandomArrayProcessor
    {
        private int[] array;
        private Random rnd = new Random();

        // Конструктор, що приймає розмір та заповнює масив випадковими числами [-100; 100]
        public RandomArrayProcessor(int size)
        {
            array = new int[size];
            FillArray();
        }

        // Приватний метод для заповнення масиву
        private void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101); // Відрізок [-100; 100]
            }
        }

        // Метод для виведення масиву на екран
        public void PrintArray()
        {
            Console.WriteLine("\nЗгенерований масив [-100; 100]:");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Метод 1: Пошук індексу max за модулем елемента
        public int GetMaxAbsIndex()
        {
            if (array.Length == 0) return -1;

            int maxAbsIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(array[maxAbsIndex]))
                {
                    maxAbsIndex = i;
                }
            }
            return maxAbsIndex;
        }

        // Геттер для отримання елемента за індексом для виводу
        public int GetElement(int index)
        {
            return array[index];
        }

        // Метод 2: Добуток після першого додатного елемента
        public long GetProductAfterFirstPositive()
        {
            int firstPosIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    firstPosIndex = i;
                    break;
                }
            }

            if (firstPosIndex == -1 || firstPosIndex == array.Length - 1)
            {
                return 0;
            }

            long product = 1;
            for (int i = firstPosIndex + 1; i < array.Length; i++)
            {
                product *= array[i];
            }
            return product;
        }
    }

    // Головний клас програми
    class Program
    {
        // Метод Main знаходиться в самому кінці
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                
                Console.Write("Введіть розмірність масиву n (або 0 для виходу): ");

                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine("\nПомилка! Введіть ціле число.");
                    continue;
                }

                if (n == 0)
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }

                if (n < 0)
                {
                    Console.WriteLine("\nРозмірність масиву має бути додатною!");
                    continue;
                }

                // Створення об'єкта класу, який сам генерує та обробляє масив
                RandomArrayProcessor processor = new RandomArrayProcessor(n);

                // Виведення згенерованого масиву
                processor.PrintArray();

                // Обчислення результатів
                int maxAbsIdx = processor.GetMaxAbsIndex();
                long product = processor.GetProductAfterFirstPositive();

                Console.WriteLine($"\n1) Номер (індекс) max за модулем елемента: {maxAbsIdx} (значення: {processor.GetElement(maxAbsIdx)})");
                Console.WriteLine($"2) Добуток елементів після першого додатного: {product}");
            }
        }
    }
}