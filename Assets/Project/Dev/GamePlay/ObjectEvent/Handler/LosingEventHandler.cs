using Project.Dev.GamePlay.ObjectEvent.Event;
using Project.Dev.Infrastructure.Registers.Hero;
using Project.Dev.Infrastructure.Registers.UI;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.ObjectEvent.Handler
{
    public class LosingEventHandler : IObjectEventHandler<LosingEvent>
    {
        private UiRegistry _uiRegistry;
        private HeroRegistry _heroRegistry;

        [Inject]
        private void Construct(UiRegistry uiRegistry, HeroRegistry heroRegistry)
        {
            _uiRegistry = uiRegistry;
            _heroRegistry = heroRegistry;
        }

        public void Handle(LosingEvent obj)
        {
            GameObject trigger = obj.Object;
            _heroRegistry.HeroMove.Destroy();
            _uiRegistry.HudController.MainMenuOn();
            _uiRegistry.HudController.NextLvlOff();
            trigger.GetComponent<Collider2D>().enabled = false;
        }
    }
}
