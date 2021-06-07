using System.Collections.Generic;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using Player = Phasmophobia.Players.Player;

namespace Phasmophobia.UI.Hud
{
	public class Inventory : Panel
	{
		private readonly List<InventorySlot> Slots = new();

		public Inventory()
		{
			for ( int i = 0; i < Players.Inventory.MaxItems; i++ )
			{
				var slot = AddChild<InventorySlot>();
				Slots.Add( slot );
			}
		}

		public override void Tick()
		{
			base.Tick();

			if ( Local.Pawn is not Player player ) return;
			if ( player.Inventory is null ) return;

			for (var i = 0; i < Slots.Count; i++)
			{
				Slots[i].Update( i, player.Inventory.GetSlot( i ), player.Inventory.GetActiveSlot() == i );
			}
		}

		[Event.BuildInput]
		public void OnBuildInput( InputBuilder input )
		{
			if ( Local.Pawn is not Player player ) return;

			var inv = player.Inventory;
			if ( inv is null ) return;

			if ( input.Pressed( InputButton.Slot1 ) ) input.ActiveChild = inv.GetSlot( 0 );
			if ( input.Pressed( InputButton.Slot2 ) ) input.ActiveChild = inv.GetSlot( 1 );
		}
	}

	public class InventorySlot : Panel
	{
		private readonly Label _slot;
		private readonly Image _icon;
		
		public InventorySlot()
		{
			_slot = Add.Label( classname: "Slot" );
			_icon = Add.Image( classname: "Icon" );
		}

		public void Update( int slot, Entity ent, bool isActive )
		{
			// Add +1 for UX purposes, matches with the input
			_slot.Text = (slot + 1).ToString();
			SetClass( "Active", isActive );
			
			if ( ent is null || !ent.IsValid() )
				return;

			_icon.SetTexture( "/ui/phasmophobia/flashlight.png" );

			var attr = Library.GetAttribute( ent.GetType() );
		}
	}
}
