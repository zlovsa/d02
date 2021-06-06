using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex01
{
	class Configuration
	{
		public Configuration(List<IConfigurationSource> sources) {
			sources.Sort((x, y) => y.Priority - x.Priority);
			Params = new Hashtable();
			foreach (var source in sources) {
				Hashtable ht = source.Read();
				foreach (DictionaryEntry de in ht)
					if (!Params.ContainsKey(de.Key))
						Params.Add(de.Key, de.Value);
			}
		}

		public Hashtable Params;
	}
}
