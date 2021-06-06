using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d02_ex00
{
	class Book : ISearchable
	{
		public class BookDetails
		{
			[JsonPropertyName("title")]
			public string Title { get; set; }
			[JsonPropertyName("author")]
			public string Author { get; set; }
			[JsonPropertyName("description")]
			public string SummaryShort { get; set; }
		}

		[JsonPropertyName("book_details")]
		public List<BookDetails> bookDetails { get; set; }

		public string Title => bookDetails[0].Title;
		public string Author { get => bookDetails[0].Author; }
		public string SummaryShort { get => bookDetails[0].SummaryShort; }
		[JsonPropertyName("rank")]
		public int Rank { get; set; }
		[JsonPropertyName("list_name")]
		public string ListName { get; set; }
		[JsonPropertyName("amazon_product_url")] 
		public string Url { get; set; }

		public override string ToString() {
			return $"{Title} by {Author} [{Rank} on NYT’s {ListName}]{Environment.NewLine}"
				+$"{SummaryShort}{Environment.NewLine}"
				+$"{Url}";
		}
	}
}
