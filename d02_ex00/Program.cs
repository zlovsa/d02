using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using d02_ex00;

var media = new List<ISearchable>();

List<T> Deserialize<T>(string jsonfile) {
	string json = File.ReadAllText(jsonfile);
	var jdoc = JsonDocument.Parse(json);
	var results = jdoc.RootElement.GetProperty("results");
	return JsonSerializer.Deserialize<List<T>>(results.GetRawText());
}

try {
	media.AddRange(Deserialize<Book>("book_reviews.json"));
	media.AddRange(Deserialize<Movie>("movie_reviews.json"));
} catch {
	Console.WriteLine("Error reading json files.");
	return;
}

Console.WriteLine("> Input search text:");
string query = Console.ReadLine();

var mediaQuery =
	from item in media
	where item.Title.Contains(query ?? string.Empty, StringComparison.OrdinalIgnoreCase)
	select item;

Console.WriteLine($"Items found: {mediaQuery.Count()}");

void PrintFilter<T>(IEnumerable<ISearchable> query) {
	var typeQuery =
		from item in query
		where item is T
		select item;
	Console.WriteLine($"{Environment.NewLine}{typeof(T).Name} search result [{typeQuery.Count()}]:");
	Console.WriteLine(string.Join(Environment.NewLine, typeQuery.Select(q => $"- {q}")));
}

PrintFilter<Book>(mediaQuery);
PrintFilter<Movie>(mediaQuery);