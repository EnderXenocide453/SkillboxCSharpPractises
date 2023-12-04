using System;

namespace SkillboxPractises
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenStartDialogue();
        }

        static void OpenStartDialogue()
        {
            Console.Clear();
            Console.WriteLine("Пожалуйста выберите необходимую функцию:\n" +
                "1 - проверка четности числа\n" +
                "2 - подсчёт суммы карт в игре «21»\n" +
                "3 - проверка на простое числом\n" +
                "4 - наименьший элемент в последовательности\n" +
                "5 - Игра «Угадай число»\n" +
                "Esc - завершить работу");

            var key = Console.ReadKey();

            switch (key.Key) {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.D1:
                    OpenCheckOdd();
                    break;
                case ConsoleKey.D2:
                    Open21Counter();
                    break;
                case ConsoleKey.D3:
                    OpenSimpleNumber();
                    break;
                case ConsoleKey.D4:
                    OpenMinimum();
                    break;
                case ConsoleKey.D5:
                    PlayGuessANumber();
                    break;
                default:
                    OpenStartDialogue();
                    break;
            }
        }

        static void OpenCheckOdd()
        {
            Console.Clear();
            Console.WriteLine("Введите желаемое число:");

            if (int.TryParse(Console.ReadLine(), out int num))
                Console.WriteLine($"Число {num} " + (num % 2 == 0 ? "Число четное!" : "Число нечетное!"));
            else
                Console.WriteLine("Введенная строка не чвляется целым числом!");

            Console.WriteLine("Чтобы повторить операцию нажмите любую кнопку. Для выхода нажмите Esc");
            switch (Console.ReadKey().Key) {
                case ConsoleKey.Escape:
                    OpenStartDialogue();
                    return;
                default:
                    OpenCheckOdd();
                    return;
            }
        }

        static void Open21Counter()
        {
            Console.Clear();
            Console.WriteLine("Введите количество карт на руках:");

            if (!int.TryParse(Console.ReadLine(), out int cardCount) || cardCount <= 0) {
                Console.WriteLine("Введенная строка не является целым положительным числом!");
            }
            else {
                int sum = 0;

                for (int i = 0; i < cardCount; i++) {
                    Console.Clear();
                    Console.WriteLine($"Текущая сумма: {sum}\n" +
                        "Введите номинал карты.\n" +
                        "Валет - J\n" +
                        "Дама - Q\n" +
                        "Король - K\n" +
                        "Туз - T");

                    string nominalString = Console.ReadLine();
                    if (int.TryParse(nominalString, out var nominal) && nominal <= 10 && nominal > 0) {
                        sum += nominal;
                        continue;
                    }

                    switch (nominalString) {
                        case "T":
                            sum += 10;
                            continue;
                        case "Q":
                            sum += 10;
                            continue;
                        case "K":
                            sum += 10;
                            continue;
                        case "J":
                            sum += 10;
                            continue;
                    }

                    //Если ни одной проверки не пройдено, останавливаемся на текущей карте
                    i--;
                }

                Console.Clear();
                Console.WriteLine($"Итоговая сумма: {sum}");
            }

            Console.WriteLine("Чтобы повторить операцию нажмите любую кнопку. Для выхода нажмите Esc");
            switch (Console.ReadKey().Key) {
                case ConsoleKey.Escape:
                    OpenStartDialogue();
                    return;
                default:
                    Open21Counter();
                    return;
            }
        }

        static void OpenSimpleNumber()
        {
            Console.Clear();
            Console.WriteLine("Введите жедаемое число:");

            if (int.TryParse(Console.ReadLine(), out int num)) {
                Console.Clear();
                bool isSimple = true;

                int i = 2;
                while (i <= Math.Abs(num) / 2) {
                    if (num % i == 0) {
                        isSimple = false;
                        break;
                    }
                    i++;
                }

                if (isSimple)
                    Console.WriteLine($"Число {num} - простое!");
                else
                    Console.WriteLine($"Число {num} не является простым!");
            }
            else
                Console.WriteLine("Введенная строка не чвляется целым числом!\n");

            Console.WriteLine("Чтобы повторить операцию нажмите любую кнопку. Для выхода нажмите Esc");
            switch (Console.ReadKey().Key) {
                case ConsoleKey.Escape:
                    OpenStartDialogue();
                    return;
                default:
                    OpenSimpleNumber();
                    return;
            }
        }

        static void OpenMinimum()
        {
            Console.Clear();
            Console.WriteLine("Введите количество чисел в последовательности:");

            int min = int.MaxValue;

            if (!int.TryParse(Console.ReadLine(), out int count)) {
                Console.WriteLine("Введенная строка не является целым числом!");
            } else {
                for (int i = 0; i < count; i++) {
                    if (!int.TryParse(Console.ReadLine(), out int num)) {
                        i--;
                        continue;
                    }

                    if (num < min)
                        min = num;
                }

                Console.WriteLine($"Минимальное число в последовательности: {min}");
            }

            Console.WriteLine("Чтобы повторить операцию нажмите любую кнопку. Для выхода нажмите Esc");
            switch (Console.ReadKey().Key) {
                case ConsoleKey.Escape:
                    OpenStartDialogue();
                    return;
                default:
                    OpenMinimum();
                    return;
            }
        }

        static void PlayGuessANumber()
        {
            Console.Clear();
            Console.WriteLine("Введите максимальное число:");

            if (!int.TryParse(Console.ReadLine(), out int max) || max <= 0) {
                Console.WriteLine("Введенная строка не является целым положительным числом!");
            } else {
                Random rand = new Random();
                int correctNum = rand.Next() % (max + 1);
                bool founded = true;

                while (true) {
                    Console.WriteLine("Введите предполагаемое Вами число:");

                    string answer = Console.ReadLine();
                    Console.Clear();

                    if (!int.TryParse(answer, out int num)) {
                        if (answer == "") {
                            founded = false;
                            break;
                        }
                        continue;
                    }

                    if (num == correctNum)
                        break;

                    if (num > correctNum)
                        Console.WriteLine("Загаданное число меньше!");
                    else
                        Console.WriteLine("Загаданное число больше!");
                }

                if (founded)
                    Console.WriteLine("Поздравляю, Вы угадали!");
                Console.WriteLine($"Правильное число - {correctNum}");
            }

            Console.WriteLine("Чтобы повторить начать заново нажмите любую кнопку. Для выхода нажмите Esc");
            switch (Console.ReadKey().Key) {
                case ConsoleKey.Escape:
                    OpenStartDialogue();
                    return;
                default:
                    PlayGuessANumber();
                    return;
            }
        }
    }
}
