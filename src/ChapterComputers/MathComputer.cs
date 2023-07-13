namespace AlgorithmsNStructures.files_to_check
{
    public class MathComputer
    {
        public long Factorial(int n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
    }
}
