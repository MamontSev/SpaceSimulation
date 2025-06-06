using SpaceSimulation.UI.MainMenu.HUD;

using Zenject;

namespace SpaceSimulation.Installer
{
	public class MenuInstaller:MonoInstaller
	{
		public override void InstallBindings()
		{
			BindMainMenuHudFactory();
		}

		private void BindMainMenuHudFactory()
		{
			Container
			.Bind<MainMenuHudFactory>()
			.FromComponentInHierarchy()
			.AsSingle()
			.NonLazy();
		}

	}
}
