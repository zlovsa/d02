using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace d02_ex00
{
	class Movie : ISearchable
	{
		[JsonPropertyName("title")]
		public string Title { get; set; }
		[JsonPropertyName("mpaa_rating")]
		public string Rating { get; set; }
		[JsonPropertyName("critics_pick")]
		public int intIsCriticsPick { get; set; }
		public bool IsCriticsPick => intIsCriticsPick == 1;
		[JsonPropertyName("summary_short")]
		public string SummaryShort { get; set; }

		public class Link
		{
			[JsonPropertyName("url")]
			public string Url { get; set; }
		}
		[JsonPropertyName("link")]
		public Link link { get; set; }

		public string Url => link.Url;

		public override string ToString() {
			return $"{Title.ToUpper()}{(IsCriticsPick ? " [NYT critic’s pick]" : "")}{Environment.NewLine}"
				+ $"{SummaryShort}{Environment.NewLine}"
				+ $"{Url}";
;		}
	}
}
