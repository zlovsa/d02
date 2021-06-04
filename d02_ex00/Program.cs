using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using d02_ex00;

List<ISearchable> books = new List<ISearchable>();
string booksjson = File.ReadAllText("book_reviews.json");
books = JsonSerializer.Deserialize<List<ISearchable>>(booksjson);

List<ISearchable> movies = new List<ISearchable>();
string moviesjson = File.ReadAllText("book_reviews.json");
movies = JsonSerializer.Deserialize<List<ISearchable>>(moviesjson);

Console.WriteLine("> Input search text:");
string query = Console.ReadLine();

var booksQuery =
	from book in books
	where book.Title.Contains(query)
	select book;

var moviesQuery =
	from movie in movies
	where movie.Title.Contains(query)
	select movie;

Console.WriteLine($"Items found: {booksQuery.Count() + moviesQuery.Count()}");
Console.WriteLine();
Console.WriteLine($"Book search result [{booksQuery.Count()}]:");
booksQuery.ToList().ForEach(x => x.ToString());
Console.WriteLine();
Console.WriteLine($"Movie search result [{moviesQuery.Count()}]:");
moviesQuery.ToList().ForEach(x => x.ToString());