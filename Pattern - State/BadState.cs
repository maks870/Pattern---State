using System;

class BadState : CreatureState
{
    public BadState(Parameter hp, Parameter satiety, Creature creature) : base(hp, satiety, creature)
    {
    }

    protected override void CheckIncrease()
    {
        if ((hp.value >= hp.mid && satiety.value >= satiety.mid))
            creature.ChangeState(creature.NormalState);
    }

    protected override void CheckDecrease()
    {
        if ((hp.value < hp.low || satiety.value < satiety.low))
            creature.ChangeState(creature.CritialState);
    }

    public override void CreateActivity()
    {
        if (CheckActivity())
            return;

        if (satiety.value < satiety.mid && hp.value >= hp.low)
            SetActivity(new SearchState(this));
        else
            SetActivity(new RestState(this));

        creature.AddHalfCycleLife();
    }

    public override void InvokeBehavior()
    {
        activity.BeNormalActive();
    }
}



