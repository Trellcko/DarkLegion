namespace DarkLegion.Utils
{
    public static class MathExtensions
    {
        private const int MaxPrecent = 100;

        public static float CalculateValueFromPrecent(float maxValue, float precent)
        {
            return (maxValue * precent) / MaxPrecent;
        }
    }
}