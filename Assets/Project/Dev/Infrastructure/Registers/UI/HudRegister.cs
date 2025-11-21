using Project.Dev.Infrastructure.Registers.Interface;
using Project.Dev.Meta.UI.HudController;
using UnityEngine;

namespace Project.Dev.Infrastructure.Registers.UI
{
    public class HudRegister : IUiRegistery
    {
        private readonly UiRegistry _hud;

        public HudRegister(UiRegistry hud) => _hud = hud;

        public void Registry(GameObject ui)
        {
            var component = ui.GetComponent<HudController>();
            _hud.SetHud(component);

        }
    }
}
