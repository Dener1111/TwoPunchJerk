using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPartDetector : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;
    [SerializeField] DKEvents.DKEventHeadPart onPunchHeadPart;

    [Space]
    [SerializeField] SphereCollider coll;

    [SerializeField] float scaleFactor; //model/animations is fucked
    [SerializeField] List<HeadPartPos> headParts;


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
        float minDist = 1f;
        HeadPartPos target = null;
        foreach (var item in headParts)
        {
            float dist = Vector2.Distance(pos, item.pos);
            if (dist >= minDist)
                continue;

            minDist = dist;
            target = item;
        }

        if (target == null)
            return;

        onPunchHeadPart.Value = target.part;
        // Debug.Log($"PUNCHED: {target.name}");
    }

    void OnDrawGizmosSelected()
    {
        if (!coll)
            return;

        Gizmos.color = Color.cyan;
        Vector3 offset = coll.transform.position; // - coll.center;
        float radius = coll.radius * scaleFactor;

        foreach (var item in headParts)
        {
            Vector3 pos = offset;
            pos.x += Mathf.Lerp(-radius, radius, Mathf.InverseLerp(-1f, 1f, item.pos.x));
            pos.y += Mathf.Lerp(-radius, radius, Mathf.InverseLerp(-1f, 1f, item.pos.y));
            pos.z += coll.radius * scaleFactor;
            Gizmos.DrawWireSphere(pos, .1f);
        }
    }

    [System.Serializable]
    class HeadPartPos
    {
        public HeadPart part;
        public Vector2 pos;
    }
}