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
			sources.Sort(delegate (IConfigurationSource x, IConfigurationSource y) {
				return y.Priority - x.Priority;
			});
			Params = new Hashtable();
			foreach (var source in sources) {
				Hashtable ht;
				try {
					ht = source.Read();
				} catch(Exception exc){
					throw new Exception("Config read failed.", exc);
				}
				foreach (DictionaryEntry de in ht)
					if (!Params.ContainsKey(de.Key))
						Params.Add(de.Key, de.Value);
			}
		}

		public Hashtable Params;
	}
}
