using System;

abstract class ActivityState
{
    protected CreatureState creature;

    public ActivityState(CreatureState creature)
    {
        this.creature = creature;
    }

    protected bool CalculateTheChance(int chance)
    {
        Random rand = new Random();

        int chanceRand = rand.Next(1, 101);

        return chanceRand <= chance;
    }

    public void SetCreatureState(CreatureState creature)
    {
        this.creature = creature;
    }

    public abstract void BeHighlyActive();

    public abstract void BeNormalActive();

    public abstract void BeLowActive();


}
