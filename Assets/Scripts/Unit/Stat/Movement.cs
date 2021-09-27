namespace DarkLegion.Unit.Stat
{
    public class Movement : BaseStat
    {
        public const int Cost = 1;

        protected override void Init()
        {
            Value = BaseStats.Movement;
        }
    }
}