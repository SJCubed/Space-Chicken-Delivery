using System.Collections;
using UnityEngine;

public class PlayerSkillCaster : SkillCaster
{
    [SerializeField]
    private PlayerSkillSlot playerSkillSlot;
    private SkillBase[] skillSnapshots = new SkillBase[6];
    private int skillQueue = 0;

    //Make copies of the skills in the player skill slot On Enable
    private void OnEnable()
    {
        for (int i = 0; i < skillSnapshots.Length; i++)
        {
            if (playerSkillSlot.SkillSlots[i] != null)
            {
                skillSnapshots[i] = Instantiate(playerSkillSlot.SkillSlots[i]);
            }
        }
    }

    //Destroy the copies of the skills on Disable
    private void OnDisable()
    {
        for (int i = 0; i < skillSnapshots.Length; i++)
        {
            if (skillSnapshots[i] != null)
            {
                Destroy(skillSnapshots[i]);
            }
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
        //If user presses skill key or queue has this key buffered and this skill slot is not null
        if ((Input.GetButtonDown("Skill1") || skillQueue == 1) && playerSkillSlot.SkillSlots[0] != null)
        {
            //If this skill is not on cooldown and has charge available and
            //either there is no global cast cooldown or this skill is instant cast,
            //reset buffer and cast skill

            if (skillSnapshots[0].CurrentSkillCooldown <= 0 &&
                skillSnapshots[0].CurrentCharge > 0 &&
                (globalCastTimer <= 0 || skillSnapshots[0].InstantCast))
            {
                skillQueue = 0;
                skillSnapshots[0].Cast(this);
            }
            //If skill is unable to be casted by any reason and user pressed button, add key to buffer
            else if (Input.GetButtonDown("Skill1"))
                skillQueue = 1;
        }
        if ((Input.GetButtonDown("Skill2") || skillQueue == 2) && playerSkillSlot.SkillSlots[1] != null)
        {
            if (skillSnapshots[1].CurrentSkillCooldown <= 0 &&
                skillSnapshots[1].CurrentCharge > 0 &&
                (globalCastTimer <= 0 || skillSnapshots[1].InstantCast))
            {
                skillQueue = 0;
                skillSnapshots[1].Cast(this);
            }
            else if (Input.GetButtonDown("Skill2"))
                skillQueue = 2;
        }
        if ((Input.GetButtonDown("Skill3") || skillQueue == 3) && playerSkillSlot.SkillSlots[2] != null)
        {
            if (skillSnapshots[2].CurrentSkillCooldown <= 0 &&
                skillSnapshots[2].CurrentCharge > 0 &&
                (globalCastTimer <= 0 || skillSnapshots[2].InstantCast))
            {
                skillQueue = 0;
                skillSnapshots[2].Cast(this);
            }
            else if (Input.GetButtonDown("Skill3"))
                skillQueue = 3;
        }
        if ((Input.GetButtonDown("Ult") || skillQueue == 4) && playerSkillSlot.SkillSlots[3] != null)
        {
            if (skillSnapshots[3].CurrentSkillCooldown <= 0 &&
                skillSnapshots[3].CurrentCharge > 0 &&
                (globalCastTimer <= 0 || skillSnapshots[3].InstantCast))
            {
                skillQueue = 0;
                skillSnapshots[3].Cast(this);
            }
            else if (Input.GetButtonDown("Ult"))
                skillQueue = 4;
            if ((Input.GetButtonDown("Attack") || skillQueue == 5) && playerSkillSlot.SkillSlots[4] != null)
            {
                if (skillSnapshots[4].CurrentSkillCooldown <= 0 &&
                    skillSnapshots[4].CurrentCharge > 0 &&
                    (globalCastTimer <= 0 || skillSnapshots[4].InstantCast))
                {
                    skillQueue = 0;
                    skillSnapshots[4].Cast(this);
                }
                else if (Input.GetButtonDown("Attack"))
                    skillQueue = 5;
            }
            if ((Input.GetButtonDown("MoveSkill") || skillQueue == 6) && playerSkillSlot.SkillSlots[5] != null)
            {
                if (skillSnapshots[5].CurrentSkillCooldown <= 0 &&
                    skillSnapshots[5].CurrentCharge > 0 &&
                    (globalCastTimer <= 0 || skillSnapshots[5].InstantCast))
                {
                    skillQueue = 0;
                    skillSnapshots[5].Cast(this);
                }
                else if (Input.GetButtonDown("MoveSkill"))
                    skillQueue = 6;
            }
        }
    }

    private IEnumerator PlayerSkillManager()
    {

        while (true)
        {
            //reduce cast timer
            if (globalCastTimer > 0)
                globalCastTimer -= Time.deltaTime;

            //Loop through all the skills to reduce cooldown and charge up timers
            foreach (SkillBase newSkillBase in skillSnapshots)
            {
                if (newSkillBase != null)
                {
                    if (newSkillBase.CurrentSkillCooldown > 0)
                        newSkillBase.CurrentSkillCooldown -= Time.deltaTime;
                    if (newSkillBase.CurrentCharge < newSkillBase.MaxCharge)
                    {
                        if (newSkillBase.CurrentRechargeTime <= 0)
                        {
                            newSkillBase.CurrentCharge++;
                            newSkillBase.CurrentRechargeTime = newSkillBase.RechargeTime;
                        }
                        else
                        {
                            newSkillBase.CurrentRechargeTime -= Time.deltaTime;
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
