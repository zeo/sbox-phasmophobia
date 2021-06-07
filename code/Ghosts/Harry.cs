using System.Collections.Generic;
using Phasmophobia.Ghosts.Characteristics;
using Sandbox;

namespace Phasmophobia.Ghosts
{
	[Library( Title = "Harry" )]
	public class Harry : BaseGhost
	{
		public override List<ICharacteristic> Characteristics { get; } = new() {new FreezingTemperatures(),};
	}
}
