using Phasmophobia.Tools;
using Sandbox;

namespace Phasmophobia.Players
{
	[Library( "phasmophobia_player" )]
	public partial class Player : Sandbox.Player
	{
		private ICamera LastCamera { get; set; }
		
		public Player()
		{
			Inventory = new Inventory( this );
		}

		public override void Spawn()
		{
			base.Spawn();

			LastCamera = new FirstPersonCamera();
		}

		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			Camera = LastCamera;

			if ( DevController is NoclipController )
			{
				DevController = null;
			}

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			Inventory.Add( new Flashlight(), true );
			Inventory.Add( new StrongFlashlight() );

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			if ( Input.ActiveChild is not null )
			{
				ActiveChild = Input.ActiveChild;
			}
			
			SimulateActiveChild( cl, ActiveChild );
		}

		[ClientCmd( "dwa" )]
		public static void tes()
		{
			Local.Pawn.Inventory.SetActiveSlot(1, false);
		}
	}
}
