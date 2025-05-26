namespace WebApi.Combat
{
    public class EloCalculator
    {
        public enum GameOutcome
        {
            Win = 1,
            Loss = 0
        }

        public static void CalculateELO(ref int p1Rating, ref int p2Rating, GameOutcome p1Outcome)
        {
            int eloK = 32;

            double expectation = ExpectationToWin(p1Rating, p2Rating);
            int delta = (int)(eloK * ((int)p1Outcome - expectation));

            p1Rating += delta;
            p2Rating -= delta;
        }

        private static double ExpectationToWin(int p1Rating, int p2Rating)
        {
            return 1 / (1 + Math.Pow(10, (p2Rating - p1Rating) / 400.0));
        }
    }
}
