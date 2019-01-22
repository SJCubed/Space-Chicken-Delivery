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

[CreateAssetMenu(fileName = "New Skill Base Template", menuName = "Skill/Skill Base Template")]
public class SkillBase : ScriptableObject
{
    public string SkillName;

    //For when Icons are used
    //public Sprite Icon { get; private set; }

    [Multiline]
    public string SkillDescription;
    [Space]
    public SkillType SkillType;
    public SkillLevel SkillLevel;
    private float currentSkillCooldown = 0f;
    private float currentChargeUpTime = 0f;
    private int currentRechargeTime = 1;
    public float CurrentSkillCooldown { get => currentSkillCooldown; set => currentSkillCooldown = value; }
    public float CurrentRechargeTime { get => currentChargeUpTime; set => currentChargeUpTime = value; }
    public int CurrentCharge { get => currentRechargeTime; set => currentRechargeTime = value; }
    [Space]
    public float SkillCooldown = 1f;
    public float RechargeTime = 1f;
    public int MaxCharge = 1;
    [Space]
    public bool InstantCast = false;
    //MultiCast is array of SkillActions that gets called sequentially based on time or input
    public SkillAction[] MultiCast;
    private int multiCastStage = 0;

    //When the caster uses the skill, this method is called
    public void Cast(SkillCaster newCaster)
    {
        if (MultiCast[multiCastStage].SkillChecks != null)
        {
            bool canCast = true;
            //Check if this skill can be cast
            foreach (SkillCheck newSkillCheck in MultiCast[multiCastStage].SkillChecks)
            {
                if (!newSkillCheck.Check(this, newCaster))
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
            //If the skill can be cast
            else
            {
                //If this skill isn't instant cast, set cast time
                if (!InstantCast)
                    newCaster.GlobalCastTimer = MultiCast[multiCastStage].ActionCastTime;
                //Perform Action
                MultiCast[multiCastStage].DoAction(this, newCaster);
                //If this is last multi cast stage, reset multi cast stage to 0, else increase it by 1
                if (multiCastStage == MultiCast.Length - 1)
                    multiCastStage = 0;
                else
                    multiCastStage++;
            }
        }
    }
}