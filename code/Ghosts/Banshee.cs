using System.Collections.Generic;
using Phasmophobia.Ghosts.Characteristics;
using Sandbox;

namespace Phasmophobia.Ghosts
{
	[Library( Title = "Banshee" )]
	public class Banshee : BaseGhost
	{
		public override List<ICharacteristic> Characteristics { get; } = new()
		{
			new Fingerprints(),
			new EmfLevelFive(),
			new Fingerprints()
		};
	}
}
