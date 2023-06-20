class RestState : ActivityState
{
    public RestState(CreatureState creature) : base(creature)
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

        creature.Rest();
        creature.Rest();
        creature.Starve();

        creature.SetActivity(new WaitingForActivity(creature));
    }

    public override void BeNormalActive()
    {
        if (CalculateTheChance(40))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.Rest();

        if (CalculateTheChance(50))
            creature.Rest();

        creature.SetActivity(new WaitingForActivity(creature));
    }

    public override void BeLowActive()
    {
        if (CalculateTheChance(20))
        {
            creature.SetPrevActivity(this);
            creature.SetActivity(new FightState(creature));
            return;
        }

        creature.Rest();

        creature.SetActivity(new WaitingForActivity(creature));
    }

}


