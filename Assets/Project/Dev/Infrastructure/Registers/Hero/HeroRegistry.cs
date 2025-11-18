using Project.Dev.GamePlay.NPC.Player1;

namespace Project.Dev.Infrastructure.Registers.Hero
{
    public class HeroRegistry
    {
        public HeroMove HeroMove { get; private set; }
        
        public void SetMove(HeroMove heroMove) => HeroMove = heroMove;
    }
}
