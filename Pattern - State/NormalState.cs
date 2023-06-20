using System;

class NormalState : CreatureState
{
    public NormalState(Parameter hp, Parameter satiety, Creature creature) : base(hp, satiety, creature)
    {
    }

    protected override void CheckIncrease()
    {
        if (hp.value >= hp.hight && satiety.value >= satiety.hight)
            creature.ChangeState(creature.GoodState);
    }

    protected override void CheckDecrease()
    {
        if ((hp.value < hp.mid || satiety.value < satiety.mid))
            creature.ChangeState(creature.BadState);
    }

    public override void CreateActivity()
    {
        if (CheckActivity())
            return;

        if (hp.value >= satiety.value)
            activity = new SearchState(this);
        else
            activity = new RestState(this);

        creature.AddHalfCycleLife();
    }

    public override void InvokeBehavior()
    {
        if (activity.GetType() == typeof(FightState) || activity.GetType() == typeof(SearchState))
        {
            activity.BeNormalActive();
            return;
        }

        activity.BeLowActive();
    }
}



