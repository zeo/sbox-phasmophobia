using System.Linq;
using Sandbox;

namespace Phasmophobia.Entities
{
	/// <summary>
	/// The generator which powers the electronics of the building.
	/// It has a max amount of devices it can power at the same time, when this limit is reached, it shuts down.
	/// </summary>
	[Library( "phasmophobia_power_generator" )]
	public partial class PowerGenerator : ModelEntity
	{
		[Net, Predicted]
		public bool Active { get; set; }
		
		public override void Spawn()
		{
			base.Spawn();
		}

		public void Activate()
		{
		}
		
		public void Deactivate()
		{
			
		}
	}
}
