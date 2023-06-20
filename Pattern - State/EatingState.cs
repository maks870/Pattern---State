class EatingState : ActivityState
{
    public EatingState(CreatureState creature) : base(creature)
    {
    }

    public override void BeHighlyActive()
    {
        if (CalculateTheChance(60))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.Eat();
        creature.Eat();
        creature.Eat();

        creature.SetActivity(new WaitingForActivity(creature));
    }

    public override void BeNormalActive()
    {
        if (CalculateTheChance(30))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.Eat();
        creature.Eat();

        //if (CalculateTheChance(50))
        //    creature.Eat();

        creature.SetActivity(new WaitingForActivity(creature));
    }

    public override void BeLowActive()
    {
        if (CalculateTheChance(10))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.Eat();

        creature.SetActivity(new WaitingForActivity(creature));
    }
}


