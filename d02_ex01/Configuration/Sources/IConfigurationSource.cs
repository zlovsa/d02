using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d02_ex01
{
	interface IConfigurationSource
	{
		public string Filename { get; set; }

		public Hashtable Read();

		public int Priority { get; set; }
	}
}
