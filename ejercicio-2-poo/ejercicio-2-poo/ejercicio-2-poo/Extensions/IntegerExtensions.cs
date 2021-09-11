namespace ejercicio_2_poo.Extensions
{
    public static class IntegerExtensions
    {
        public static int DivisionPorCero(this int dividendo)
        {
            return dividendo / 0;
            
        }

        public static int DivisionConParametros(this int dividendo, int divisor)
        {
            return dividendo / divisor;

        }
    }
}
