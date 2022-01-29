namespace Assets.Scripts.Trophies
{
    public class StatMod
    {
        public readonly Stat Stat;
        public readonly int Mod;

        public StatMod(ModifierParameter parameter)
        {
            Stat = parameter.Stat;
            Mod = parameter.StatChange;
        }
    }
}