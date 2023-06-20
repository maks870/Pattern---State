using System;

class GoodState : CreatureState
{
    public GoodState(Parameter hp, Parameter satiety, Creature creature) : base(hp, satiety, creature)
    {
    }

    protected override void CheckIncrease()
    {

    }

    protected override void CheckDecrease()
    {
        if (hp.value < hp.hight || satiety.value < satiety.hight)
            creature.ChangeState(creature.NormalState);
    }

    public override void CreateActivity()
    {
        if (CheckActivity())
            return;

        if (hp.value > satiety.value)
            SetActivity(new SearchState(this));
        else
            SetActivity(new RestState(this));

        creature.AddHalfCycleLife();
    }

    public override void InvokeBehavior()
    {
        activity.BeLowActive();
    }
}



