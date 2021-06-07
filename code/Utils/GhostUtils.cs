using System;
using System.Collections.Generic;
using System.Linq;
using Phasmophobia.Ghosts;
using Phasmophobia.Ghosts.Characteristics;
using Sandbox;

namespace Phasmophobia.Utils
{
	public static class GhostUtils
	{
		private static readonly string[] FirstNames = {
			"Mex", "Felien", "Clim"
		};

		private static readonly string[] LastNames =
		{
			"de Loo", "Boumans"
		};
			
			
		/// <summary>
		/// Generates a random name for the ghost
		/// </summary>
		/// <returns>A random name</returns>
		public static string GenerateName()
		{
			return Rand.FromArray( FirstNames ) + " " + Rand.FromArray( LastNames );
		}

		public static BaseGhost GetGhostByCharacteristics(List<ICharacteristic> characteristics)
		{
			IEnumerable<Type> ghosts = Library.GetAll<BaseGhost>();

			foreach (var ghost in ghosts)
			{
				if ( typeof(BaseGhost) != ghost ) continue;
				
			}

			return null;
		}
	}
}
