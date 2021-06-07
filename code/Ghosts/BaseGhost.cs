using System.Collections.Generic;
using Phasmophobia.Ghosts.Characteristics;

namespace Phasmophobia.Ghosts
{
	public abstract class BaseGhost
	{
		public abstract List<ICharacteristic> Characteristics { get; }
	}
}
