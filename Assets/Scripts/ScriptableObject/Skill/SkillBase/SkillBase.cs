using System.Collections;
using UnityEngine;

//Skill Type: Basic Skill, Ult = Ultimate Skill, Attack = Basic Attack, Move = Movement Skill
public enum SkillType
{
    Skill = 0,
    Ult = 1,
    Attack = 2,
    Move = 3
}

//Skill Level: Skill Upgrades from 0 to +3
public enum SkillLevel
{
    Crude = 0,
    Normal = 1,
    Refined = 2,
    Perfect = 3
}

public abstract class SkillBase : ScriptableObject, ISkillCastable
{
    public string SkillName;

    //For when Icons are used
    //public Sprite Icon { get; private set; }

    [Multiline]
    public string SkillDescription;
    [Space]
    public SkillType SkillType;
    public SkillLevel SkillLevel;
    [Space]
    [HideInInspector]
    public float CurrentCooldown = 0f;
    public float Cooldown = 1f;
    [HideInInspector]
    public float CurrentChargeUpTime = 0f;
    public float ChargeUpTime = 1f;
    [HideInInspector]
    public int CurrentCharge = 1;
    public int MaxCharge = 1;

    //SkillCheck is for checking if this skill can be casted upon keypress
    [Space]
    public SkillCheck[] SkillChecks;
    //SkillAction is actually performing the skill actions when skill check is passed
    [Space]
    public SkillAction[] SkillActions;

    //When the caster uses the skill, this method is called
    public virtual void Cast(SkillCaster newCaster)
    {
        //Check if this skill can be cast
        if (SkillChecks != null)
        {
            bool canCast = true;
            foreach (SkillCheck skillCheck in SkillChecks)
            {
                if (!skillCheck.Check(newCaster))
                {
                    canCast = false;
                    break;
                }
            }
            //If the skill cannot be casted then debug and return
            if (!canCast)
            {
                Debug.Log("Can't cast this skill at this time");
                return;
            }
            //If the skill can be cast then set the cooldown and
            //use one Charge and Start DoAction Coroutine
            else
            {
                if (SkillActions != null)
                {
                    CurrentCooldown = Cooldown;
                    CurrentCharge--;

                    newCaster.StartCoroutine(DoAction(newCaster));

                }
                else
                {
                    Debug.Log("No Skill Actions found!");
                    return;
                }
            }
        }
    }

    public abstract IEnumerator DoAction(SkillCaster newCaster);

}
