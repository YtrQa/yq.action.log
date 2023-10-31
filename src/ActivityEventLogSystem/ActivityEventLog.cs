using Microsoft.EntityFrameworkCore;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using ActivityEventLogSystem.Interfaces;

namespace ActivityEventLogSystem
{
	public class ActivityEventLog<TContext,TEnumActivityType,TEnumActorType>
		where TContext : DbContext
		where TEnumActivityType : Enum
		where TEnumActorType : Enum
		
	{
		private readonly TContext _context;
		public ActivityEventLog(TContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task SaveAsync(IActivityLog entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			if(entity.Id==Guid.Empty)  entity.Id = Guid.NewGuid();
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task SaveAsync<TEntitySourceFirst, TEntitySourceSecond> (
			TEntitySourceFirst beforeChange,
			TEntitySourceSecond afterChange,
			List<string> ignoreProperties,
			TEnumActivityType activityType,
			TEnumActorType actorType,
			string actorId,
			string target)
		{
			var compResult = DiffObjects(beforeChange, afterChange, ignoreProperties);

			if (compResult.Differences.Any())
			{
				var payload = JsonConvert.SerializeObject(compResult.Differences.Select(s => new
				{
					Type = s.Object1TypeName ?? s.Object2TypeName,
					Name = s.PropertyName,
					OldValue = s.Object1Value,
					NewValue = s.Object2Value
				}));

				await AddActivity(actorId, target, payload,activityType.ToString(),actorType.ToString());
			}
		}
		
		private async Task AddActivity(
			string actorId,
			string target,
			string payload,
			string activityType,
			string actorType)
		{
				List<Type> typesIActivityLog= _context.Model.GetEntityTypes()
				.Select(e => e.ClrType)
				.Where(t => typeof(IActivityLog).IsAssignableFrom(t))
				.ToList();

				foreach (var type in typesIActivityLog)
				{
					if (Activator.CreateInstance(type) is IActivityLog entity)
					{
						entity.Id = Guid.NewGuid();
						entity.ActivityType = activityType;
						entity.ActorType = actorType;
						entity.Actor = actorId;
						entity.Target = target;
						entity.Payload = payload;
						entity.Timestamp = DateTime.UtcNow;

						await _context.AddAsync(entity);
					}
				}
				await _context.SaveChangesAsync();
			
		}

		private ComparisonResult DiffObjects<TFirst,TSecond>(
			TFirst first,
			TSecond second,
			IEnumerable<string> ignore) 
		{
			var compareLogic = new CompareLogic
			{
				Config =
				{
					MaxDifferences = 99999,
					IgnoreObjectTypes = true,
					MembersToIgnore = ignore?.ToList() ?? new List<string>()
				}
			};

			return compareLogic.Compare(first, second);
		}
	}
}