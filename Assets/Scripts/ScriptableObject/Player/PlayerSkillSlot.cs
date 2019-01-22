using UnityEngine;

[CreateAssetMenu(fileName = "New Player Skill Slot", menuName = "Skill/Player Skill Slot")]
public class PlayerSkillSlot : ScriptableObject
{

    [NamedArrayAttribute(new string[] { "Skill1", "Skill2", "Skill3", "Ult", "Attack", "Move"})]
    public SkillBase[] SkillSlots = new SkillBase[6];

}
