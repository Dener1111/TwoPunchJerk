using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionKnockout : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventInt punchCount;

    [Space]
    [SerializeField] ParticleSystem particles;
    [SerializeField] int spawnAfterPunchCount;
    
    void Start()
    {
        punchCount.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        punchCount.RemoveListener(OnPunch);
    }

    void OnPunch(int count)
    {
        if(count < spawnAfterPunchCount)
            return;
        
        if(particles.isEmitting)
            return;

        particles.Play();
    }
}
