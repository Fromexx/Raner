namespace Assets.Scripts.GateOperations
{
    public class Subtraction : IGateOperation
    {
        public readonly int CountToSubtract;

        public Subtraction(int countToSubtract)
        {
            CountToSubtract = countToSubtract;
        }

        public int DoOperation(int incomingArmySize) => incomingArmySize - CountToSubtract;
    }
}