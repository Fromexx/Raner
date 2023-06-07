public class Division : IGateOperation
{
    public readonly int DivisionCoef;

    public Division(int divisionCoef)
    {
        DivisionCoef = divisionCoef;
    }
    public int DoOperation(int incomingArmySize) => incomingArmySize / DivisionCoef;
}
