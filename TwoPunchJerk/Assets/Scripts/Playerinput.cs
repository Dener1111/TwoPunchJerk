using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playerinput : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector3 onPunchLeft;
    [SerializeField] DKEvents.DKEventVector3 onPunchRight;
    
    [Space]
    [SerializeField] LayerMask punchMask;

    [SerializeField] float timeBetweenInput = .15f;
    
    Camera _cam;

    int _handIndex;
    RaycastHit[] _hits = new RaycastHit[2];

    float _nextImput;
    
    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if(Time.time < _nextImput)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            _handIndex = 0;
            CheckPunch();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _handIndex = 1;
            CheckPunch();
        }
    }

    void CheckPunch()
    {
        const float dist = 4f;
        
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        int hitCount = Physics.RaycastNonAlloc(ray, _hits, dist, punchMask, QueryTriggerInteraction.Ignore);

        _nextImput = Time.time + timeBetweenInput;

        if (hitCount <= 0)
        {
            PunchEvent(ray.GetPoint(dist));
            return;
        }

        PunchEvent(_hits[0].point);
    }

    void PunchEvent(Vector3 pos)
    {
        if (_handIndex == 0)
        {
            onPunchLeft.Invoke(pos);
            return;   
        }
        
        onPunchRight.Invoke(pos);
    }
}