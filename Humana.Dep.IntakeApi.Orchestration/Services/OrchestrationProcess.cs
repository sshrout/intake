using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humana.Dep.IntakeApi.Orchestration.Interfaces;
using Humana.Dep.IntakeApi.Orchestration.Models;
using Humana.Dep.IntakeApi.Orchestration.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace Humana.Dep.IntakeApi.Orchestration.Services
{
	public class OrchestrationProcess : IOrchestrationProcess
	{
		private readonly IServiceProvider serviceProvider;
		private readonly List<IOrchestratorHandler> handlers;
		public OrchestrationProcess(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}


		public void RegisterHandler<T>() where T : IOrchestratorHandler, new()
		{
			var handler = serviceProvider.GetRequiredService<T>() as IOrchestratorHandler;
			handlers.Add(handler!);
		}

		public void ProcessItem(OrchestrationContext context)
		{
			foreach (var handler in handlers)
			{
				var result = handler.ProcessItem(context);

				switch (result)
				{
					case ProcessingResult.CriticalError:

					case ProcessingResult.StopProcessing:
						break;
				}
			}
		}
	}
}