using Project.Dev.Meta.UI.HudController;

namespace Project.Dev.Infrastructure.Registers.UI
{
    public class UiRegistry
    {
        public HudController HudController { get; private set; }

        public void SetHud(HudController hudController) => HudController = hudController;
    }
}
