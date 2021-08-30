namespace DarkLegion.Unit {
    public class Movement : Stat
    {
        protected override void Init()
        {
            Value = BaseStats.MaxStep;
        }
    }
}