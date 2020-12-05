using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataZipper
{
	public class Configuration
	{
		[JsonProperty(PropertyName = "sources")]
		public List<string> SourcePaths { get; set; }

		[JsonProperty(PropertyName = "destination")]
		public string DestinationPath { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "interval")]
		public int Interval { get; set; }

		[JsonProperty(PropertyName = "enabled")]
		public bool Enabled { get; set; }

		[JsonIgnore]
		public string TemporaryPath { get; set; }


		public Configuration()
		{
			SourcePaths = new List<string>();
		}
	}
}
