using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionMaterial : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventHeadPart onPunchHeadPart;

    [Space]
    [SerializeField] Renderer rend;
    [SerializeField] float damagePerPunch = .25f;
    [SerializeField] List<HeadPart> masks;
    
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
        if(!masks.Contains(part))
            return;

        string partName = part.ToString();

        float damage = rend.material.GetFloat(partName);
        damage += damagePerPunch;
        damage = Mathf.Clamp01(damage);
        rend.material.SetFloat(partName, damage);
    }
}
