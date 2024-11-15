using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class Mob : Npc
{

    private int Mpriva;
    protected int Mprot;
    public int Mpublc;


    public override void Attack()
    {
        Console.WriteLine("Mob攻擊");
    }
    
    public void Show()
    {
        Console.WriteLine("Mob");
    }


}