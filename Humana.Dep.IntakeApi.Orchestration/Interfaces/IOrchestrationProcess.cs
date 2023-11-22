using Humana.Dep.IntakeApi.Orchestration.Models;

namespace Humana.Dep.IntakeApi.Orchestration.Interfaces
{
	public interface IOrchestrationProcess
	{
		void RegisterHandler<T>(ProcessingStatusType processingStatusType) where T : IOrchestratorHandler, new();

	}
}
