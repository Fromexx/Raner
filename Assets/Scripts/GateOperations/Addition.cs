public class Addition : IGateOperation
{
    public readonly int CountToAdd;
 
    public Addition(int countToAdd)
    {
        CountToAdd = countToAdd;
    }
    public int DoOperation(int incomingArmySize) => incomingArmySize + CountToAdd;
}
