using System.Collections.Generic;
using Phasmophobia.Ghosts.Characteristics;
using Sandbox;

namespace Phasmophobia.Ghosts
{
	[Library( "phasmophobia_ghost_harry" )]
	public class Harry : BaseGhost
	{
		public override List<ICharacteristic> Characteristics { get; } = new() {new FreezingTemperatures(),};
	}
}
