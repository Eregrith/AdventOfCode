namespace AdventOfCode2023.GondolaLift
{
    internal class EngineGear
    {
        private EnginePart enginePart1;
        private EnginePart enginePart2;

        public EngineGear(EnginePart enginePart1, EnginePart enginePart2)
        {
            this.enginePart1 = enginePart1;
            this.enginePart2 = enginePart2;
        }

        public int Ratio => enginePart1.Number * enginePart2.Number;
    }
}