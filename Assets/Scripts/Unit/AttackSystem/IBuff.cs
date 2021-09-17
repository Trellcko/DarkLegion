namespace DarkLegion.Unit.AttackSystem
{
    public interface IBuff
    {
        public bool IsFixed { get; }
        public bool IsPositiveBuff { get; }
        public bool IsInfinity { get; }
        public bool IsBuffActionCompleted { get; }

        public float Value { get; }

        public void Do();
        public void Undo();
        public void DecreaseDuration();
    }
}