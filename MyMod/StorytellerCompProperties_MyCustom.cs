using RimWorld;
using Verse;

namespace MyMod
{
	[DefOf]
	public class StorytellerCompProperties_MyCustom : StorytellerCompProperties
	{
		public IncidentCategoryDef category;

		public StorytellerCompProperties_MyCustom()
		{
			this.compClass = typeof(StorytellerComp_Network);
			Log.TryOpenLogWindow();
			Log.Message("I am loaded!");
		}
	}
}
