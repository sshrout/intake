namespace Humana.Dep.IntakeApi.Orchestration.Interfaces
{
	public interface IOrchestrationProcess
	{
		void RegisterHandler<T>() where T : IOrchestratorHandler, new();

	}
}
