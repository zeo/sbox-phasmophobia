using Sandbox.UI;

namespace Phasmophobia.UI.Hud
{
	public class Hud : Sandbox.HudEntity<RootPanel>
	{
		public Hud()
		{
			if ( !IsClient )
				return;
			
			RootPanel.StyleSheet.Load( "/UI/Hud/Hud.scss" );
			
			RootPanel.AddChild<Inventory>();
		}
	}
}
