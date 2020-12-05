using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataZipper.Models
{
	public class Configurations
	{
		[JsonProperty(PropertyName = "configurations")]
		public List<Configuration> DataZipperConfigurations { get; set; }
	}
}
