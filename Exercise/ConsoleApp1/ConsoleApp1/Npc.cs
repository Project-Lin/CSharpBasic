namespace ConsoleApp1;

public class Npc
{
    public int hp;
    
    public Npc()
    {
        hp = 10;
    }

    public void setHp(int h)
    {
        hp = h;
    }
    public virtual void Attack()
    {
        Console.WriteLine("NPC攻擊");
    }

    public void Show()
    {
        Console.WriteLine("Npc");
    }
}