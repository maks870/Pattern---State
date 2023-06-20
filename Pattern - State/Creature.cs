using System;

class Creature
{
    protected bool isAlive = true;
    protected int halfCyclesLived = 0;
    protected int goodHalfCyclesLived = 0;
    protected int nearDeathCount = 0;

    protected CreatureState creatureState;

    public CreatureState GoodState { get; private set; }
    public CreatureState NormalState { get; private set; }
    public CreatureState BadState { get; private set; }
    public CreatureState CritialState { get; private set; }

    public Creature(Parameter hp, Parameter satiety)
    {
        creatureState = new GoodState(hp, satiety, this);
        GoodState = new GoodState(hp, satiety, this);
        NormalState = new NormalState(hp, satiety, this);
        BadState = new BadState(hp, satiety, this);
        CritialState = new CritialState(hp, satiety, this);
    }

    private void AddGoodHalfCycleLife()
    {
        goodHalfCyclesLived++;
    }

    public void ChangeState(CreatureState state)
    {
        state.SetState(creatureState);
        creatureState = state;
    }

    public void AddNearDeathCount()
    {
        nearDeathCount++;
    }

    public void AddHalfCycleLife()
    {
        halfCyclesLived++;

        if (creatureState.GetType() == typeof(GoodState))
            AddGoodHalfCycleLife();


        if (halfCyclesLived % 2 == 0)
            creatureState.Starve();

        if (halfCyclesLived == 20000)
        {
            Console.WriteLine("Creature died of old age");
            Die();
        }
    }

    public void LiveTheCycles()
    {
        while (isAlive /*&& creatureState.Hp.value != 0 && creatureState.Satiety.value != 0*/)
        {
            creatureState.CreateActivity();
            creatureState.InvokeBehavior();
            Console.WriteLine("Hp: " + creatureState.Hp.value);
            Console.WriteLine("Satiety: " + creatureState.Satiety.value);
            Console.WriteLine();

            if (!isAlive)
            {
                Console.WriteLine($"Cycles to live: {halfCyclesLived / 2}");
                Console.WriteLine($"Good Cycles to live: {goodHalfCyclesLived / 2}");
                Console.WriteLine($"Near-death moment: {nearDeathCount - 1 }");
                break;
            }
        }
    }

    public void Die()
    {
        isAlive = false;
    }
}

