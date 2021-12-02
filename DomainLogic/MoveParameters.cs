namespace DomainLogic
{
    public class MoveParameters
    {
        public Direction Direction { get; set; }

        public int Distance { get; set; }

        public MoveParameters(Direction direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }
    }
}
