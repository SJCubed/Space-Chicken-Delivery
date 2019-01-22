using System.Collections;
using UnityEngine;

public class PlayerSkillCaster : SkillCaster
{

    [SerializeField]
    private PlayerSkillSlot playerSkillSlot;
    private SkillBase[] skillSnapshots = new SkillBase[6];


    //Make copies of the skills in the player skill slot On Enable
    private void OnEnable()
    {
        for (int i = 0; i < skillSnapshots.Length; i++)
        {
            skillSnapshots[i] = Instantiate(playerSkillSlot.SkillSlots[i]);
        }
    }

    //Destroy the copies of the skills on Disable
    private void OnDisable()
    {
        for (int i = 0; i < skillSnapshots.Length; i++)
        {
            Destroy(skillSnapshots[i]);
        }
    }

    //Start Coroutine for all the skill's cooldowns and charge
    private void Start()
    {
        StartCoroutine(PlayerSkillManager());
    }

    //Check for Player's Input
    private void Update()
    {
        SkillInput();
    }

    //Cast the skill based on the key input
    private void SkillInput()
    {
        if (Input.GetButtonDown("Skill1") && playerSkillSlot.SkillSlots[0] != null)
        {
            skillSnapshots[0].Cast(this);
        }
        if (Input.GetButtonDown("Skill2") && playerSkillSlot.SkillSlots[1] != null)
        {
            skillSnapshots[1].Cast(this);
        }
        if (Input.GetButtonDown("Skill3") && playerSkillSlot.SkillSlots[2] != null)
        {
            skillSnapshots[2].Cast(this);
        }
        if (Input.GetButtonDown("Ult") && playerSkillSlot.SkillSlots[3] != null)
        {
            skillSnapshots[3].Cast(this);
        }
        if (Input.GetButtonDown("Attack") && playerSkillSlot.SkillSlots[4] != null)
        {
            skillSnapshots[4].Cast(this);
        }
        if (Input.GetButtonDown("MoveSkill") && playerSkillSlot.SkillSlots[5] != null)
        {
            skillSnapshots[5].Cast(this);
        }
    }

    private IEnumerator PlayerSkillManager()
    {

        while (true)
        {

            //Loop through all the skills to reduce cooldown and charge up
            foreach (SkillBase newSkillBase in skillSnapshots)
            {
                if (newSkillBase.Cooldown >= 0)
                    newSkillBase.Cooldown -= Time.deltaTime;
                if (newSkillBase.CurrentCharge < newSkillBase.MaxCharge)
                {
                    if (newSkillBase.CurrentChargeUpTime <= 0)
                    {
                        newSkillBase.CurrentCharge++;
                        newSkillBase.CurrentChargeUpTime = newSkillBase.ChargeUpTime;
                    }
                    else
                    {
                        newSkillBase.CurrentChargeUpTime -= Time.deltaTime;
                    }

                }

            }

            yield return null;
        }

    }

}
