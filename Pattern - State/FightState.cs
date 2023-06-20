class FightState : ActivityState
{
    public FightState(CreatureState creature) : base(creature)
    {
    }

    public override void BeHighlyActive()
    {
        if (CalculateTheChance(70))
            creature.Damage();

        creature.ReturnToPrevActivity();
    }

    public override void BeNormalActive()
    {
        if (CalculateTheChance(50))
        {
            creature.Damage();
            creature.SetActivity(new WaitingForActivity(creature));
            return;
        }

        creature.ReturnToPrevActivity();
    }

    public override void BeLowActive()
    {

        if (CalculateTheChance(30))
            creature.Damage();

        creature.SetActivity(new WaitingForActivity(creature));
    }
}


