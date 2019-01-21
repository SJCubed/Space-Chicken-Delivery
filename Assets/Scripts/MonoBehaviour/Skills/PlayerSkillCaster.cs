using UnityEngine;

public class PlayerSkillCaster : SkillCaster
{

    [SerializeField]
    private PlayerSkillSlot playerSkillSlot;

    private void Update()
    {
        SkillInput();
    }

    private void SkillInput()
    {
        if (Input.GetButtonDown("Skill1") && playerSkillSlot.SkillSlots[0] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[0]);
            snapshot.Cast(this);
        }
        if (Input.GetButtonDown("Skill2") && playerSkillSlot.SkillSlots[1] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[1]);
            snapshot.Cast(this);
        }
        if (Input.GetButtonDown("Skill3") && playerSkillSlot.SkillSlots[2] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[2]);
            snapshot.Cast(this);
        }
        if (Input.GetButtonDown("Ult") && playerSkillSlot.SkillSlots[3] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[3]);
            snapshot.Cast(this);
        }
        if (Input.GetButtonDown("Attack") && playerSkillSlot.SkillSlots[4] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[4]);
            snapshot.Cast(this);
        }
        if (Input.GetButtonDown("MoveSkill") && playerSkillSlot.SkillSlots[5] != null)
        {
            SkillBase snapshot = Instantiate(playerSkillSlot.SkillSlots[5]);
            snapshot.Cast(this);
        }
    }
}
