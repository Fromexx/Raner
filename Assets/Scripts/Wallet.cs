using UnityEditor;

public static class Wallet
{
    private static int _money;
    
    public static int Money => _money;

    public static bool AddMoney(int money)
    {
        if (money < 0) return false;
        _money += money;
        return true;
    }

    public static bool RemoveMoney(int money)
    {
        if (money < 0) return false;
        _money -= money;
        return true;
    }

}
