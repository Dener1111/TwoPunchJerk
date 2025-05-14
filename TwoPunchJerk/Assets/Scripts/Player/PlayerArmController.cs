using System;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerArmController : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector3 onPunchTrigger;

    [Space]
    [SerializeField] Transform fist;

    [Space]
    [SerializeField] float punchDuration;
    [SerializeField] Ease punchEase;

    [Space]
    [SerializeField] float resetDuration;
    [SerializeField] Ease resetEase;

    Vector3 _defaultPos;
    Quaternion _defaultRot;
    
    Sequence _punchTween;
    
    void Start()
    {
        _defaultPos = fist.position;
        _defaultRot = fist.rotation;
        
        onPunchTrigger.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchTrigger.RemoveListener(OnPunch);
    }

    void OnPunch(Vector3 pos)
    {
        Vector3 dir = (pos - _defaultPos).normalized;
        
        _punchTween.Stop();
        _punchTween = Sequence.Create();
        
        _punchTween.Group(Tween.Position(fist, pos, punchDuration, punchEase));
        _punchTween.Group(Tween.Rotation(fist, Quaternion.LookRotation(dir), punchDuration, punchEase));

        _punchTween.ChainDelay(punchDuration);
        
        _punchTween.Group(Tween.Position(fist, _defaultPos, resetDuration, resetEase));
        _punchTween.Group(Tween.Rotation(fist, _defaultRot, resetDuration, resetEase));
    }
}
