using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isContinue = true;

            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("1) добавить книгу \n2) убрать книгу " +
                    "\n3) поиск по названию \n4) поиск по автору \n5) поиск по году издания " +
                    "\n6) поиск по издательству \n7) показить все книги \n8) выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        library.AddBook();
                        break;
                    case '2':
                        library.RemoveBook();
                        break;
                    case '3':
                        library.FindByTitle();
                        break;
                    case '4':
                        library.FindByAuthor();
                        break;
                    case '5':
                        library.FindByPublicationDate();
                        break;
                    case '6':
                        library.FindByPublishingHous();
                        break;
                    case '7':
                        library.ShowInfo();
                        break;
                    case '8':
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Неверно выбрана команда");
                        break;
                }

                Console.ReadKey(true);
            }
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public Library()
        {
            books.Add(new Book("Слимпериада", "Михаил Бабкин", "2008", "Альфа-книга"));
            books.Add(new Book("Гиперион", "Дэн Симмонс", "2004", "АСТ"));
            books.Add(new Book("Падение Гипериона", "Дэн Симмонс", "2004", "АСТ"));
            books.Add(new Book("Орден святого бестселлера", "Генри Лайон Олди", "2006", "ЭКСМО"));
            books.Add(new Book("Череп на рукаве", "Ник Перумов", "2004", "ЭКСМО"));
            books.Add(new Book("Череп в небесах", "Ник Перумов", "2005", "ЭКСМО"));
            books.Add(new Book("Капитал, том 1", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            books.Add(new Book("Капитал, том 2", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            books.Add(new Book("Капитал, том 3", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            books.Add(new Book("Капитал, том 4", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
        }

        public void AddBook()
        {
            Console.WriteLine("Добавить книгу:");
            Console.WriteLine("Введите название книги:");
            string title = Console.ReadLine();
            Console.WriteLine("Введите автора книги:");
            string author = Console.ReadLine();
            Console.WriteLine("Введите дату издания книги:");
            string publicationDate = Console.ReadLine();
            Console.WriteLine("Введите издательтво выпустившее книгу:");
            string publishingHous = Console.ReadLine();              
            books.Add(new Book(title, author, publicationDate, publishingHous));
        }

        public void RemoveBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Книжная полка пуста");
            }
            else
            {
                bool isFound = false;
                Book bookToRemove = null;

                Console.WriteLine("Введите название книги которую хоттите убрать с полки:");
                string userInput = Console.ReadLine();

                foreach (Book book in books)
                {
                    if (book.Title == userInput)
                    {
                        bookToRemove = book;
                        isFound = true;
                    }
                }

                if (isFound)
                {
                    books.Remove(bookToRemove);
                }
                else
                { 
                    Console.WriteLine($"Книги с названием {userInput} на полке нет");
                }
            }
        }

        public void FindByTitle()
        {
            Console.WriteLine("Введите название книги которую хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги написанные " + userInput + ":");
            FindByType(userInput, SearchType.Title);
        }

        public void FindByAuthor()
        {
            Console.WriteLine("Введите имя автора, книги которого хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги написанные " + userInput + ":");
            FindByType(userInput, SearchType.Author);
        }

        public void FindByPublicationDate()
        {
            Console.WriteLine("Введите год издания книг, которые хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги изданные в " + userInput + " году:");
            FindByType(userInput, SearchType.PublicationDate);

        }

        public void FindByPublishingHous()
        {
            Console.WriteLine("Введите издательство, книги которого хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги выпущенные в издательстве " + userInput + ":");
            FindByType(userInput, SearchType.PublishingHous); 
        }

        public void ShowInfo()
        {
            Console.WriteLine("На моей книжной полке сейчас:");

            foreach (Book book in books)
            {
                book.ShowInfo();
            }
        }

        private void FindByType(string userInput, SearchType type)
        {
            bool isFound = false;

            foreach (Book book in books)
            {
                if (book.Title == userInput && type == SearchType.Title)
                {
                    book.ShowInfo();
                    isFound = true;
                }

                if (book.Author == userInput && type == SearchType.Author)
                {
                    book.ShowInfo();
                    isFound = true;
                }

                if (book.PublicationDate == userInput && type == SearchType.PublicationDate)
                {
                    book.ShowInfo();
                    isFound = true;
                }

                if (book.PublishingHous == userInput && type == SearchType.PublishingHous)
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Не найдено");
            }
        }
    }

    enum SearchType
    {
        Title, 
        Author, 
        PublicationDate, 
        PublishingHous,
    }

    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string PublicationDate { get; }
        public string PublishingHous { get; }

        public Book(string title, string author, string publicationDate, string publishingHous)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
            PublishingHous = publishingHous;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Title}. Автор: {Author}. Год издания: {PublicationDate}. Издательтво: {PublishingHous}");
        }
    }
}
