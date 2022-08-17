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
                    "\n6) поиск по издательству \n7) отсортировать книги по году издания " +
                    "\n8) показить все книги \n8) выход");
                
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
                        library.ShowSortByAgeBooks();
                        break;
                    case '8':
                        library.ShowInfo();
                        break;
                    case '9':
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
        private List<Book> _books = new List<Book>();

        public Library()
        {
            _books.Add(new Book("Слимпериада", "Михаил Бабкин", "2008", "Альфа-книга"));
            _books.Add(new Book("Гиперион", "Дэн Симмонс", "2004", "АСТ"));
            _books.Add(new Book("Падение Гипериона", "Дэн Симмонс", "2004", "АСТ"));
            _books.Add(new Book("Орден святого бестселлера", "Генри Лайон Олди", "2006", "ЭКСМО"));
            _books.Add(new Book("Череп на рукаве", "Ник Перумов", "2004", "ЭКСМО"));
            _books.Add(new Book("Череп в небесах", "Ник Перумов", "2005", "ЭКСМО"));
            _books.Add(new Book("Капитал, том 1", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            _books.Add(new Book("Капитал, том 2", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            _books.Add(new Book("Капитал, том 3", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
            _books.Add(new Book("Капитал, том 4", "Карл Маркс", "1989", "ПОЛИТИЗДАТ"));
        }

        public void AddBook()
        {
            _books.Add(GetNewBook());
        }

        public void RemoveBook()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Книжная полка пуста");
            }
            else
            {
                bool isFound = false;
                Book bookToRemove = null;

                Console.WriteLine("Введите название книги которую хоттите убрать с полки:");
                string userInput = Console.ReadLine();

                foreach (Book book in _books)
                {
                    if (book.Title == userInput)
                    {
                        bookToRemove = book;
                        isFound = true;
                    }
                }

                if (isFound)
                {
                    _books.Remove(bookToRemove);
                }
                else
                { 
                    Console.WriteLine($"Книги с названием {userInput} на полке нет");
                }
            }
        }

        public void FindByTitle()
        {
            List <string> titles = new List<string>(0);

            foreach (Book book in _books)
            {
                titles.Add(book.Title);
            }

            Console.WriteLine("Введите название книги которкю хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги с названием " + userInput + ":");
            ShowByAge(FindByType(userInput, titles));
        }

        public void FindByAuthor()
        {
            List<string> authors = new List<string>(0);

            foreach (Book book in _books)
            {
                authors.Add(book.Author);
            }

            Console.WriteLine("Введите имя автора, книги которого хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги написанные " + userInput + ":");
            ShowByAge(FindByType(userInput, authors));
        }

        public void FindByPublicationDate()
        {
            List<string> publicationDate = new List<string>(0);

            foreach (Book book in _books)
            {
                publicationDate.Add(book.PublicationDate);
            }

            Console.WriteLine("Введите год издания книг, которые хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги изданные в " + userInput + " году:");
            ShowList(FindByType(userInput, publicationDate));
        }       

        public void FindByPublishingHous()
        {
            List<string> publishingHous = new List<string>(0);

            foreach (Book book in _books)
            {
                publishingHous.Add(book.PublishingHous);
            }

            Console.WriteLine("Введите издательство книг, которые хотите найти:");
            string userInput = Console.ReadLine();
            Console.WriteLine("Книги выпущенные в издательстве " + userInput + ":");
            ShowByAge(FindByType(userInput, publishingHous));
        }

        public void ShowSortByAgeBooks()
        {
            ShowByAge (_books);
        }

        public void ShowInfo()
        {
            Console.WriteLine("На моей книжной полке сейчас:");

            foreach (Book book in _books)
            {
                book.ShowInfo();
            }
        }

        private void ShowList(List<Book> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Не найдено");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ShowInfo();
                }
            }           
        }

        private void ShowByAge(List<Book> list)
        {
            List<string> publicationDate = new List<string>(0);

            foreach (Book book in list)
            {
                publicationDate.Add(book.PublicationDate);
            }

            ShowList(SortByAge(publicationDate, list));
        }

        private List<Book> SortByAge(List<string> values, List<Book> list)
        {
            List<Book> sortBooks = new List<Book>(0);
            string previousValue = null;

            values.Sort();

            foreach (string value in values)
            {
                if (previousValue != value)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (value == list[i].PublicationDate)
                        {
                            sortBooks.Add(list[i]);
                        }
                    }
                }     
                
                previousValue = value;
            }

            return sortBooks;
        }

        private Book GetNewBook()
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
            return new Book(title, author, publicationDate, publishingHous);
        }

        private List<Book> FindByType(string userInput, List<string> values)
        {
            List<Book> searchList = new List<Book>(0);
            int counter = 0;

            foreach (string value in values)
            {
                if (value == userInput)
                {
                    searchList.Add(_books[counter]);
                }
                
                counter++;
            }
            
            return searchList;
        }
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
