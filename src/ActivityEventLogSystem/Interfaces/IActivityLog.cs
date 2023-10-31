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
		//Activity type is the name of the activity
		string ActivityType { get; set; }
		//Actor type is the name of the actor
		string ActorType { get; set; }
		//Actor is the id of the actor
		string Actor { get; set; }
		//Target is the id of the target
		string Target { get; set; }
		//Payload is the json of the changes
		string Payload { get; set; }
		//Timestamp is the time of the activity
		DateTime Timestamp { get; set; }
	}
}