using Sandbox;

namespace Phasmophobia.Players
{
	public class Inventory : BaseInventory
	{
		public const int MaxItems = 3;
		
		public Inventory(Player owner) : base(owner)
		{
		}

		public override bool CanAdd( Entity ent )
		{
			if ( Count() >= MaxItems )
			{
				return false;
			}

			if ( Contains( ent ) )
			{
				return false;
			}
			
			return base.CanAdd( ent );
		}
	}
}
