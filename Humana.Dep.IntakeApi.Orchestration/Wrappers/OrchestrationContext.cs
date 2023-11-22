using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Humana.Dep.IntakeApi.Kafka.Models;
using Humana.Dep.IntakeApi.Orchestration.Models;

namespace Humana.Dep.IntakeApi.Orchestration.Wrappers
{
	public class OrchestrationContext
	{
		private readonly Dictionary<string, object?> contextItems = new();
		public List<MessageProductionRequest> MessageProductionRequests { get;  }= new ();
		public Message<byte[], byte[]> Request { get; set; }
		public ProcessingStatusType ProcessingStatus { get; set; }

		public OrchestrationContext(Message<byte[], byte[]> request)
		{
			Request = request;
		}

		public void SetContextItem(string key, object? value)
		{
			contextItems[key] = value;
		}

		public object? GetContextItem(string key)
		{
			return contextItems.TryGetValue(key, out var item) ? item : null;
		}

		public object? this[string key] {
			get => GetContextItem(key);
			set => SetContextItem(key, value);
		}

		public void AddMessageProductionRequest(MessageProductionRequest messageProductionRequest)
		{
			MessageProductionRequests.Add(messageProductionRequest);
		}



	}
}
