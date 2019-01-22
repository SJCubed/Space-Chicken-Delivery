using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestSkillAction : SkillAction
{
    public float WaitTime;

    public override void DoAction(SkillBase newSkill, SkillCaster newCaster)
    {
        newSkill.CurrentSkillCooldown = newSkill.SkillCooldown;
        newSkill.CurrentCharge--;
        Coroutine coroutine = newCaster.StartCoroutine(TestSkill());
    }

    public IEnumerator TestSkill()
    {
        Debug.Log("Start Timer");
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("Timer Ended");
    }


}
