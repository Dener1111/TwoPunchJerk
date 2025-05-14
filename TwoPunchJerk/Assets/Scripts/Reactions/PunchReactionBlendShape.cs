using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionBlendShape : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventHeadPart onPunchHeadPart;

    [Space]
    [SerializeField] SkinnedMeshRenderer rend;
    [SerializeField] int blendShapeIndex;
    [SerializeField] HeadPart headPart;
    [SerializeField] float damagePerPunch;

    float _currentValue;
    readonly float maxValue = 100;
    
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
        if(part != headPart)
            return;

        _currentValue += damagePerPunch;
        _currentValue = Mathf.Clamp(0, maxValue, _currentValue);
        
        rend.SetBlendShapeWeight(blendShapeIndex, _currentValue);
    }
}
