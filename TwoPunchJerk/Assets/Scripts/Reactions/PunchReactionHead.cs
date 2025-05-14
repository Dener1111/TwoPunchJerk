using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionHead : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;
    [SerializeField] Animator anim;

    [Space]
    [SerializeField] float angerPerPunch = .05f;

    float _anger;
    
    readonly string Punch = "Punch";
    readonly string PunchDir = "PunchDir";
    
    readonly int FaceLayerIndex = 2;
    
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
        anim.SetFloat(PunchDir, pos.x);
        anim.SetTrigger(Punch);

        _anger += angerPerPunch;
        _anger = Mathf.Clamp01(_anger);
        
        anim.SetLayerWeight(FaceLayerIndex, _anger);
    }
}
