using Sandbox;

namespace Phasmophobia.Tools
{
	[Library( "phasmophobia_flashlight", Title = "Flashlight" )]
	public partial class Flashlight : Tool
	{
		public override string WorldModelPath => "weapons/rust_pistol/rust_pistol.vmdl";
		public override string ViewModelPath => "weapons/rust_flashlight/v_rust_flashlight.vmdl";

		protected virtual Vector3 LightOffset => Vector3.Forward * 10;
		protected virtual int LightRange => 512;

		private SpotLightEntity WorldLight { get; set; }
		private SpotLightEntity ViewLight { get; set; }

		[Net, Local, Predicted] private bool LightEnabled { get; set; } = true;

		public override void Spawn()
		{
			base.Spawn();

			WorldLight = CreateLight();
			WorldLight.SetParent( this, "slide", new Transform( LightOffset ) );
			WorldLight.EnableHideInFirstPerson = true;
			WorldLight.Enabled = LightEnabled;
		}

		public override void CreateViewModel()
		{
			if ( Local.Pawn.Camera is not FirstPersonCamera )
				return;

			base.CreateViewModel();

			ViewLight = CreateLight();
			ViewLight.SetParent( ViewModelEntity, "light", new Transform( LightOffset ) );
			ViewLight.EnableViewmodelRendering = true;
			ViewLight.Enabled = LightEnabled;
		}

		private SpotLightEntity CreateLight()
		{
			var light = new SpotLightEntity
			{
				Enabled = true,
				DynamicShadows = true,
				Range = LightRange,
				Falloff = 1.0f,
				LinearAttenuation = 0,
				QuadraticAttenuation = 1f,
				Brightness = 2,
				Color = Color.White,
				InnerConeAngle = 20,
				OuterConeAngle = 40,
				FogStength = 1f,
				Owner = Owner
			};

			light.UseFog();

			return light;
		}

		private static SoundEvent ToggleSound = new("sounds/flashlight.vsnd");

		public override void Simulate( Client player )
		{
			base.Simulate( player );

			if ( Input.Pressed( InputButton.Attack1 ) )
			{
				LightEnabled = !LightEnabled;
				
				if (IsClient)
					Sound.FromEntity( ToggleSound.Name, this );
			}

			if ( WorldLight.IsValid() )
				WorldLight.Enabled = LightEnabled;

			if ( ViewLight.IsValid() )
				ViewLight.Enabled = LightEnabled;
		}
	}
}
