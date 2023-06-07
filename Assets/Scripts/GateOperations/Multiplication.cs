using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : IGateOperation
{
    public readonly int MultiplicationCoef;

    public Multiplication(int multiplicationCoef)
    {
        MultiplicationCoef = multiplicationCoef;
    }
    public int DoOperation(int incomingArmySize) => incomingArmySize * MultiplicationCoef; 
}
