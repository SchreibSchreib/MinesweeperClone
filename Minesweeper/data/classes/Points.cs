namespace Minesweeper.data.classes
{
    public class Points
    {
        public Points()
        {
        }
        public int Current { get; set; }

        public void Add()
        {
            Current += 3;
        }
    }
}
