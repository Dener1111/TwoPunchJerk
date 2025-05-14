using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionBlood : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventInt punchCount;
    [SerializeField] DKEvents.DKEventVector3 onPunchLeft;
    [SerializeField] DKEvents.DKEventVector3 onPunchRight;

    [Space]
    [SerializeField] ParticleSystem particle;
    [SerializeField] int spawnAfterPunchCount = 10;

    int _punchDir;
    
    void Start()
    {
        punchCount.AddListener(OnPunch);
        onPunchLeft.AddListener(OnPunchLeft);
        onPunchRight.AddListener(OnPunchRight);
    }

    void OnDestroy()
    {
        punchCount.RemoveListener(OnPunch);
        onPunchLeft.RemoveListener(OnPunchLeft);
        onPunchRight.RemoveListener(OnPunchRight);
    }

    void OnPunchLeft(Vector3 _) => _punchDir = -1;
    void OnPunchRight(Vector3 _) => _punchDir = 1;

    void OnPunch(int count)
    {
        if(count < spawnAfterPunchCount)
            return;
        
        particle.transform.rotation = Quaternion.LookRotation(Vector3.left * _punchDir);
        particle.Play();
    }
}
