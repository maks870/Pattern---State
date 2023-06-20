using System;

abstract class CreatureState
{
    protected Parameter hp;
    protected Parameter satiety;
    protected Creature creature;

    protected ActivityState activity;
    private ActivityState prevActivity;

    public ActivityState Activity => activity;
    public Parameter Hp { get => hp; set => hp = value; }
    public Parameter Satiety { get => satiety; set => satiety = value; }

    protected CreatureState(Parameter hp, Parameter satiety, Creature creature)
    {
        this.hp = hp;
        this.satiety = satiety;
        this.creature = creature;
        activity = new WaitingForActivity(this);
    }

    protected virtual void CheckIncrease()
    {
    }

    protected virtual void CheckDecrease()
    {
    }

    protected bool CheckActivity()
    {
        bool isHasActivity = true;

        if (activity.GetType() == typeof(WaitingForActivity))
            isHasActivity = false;

        return isHasActivity;
    }
    public abstract void CreateActivity();
    public abstract void InvokeBehavior();

    public void Eat()
    {
        satiety.value++;

        if (satiety.value > satiety.hight + 1)
            satiety.value = satiety.hight + 1;

        CheckIncrease();
    }

    public void Starve()
    {
        satiety.value--;
        CheckDecrease();
    }

    public virtual void Rest()
    {
        hp.value++;

        if (hp.value > hp.hight + 1)
            hp.value = hp.hight + 1;

        CheckIncrease();
    }

    public virtual void Damage()
    {
        hp.value--;
        Console.WriteLine("hp after damaged " + hp.value);

        CheckDecrease();
    }

    public void SetState(CreatureState state)
    {
        hp = state.hp;
        satiety = state.satiety;
        creature = state.creature;
        activity = state.activity;
        prevActivity = state.prevActivity;
        activity.SetCreatureState(this);
        prevActivity?.SetCreatureState(this);
    }

    public void SetPrevActivity(ActivityState activity)
    {
        prevActivity = activity;
    }

    public void SetActivity(ActivityState activity)
    {
        this.activity = activity;
    }

    public void ReturnToPrevActivity()
    {
        ActivityState activity = prevActivity;

        this.activity = activity;
    }
}



