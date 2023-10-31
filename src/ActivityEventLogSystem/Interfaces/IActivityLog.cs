using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityEventLogSystem.Interfaces
{
	public interface IActivityLog
	{
		Guid Id { get; set; }
		string ActivityType { get; set; }
		string ActorType { get; set; }
		string ActorId { get; set; }
		string Target { get; set; }
		string Payload { get; set; }
		DateTime Timestamp { get; set; }
	}
}
