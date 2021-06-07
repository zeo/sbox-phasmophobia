using Phasmophobia.Players;
using Sandbox;

namespace Phasmophobia.Tools
{
	/// <summary>
	/// A tool can be picked up by player's, it is used to improve gameplay experience.
	/// Example tools are: Flashlight, Thermometer, EMF Meter
	/// Tools are stored in the <see cref="Inventory"/>
	/// </summary>
	public abstract class Tool : BaseWeapon
	{
		public virtual string WorldModelPath => null;

		public override void Spawn()
		{
			base.Spawn();

			if ( !string.IsNullOrEmpty( WorldModelPath ) )
				SetModel( WorldModelPath );
		}

		public override void CreateViewModel()
		{
			Host.AssertClient();

			if ( string.IsNullOrEmpty( ViewModelPath ) )
				return;

			ViewModelEntity = new ToolViewModel {Position = Position, Owner = Owner, EnableViewmodelRendering = true};

			ViewModelEntity.SetModel( ViewModelPath );
		}
	}
}
