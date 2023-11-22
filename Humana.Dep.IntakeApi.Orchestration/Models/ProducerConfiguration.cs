using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humana.Dep.IntakeApi.Orchestration.Models
{
	public class ProducerConfiguration
	{
		public string? TopicName { get; set; }
		public bool AvroEnabled { get; set; }
	}
}
