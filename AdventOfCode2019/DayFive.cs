using AdventOfCode2019.Intcode;
namespace AdventOfCode2019
{
    public static class DayFive
    {
        public static void PartOneAndTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("5");

            IntcodeComputer i = new IntcodeComputer(data);
            i.Run();
        }
    }
}
