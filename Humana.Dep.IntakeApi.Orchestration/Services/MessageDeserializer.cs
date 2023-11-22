using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humana.Dep.IntakeApi.Orchestration.Interfaces;
using Humana.Dep.IntakeApi.Orchestration.Models;
using Humana.Dep.IntakeApi.Orchestration.Wrappers;

namespace Humana.Dep.IntakeApi.Kafka
{
	public class MessageDeserializer : IOrchestratorHandler
	{
		public ProcessingStatusType ProcessItem(OrchestrationContext context)
		{
			throw new NotImplementedException();
		}
	}
}
