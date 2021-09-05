namespace DarkLegion.Unit.Stat
{
    public class Movement : BaseStat
    {
        protected override void Init()
        {
            Value = BaseStats.MaxStep;
        }
    }
}