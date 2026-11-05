namespace BookTracker
{
    public class Book
    {
        private string title;
        private int pages;
        private bool isFinished;
        private string genre;

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidBookDataException("Название книги не может быть пустым.");
                title = value;
            }
        }

        public int Pages
        {
            get => pages;
            set
            {
                if (value <= 0)
                    throw new InvalidBookDataException("Количество страниц должно быть положительным.");
                pages = value;
            }
        }

        public bool IsFinished
        {
            get => isFinished;
            set => isFinished = value;
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidBookDataException("Жанр не может быть пустым.");
                genre = value;
            }
        }

        public Book(string title, int pages, bool isFinished, string genre)
        {
            Title = title;
            Pages = pages;
            IsFinished = isFinished;
            Genre = genre;
        }

        public static bool operator ==(Book a, Book b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Title == b.Title && a.Pages == b.Pages && a.IsFinished == b.IsFinished && a.Genre == b.Genre;
        }

        public static bool operator !=(Book a, Book b) => !(a == b);

        public override bool Equals(object obj) => obj is Book other && this == other;

        public override int GetHashCode() => HashCode.Combine(Title, Pages, IsFinished, Genre);
    }
}