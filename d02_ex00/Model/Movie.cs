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
		public bool IsCriticsPick { get; set; }
		[JsonPropertyName("summary_short")]
		public string SummaryShort { get; set; }
		[JsonPropertyName("url")]
		public string Url { get; set; }

		public override string ToString() {
			return $"- {Title}" + (IsCriticsPick ? "[NYT critic’s pick]" : "") + Environment.NewLine
				+ $"{SummaryShort}{Environment.NewLine}"
				+ $"{Url}{Environment.NewLine}";
;		}
	}
}
