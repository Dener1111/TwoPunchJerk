using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;

public class PunchCountUI : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventInt punchCount;

    [Space]
    [SerializeField] TMP_Text text;
    [SerializeField] ShakeSettings textUpdateMotion;

    Tween _textTween;
    
    void Start()
    {
        punchCount.AddListener(OnPunch);
    }

    void OnDestroy()
    {
        punchCount.RemoveListener(OnPunch);
    }

    void OnPunch(int count)
    {
        text.SetText(count.ToString());
        
        _textTween.Stop();
        text.transform.localScale = Vector3.one;
        
        _textTween = Tween.PunchScale(text.transform, textUpdateMotion);
    }
}
