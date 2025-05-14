using System;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

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
    
    Sequence _punchTween;
    
    void Start()
    {
        _defaultPos = fist.position;
        onPunchTrigger.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchTrigger.RemoveListener(OnPunch);
    }

    void OnPunch(Vector3 pos)
    {
        _punchTween.Stop();
        _punchTween = Sequence.Create();
        _punchTween.Chain(Tween.Position(fist, pos, punchDuration, punchEase));
        _punchTween.Chain(Tween.Position(fist, _defaultPos, resetDuration, resetEase));
    }
}
