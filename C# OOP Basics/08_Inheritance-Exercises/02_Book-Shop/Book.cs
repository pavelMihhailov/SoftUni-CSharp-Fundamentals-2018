using System;
using System.Text;

public class Book
{
    private string author;
    private decimal price;
    private string title;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Price = price;
        this.Author = author;
    }

    public virtual decimal Price
    {
        get => this.price;
        set
        {
            if (value <= 0) throw new ArgumentException("Price not valid!");
            this.price = value;
        }
    }

    private string Author
    {
        get => this.author;
        set
        {
            char letter = value.Split()[1][0];
            if (char.IsDigit(letter)) throw new ArgumentException("Author not valid!");
            this.author = value;
        }
    }

    private string Title
    {
        get => this.title;
        set
        {
            if (value.Length < 3) throw new ArgumentException("Title not valid!");
            this.title = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Type: {this.GetType().Name}");
        builder.AppendLine($"Title: {this.Title}");
        builder.AppendLine($"Author: {this.Author}");
        builder.Append($"Price: {this.Price:f2}");
        return builder.ToString();
    }
}