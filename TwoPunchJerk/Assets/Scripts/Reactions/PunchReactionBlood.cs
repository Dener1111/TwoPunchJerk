using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionBlood : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventInt punchCount;
    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;

    [Space]
    [SerializeField] ParticleSystem particle;
    [SerializeField] int spawnAfterPunchCount = 10;
    
    void Start()
    {
        onPunchPosition.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchPosition.RemoveListener(OnPunch);
    }

    void OnPunch(Vector2 pos)
    {
        if(punchCount.Value < spawnAfterPunchCount)
            return;
        
        particle.transform.rotation = Quaternion.LookRotation(Vector3.left * Mathf.Sign(pos.x));
        particle.Play();
    }
}
