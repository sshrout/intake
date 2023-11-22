using Humana.Dep.IntakeApi.Orchestration.Interfaces;
using Humana.Dep.IntakeApi.Orchestration.Services;

namespace Humana.Dep.IntakeApi.Core.Processes
{
	public class MedicareOrchestrator : OrchestrationProcess
	{

		public MedicareOrchestrator(IServiceProvider serviceProvider) : base(serviceProvider) { }
	}
}
