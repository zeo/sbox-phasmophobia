using Sandbox;

namespace Phasmophobia.Entities
{
	/// <summary>
	/// Spawned through Hammer, controlled by the power generated in the building.
	/// Light should be done through Hammer if possible, if not we can create a light which should do the trick.
	/// </summary>
	[Library( "phasmophobia_building_light" )]
	public partial class BuildingLight : ModelEntity
	{
		[HammerProp]
		public bool Active { get; set; }
	}
}
