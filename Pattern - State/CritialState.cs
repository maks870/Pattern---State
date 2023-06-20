using System;

class CritialState : CreatureState
{
    private bool isNearDeath = false;
    public CritialState(Parameter hp, Parameter satiety, Creature creature) : base(hp, satiety, creature)
    {
    }

    protected override void CheckIncrease()
    {
        if ((hp.value >= hp.low && satiety.value >= satiety.low))
            creature.ChangeState(creature.BadState);
    }

    protected override void CheckDecrease()
    {
        string deathDescription = "";

        if (hp.value <= 0 || satiety.value <= 0)
        {
            if (isNearDeath)
            {
                if (hp.value <= 0)
                    deathDescription = "damage";
                else if (satiety.value <= 0)
                    deathDescription = "starving";

                Console.WriteLine($"Creature died from {deathDescription}");
                creature.Die();
            }
            else
            {
                creature.AddNearDeathCount();
            }

            isNearDeath = true;
        }
    }

    public override void CreateActivity()
    {
        if (CheckActivity())
            return;

        if (satiety.value < satiety.low)
            SetActivity(new SearchState(this));
        else
            SetActivity(new RestState(this));

        creature.AddHalfCycleLife();
    }

    public override void InvokeBehavior()
    {
        switch (activity)
        {
            case EatingState state:
                if (hp.value < satiety.value)
                    activity.BeLowActive();
                else
                    activity.BeHighlyActive();

                break;

            case SearchState state:
                if (hp.value < satiety.value)
                    activity.BeNormalActive();
                else
                    activity.BeHighlyActive();

                break;

            case FightState state:
                if (hp.value < hp.low)
                    activity.BeLowActive();
                else
                    activity.BeHighlyActive();
                break;

            case RestState state:
                activity.BeHighlyActive();
                break;
        }

        //if (hp.value < satiety.value)
        //{
        //    if (activity.GetType() == typeof(EatingState))
        //    {
        //        activity.BeLowActive();
        //    }
        //    else if (activity.GetType() == typeof(SearchState))
        //    {
        //        activity.BeNormalActive();
        //    }

        //    activity.BeHighlyActive();

        //    return;
        //}

        //if (activity.GetType() == typeof(FightState))
        //{
        //    activity.BeLowActive();
        //    return;
        //}

        //activity.BeHighlyActive();
    }
}



