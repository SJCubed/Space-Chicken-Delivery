using UnityEngine;

public abstract class SkillCaster : MonoBehaviour
{
    //Caster's Global Skill Cast Timer. When this value is above 0, that caster is performing
    //motion animation and cannot cast different skill unless it's instant cast.
    protected float globalCastTimer = 0f;
    public float GlobalCastTimer
    {
        set
        {
            globalCastTimer = value;
        }
    }
}
