using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionParticles : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventHeadPart onPunchHeadPart;

    [Space]
    [SerializeField] ParticleSystem particle;
    [SerializeField] HeadPart headPartTarget;
    [SerializeField] int spawnAfterPunchCount = 10;
    [SerializeField] int maxSpawns = 24;

    int _punchCount;
    int _spawnCount;
    
    void Start()
    {
        onPunchHeadPart.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchHeadPart.RemoveListener(OnPunch);
    }

    void OnPunch(HeadPart part)
    {
        if(headPartTarget != part)
            return;

        _punchCount++;
        
        if(_punchCount < spawnAfterPunchCount)
            return;
        
        if(_spawnCount > maxSpawns)
            return;
        
        _spawnCount++;
        particle.Play();
    }
}
