using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex01
{
	class YamlSource : IConfigurationSource
	{
		public string Filename { get; set; }
		public int Priority { get; set; }
		public YamlSource(string filename, int priority) {
			Filename = filename;
			Priority = priority;
		}

		public Hashtable Read() {
			string yaml = File.ReadAllText(Filename);
			YamlDotNet.Serialization.Deserializer yd = new YamlDotNet.Serialization.Deserializer();
			var hty = yd.Deserialize<Hashtable>(yaml);
			return hty;
		}
	}
}
