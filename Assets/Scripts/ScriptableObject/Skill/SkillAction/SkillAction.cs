using UnityEngine;

public abstract class SkillAction : ScriptableObject
{
    public float ActionCastTime = 0;

    public SkillCheck[] SkillChecks;

    public abstract void DoAction(SkillBase newSkill, SkillCaster newCaster);
}
