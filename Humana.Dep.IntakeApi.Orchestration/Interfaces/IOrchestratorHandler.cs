﻿using Humana.Dep.IntakeApi.Orchestration.Models;
using Humana.Dep.IntakeApi.Orchestration.Wrappers;

namespace Humana.Dep.IntakeApi.Orchestration.Interfaces
{
	public interface IOrchestratorHandler
	{
		ProcessingStatusType ProcessItem(OrchestrationContext context);
	}
}
