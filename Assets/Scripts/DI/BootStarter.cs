using VContainer.Unity;
using VContainer;
using Game.UI;

namespace Game
{
    public class BootStarter : LifetimeScope
    {
		protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UIController>(Lifetime.Scoped);
            builder.Register<PopupController>(Lifetime.Scoped).As<PopupController, IStartable>();
            builder.Register<DailyBonusController>(Lifetime.Scoped).As<DailyBonusController, IStartable>();
            builder.Register<LivesManager>(Lifetime.Scoped).As<LivesManager, IStartable, ITickable>();
            builder.RegisterComponentInHierarchy<AssetLoader>();
		}       
    }
}