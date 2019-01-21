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
    public string SkillName { get; private set; }
    //For when Icons are used
    //public Sprite Icon { get; private set; }
    public SkillType SkillType { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    //SkillCheck is for checking if this skill can be casted upon keypress
    [Space]
    public SkillCheck[] SkillChecks;
    //SkillAction is actually performing the skill actions when skill check is passed
    [Space]
    public SkillAction[] SkillActions;

    //When the caster uses the skill, this method is called
    public virtual void Cast(SkillCaster caster)
    {
        //Check if this skill can be cast
        if (SkillChecks != null)
        {
            bool canCast = true;
            foreach (SkillCheck skillCheck in SkillChecks)
            {
                if (!skillCheck.Check(caster))
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
            //If the skill can be cast then Start DoAction Coroutine
            else
            {
                if (SkillActions != null)
                {
                    caster.StartCoroutine(DoAction(caster));
                }
                else
                {
                    Debug.Log("No Skill Actions found!");
                    return;
                }
            }
        }
    }

    public abstract IEnumerator DoAction(SkillCaster caster);

}
