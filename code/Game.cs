using System.Linq;
using Phasmophobia.Entities;
using Phasmophobia.Ghosts;
using Phasmophobia.UI.Hud;
using Sandbox;
using Player = Phasmophobia.Players.Player;

namespace Phasmophobia
{
	[Library( "phasmophobia" )]
	public partial class Game : Sandbox.Game
	{
		public static Game Instance
		{
			get => Current as Game;
		}

		public GhostNpc GhostNpc { get; set; }

		public BaseGhost Ghost
		{
			get => GhostNpc.Ghost;
		}

		public readonly GhostRoom Room;

		private Hud ActiveHud { get; set; }
		
		public Game()
		{
			if ( IsServer )
			{
				ActiveHud = new Hud();
			}
			
			Room = All.OfType<GhostRoom>().FirstOrDefault();
		}

		[Event.Hotload]
		public void OnHotReloaded()
		{
			if ( ActiveHud is not null )
			{
				ActiveHud.Delete();
			}

			ActiveHud = new Hud();
		}

		public override void ClientJoined( Client cl )
		{
			base.ClientJoined( cl );

			var player = new Player();
			player.Respawn();

			cl.Pawn = player;
		}
	}
}
