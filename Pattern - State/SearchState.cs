class SearchState : ActivityState
{
    public SearchState(CreatureState creature) : base(creature)
    {
    }

    public override void BeHighlyActive()
    {
        creature.Starve();

        if (CalculateTheChance(40))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.SetActivity(new EatingState(creature));
    }

    public override void BeNormalActive()
    {
        if (CalculateTheChance(50))
            creature.Starve();

        if (CalculateTheChance(25))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.SetActivity(new EatingState(creature));
    }

    public override void BeLowActive()
    {
        if (CalculateTheChance(10))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        if (CalculateTheChance(50))
            creature.SetActivity(new EatingState(creature));
        else
            creature.SetActivity(new WaitingForActivity(creature));
    }
}


