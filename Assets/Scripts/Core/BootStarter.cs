using VContainer.Unity;
using VContainer;
using Game.UI;

namespace Game
{
    public class BootStarter : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AssetLoader>(Lifetime.Scoped);
            builder.Register<UIController>(Lifetime.Scoped);
            builder.Register<PopupController>(Lifetime.Scoped).As<PopupController, IStartable>();
            builder.Register<LivesManager>(Lifetime.Scoped).As<LivesManager, IStartable, ITickable>();
            /*
            builder.Register<GameManager>(Lifetime.Scoped).As<GameManager, IStartable>();
            builder.Register<ConfigsLoader>(Lifetime.Scoped);
            builder.Register<CharacterGenerator>(Lifetime.Scoped).As<CharacterGenerator, IStartable>();
            builder.Register<SceneLoader>(Lifetime.Scoped);
            */
        }
    }
}