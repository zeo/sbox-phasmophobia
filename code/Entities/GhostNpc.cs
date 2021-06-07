using Phasmophobia.Ghosts;
using Phasmophobia.Utils;
using Sandbox;

namespace Phasmophobia.Entities
{
	/// <summary>
	/// The actual entity with which the players interact.
	/// This class only contains behaviour such as movement, current state and damage.
	/// Actual ghost data would be located in the <see cref="BaseGhost"/>
	/// </summary>
	[Library( "phasmophobia_ghost_npc" )]
	public partial class GhostNpc : AnimEntity
	{
		public string Name { get; set; }
		public BaseGhost Ghost { get; set; }

		public GhostNpc()
		{
			Name = GhostUtils.GenerateName();
			Ghost = new Harry();
		}
	}
}
