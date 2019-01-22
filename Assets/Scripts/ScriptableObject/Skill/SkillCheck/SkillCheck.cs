using UnityEngine;

public abstract class SkillCheck : ScriptableObject
{
    public abstract bool Check(SkillBase newSkill, SkillCaster newCaster);
}
