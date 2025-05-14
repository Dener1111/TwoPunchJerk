using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchReactionMaterial : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventString onPunchHeadPart;

    [Space]
    [SerializeField] Renderer rend;
    [SerializeField] float damagePerPunch = .25f;
    [SerializeField] List<string> maskNames;
    
    void Start()
    {
        onPunchHeadPart.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        onPunchHeadPart.RemoveListener(OnPunch);
    }

    void OnPunch(string partName)
    {
        if(!maskNames.Contains(partName))
            return;

        float damage = rend.material.GetFloat(partName);
        damage += damagePerPunch;
        damage = Mathf.Clamp01(damage);
        rend.material.SetFloat(partName, damage);
    }
}
