namespace Exercise5;

public class Npc
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    
    public int Exp { get; set; }
    

    public virtual int OnSelect()
    {
        return -1;
    }
    public virtual void Talk()
    {
        
    }

    public virtual void Dead()
    {
        
    }

    public virtual void ShowInfo()
    {
        
    }
}