using Source.Game;
using Source.Player;
using Source.Player.Mono;
using Source.UI;
using Source.UI.Mono;
using Source.Weapon;
using Source.Weapon.Mono;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.Bootstrap
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private TouchInputTarget touchInputTarget;
        [SerializeField] private ArcherView archerView;
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private CoinPool coinPool;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<UIPresenter>();
            builder.RegisterEntryPoint<PlayerPresenter>();
            builder.RegisterEntryPoint<WeaponPresenter>();

            builder.Register<GameStats>(Lifetime.Singleton);
            builder.Register<CoinFactory>(Lifetime.Singleton);
            
            builder.Register<ArcherTarget>(Lifetime.Singleton);
            builder.Register<ArcherAnimation>(Lifetime.Singleton);

            builder.Register<BulletMove>(Lifetime.Singleton);

            builder.RegisterComponent(touchInputTarget);
            builder.RegisterComponent(archerView);
            builder.RegisterComponent(bulletPool);
            builder.RegisterComponent(coinPool);
        }
    }
}
