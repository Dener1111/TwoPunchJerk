using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionHit : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector3 onPunchPosition3D;

    [Space]
    [SerializeField] ParticleSystem hitParticle;

    void Start()
    {
        onPunchPosition3D.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchPosition3D.RemoveListener(OnPunch);
    }

    void OnPunch(Vector3 pos)
    {
        hitParticle.transform.position = pos;
        hitParticle.Play();
    }
}