using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humana.Dep.IntakeApi.Orchestration.Models
{
	public enum ProcessingStatusType
	{
		Pending,
		Retry,
		Exception,
		CriticalError,
		Complete
	}
}
