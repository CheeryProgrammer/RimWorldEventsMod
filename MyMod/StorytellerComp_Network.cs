using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMod
{
	public class StorytellerComp_Network: StorytellerComp
	{
		protected StorytellerCompProperties_MyCustom Props
		{
			get
			{
				return (StorytellerCompProperties_MyCustom)this.props;
			}
		}

		public StorytellerComp_Network()
		{
			DebugLogger.Log("StorytellerComp_Network constructor");
		}

		public override IEnumerable<FiringIncident> MakeIntervalIncidents(IIncidentTarget target)
		{
			
			DebugLogger.Log("Make interval incidents");
			yield return new FiringIncident(IncidentDefOf.RaidEnemy, this, new IncidentParms { target = target, points = StorytellerUtility.DefaultThreatPointsNow(target)});
		}
	}
}
