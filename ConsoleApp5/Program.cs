using System;

namespace BookTracker
{
    class Program
    {
        static void Main()
        {
            BookStorage storage = new BookStorage();
            storage.Add(new Book("Война и мир", 1225, true, "Роман"));
            storage.Add(new Book("Преступление и наказание", 672, false, "Роман"));
            storage.Add(new Book("Мастер и Маргарита", 480, true, "Мистика"));
            storage.Add(new Book("1984", 320, true, "Антиутопия"));
            storage.Add(new Book("Оно", 1138, false, "Ужасы"));
            storage.Add(new Book("Гарри Поттер и философский камень", 332, true, "Фэнтези"));
            storage.Add(new Book("Дюна", 688, false, "Фантастика"));
            storage.Add(new Book("Три товарища", 384, true, "Роман"));

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Показать все записи");
                Console.WriteLine("2 - Добавить запись");
                Console.WriteLine("3 - Поиск по названию");
                Console.WriteLine("4 - Среднее количество страниц");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            ShowAll(storage);
                            break;
                        case "2":
                            AddBook(storage);
                            break;
                        case "3":
                            SearchByTitle(storage);
                            break;
                        case "4":
                            ShowAveragePages(storage);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный пункт меню.");
                            break;
                    }
                }
                catch (InvalidBookDataException ex)
                {
                    Console.WriteLine($"Ошибка данных: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        static void ShowAll(BookStorage storage)
        {
            if (storage.Count == 0)
            {
                Console.WriteLine("Записей пока нет.");
                return;
            }
            Console.WriteLine($"{"Название",-35} {"Страниц",8} {"Прочитана",12} {"Жанр",-15}");
            for (int i = 0; i < storage.Count; i++)
            {
                Book b = storage[i];
                Console.WriteLine($"{b.Title,-35} {b.Pages,8} {(b.IsFinished ? "Да" : "Нет"),12} {b.Genre,-15}");
            }
        }

        static void AddBook(BookStorage storage)
        {
            Console.Write("Введите название: ");
            string title = Console.ReadLine();

            Console.Write("Введите количество страниц: ");
            string pagesInput = Console.ReadLine();
            if (!int.TryParse(pagesInput, out int pages))
            {
                Console.WriteLine("Некорректное число страниц.");
                return;
            }

            Console.Write("Прочитана? (да/нет): ");
            string finishedInput = Console.ReadLine()?.ToLower();
            bool isFinished = finishedInput == "да";

            Console.Write("Введите жанр: ");
            string genre = Console.ReadLine();

            Book newBook = new Book(title, pages, isFinished, genre);
            storage.Add(newBook);
            Console.WriteLine("Запись добавлена.");
        }

        static void SearchByTitle(BookStorage storage)
        {
            Console.Write("Введите подстроку для поиска: ");
            string query = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Поисковый запрос не может быть пустым.");
                return;
            }
            bool found = false;
            for (int i = 0; i < storage.Count; i++)
            {
                if (storage[i].Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"{i + 1}. {storage[i].Title} ({storage[i].Pages} стр., {(storage[i].IsFinished ? "прочитана" : "не прочитана")}, {storage[i].Genre})");
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Ничего не найдено.");
        }

        static void ShowAveragePages(BookStorage storage)
        {
            if (storage.Count == 0)
            {
                Console.WriteLine("Нет записей для подсчёта.");
                return;
            }
            int sum = 0;
            for (int i = 0; i < storage.Count; i++)
                sum += storage[i].Pages;
            double average = (double)sum / storage.Count;
            Console.WriteLine($"Среднее количество страниц: {average:F2}");
        }
    }
}