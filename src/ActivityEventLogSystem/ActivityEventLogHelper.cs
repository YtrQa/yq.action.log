using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityEventLogSystem
{
	public static class ActivityEventLogHelper
	{
		public static IServiceCollection AddActivityLog(this IServiceCollection services)
		{
			services.AddScoped(typeof(ActivityEventLog<,,>));
			return services;
		}
	}
}
