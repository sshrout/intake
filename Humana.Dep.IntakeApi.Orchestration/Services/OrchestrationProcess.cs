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
		private readonly Dictionary<ProcessingStatusType, List<IOrchestratorHandler>> handlers;
		public OrchestrationProcess(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		private void LoadConfiguration(string processName)
		{
			
		}

		public void RegisterHandler<T>(ProcessingStatusType processingStatusType) where T : IOrchestratorHandler, new()
		{
			var handler = serviceProvider.GetRequiredService<T>() as IOrchestratorHandler;

			if (handlers.TryGetValue(processingStatusType, out var list))
			{
				list.Add(handler!);
			}
			else
			{
				var newList = new List<IOrchestratorHandler>();
				newList.Add(handler!);
				handlers.Add(processingStatusType, newList);
			}
			
		}

		public void ProcessItem(OrchestrationContext context)
		{
			var currentStatus = ProcessingStatusType.Pending;
			var currentHandlers = handlers[currentStatus];

			for (int currentIndex = 0; currentIndex < currentHandlers.Count; currentIndex++)
			{
				var currentStep = currentHandlers[currentIndex];

				currentStep.ProcessItem(context);

				if (context.ProcessingStatus == ProcessingStatusType.Complete)
				{
					return;
				}
				else if (currentStatus != context.ProcessingStatus)
				{
					currentStatus = context.ProcessingStatus;
					currentHandlers = handlers[currentStatus];
					currentIndex = 0;
				}
				else
				{
					// No action.
				}

			}

			
		}
	}
}