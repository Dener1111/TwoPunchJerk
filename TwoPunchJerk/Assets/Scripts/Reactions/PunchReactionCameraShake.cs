using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionCameraShake : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventInt onPunch;

    [Space]
    [SerializeField] Cinemachine.CinemachineImpulseSource impulse;
    
    void Start()
    {
        onPunch.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunch.RemoveListener(OnPunch);
    }

    void OnPunch(int count)
    {
        impulse.GenerateImpulse();
    }
}
