using Sandbox;

namespace Phasmophobia.Tools
{
	[Library( "phasmophobia_strong_flashlight", Title = "Strong Flashlight" )]
	public partial class StrongFlashlight : Flashlight
	{
		protected override int LightRange => 2056;
		protected override int LightBrightness => 4;
	}
}
