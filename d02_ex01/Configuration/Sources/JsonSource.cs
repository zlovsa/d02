using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace d02_ex01
{
	class JsonSource : IConfigurationSource
	{
		public string Filename { get; set; }
		public int Priority { get; set; }
		public JsonSource(string filename, int priority) {
			Filename = filename;
			Priority = priority;
		}

		public Hashtable Read() {
			string json = File.ReadAllText(Filename);
			var htj = JsonSerializer.Deserialize<Hashtable>(json);
			return htj;
		}
	}
}
