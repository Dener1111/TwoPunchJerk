using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPartDetector : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;
    [SerializeField] DKEvents.DKEventString onPunchHeadPart;

    [Space]
    [SerializeField] SphereCollider coll;

    [SerializeField] float scaleFactor; //model/animations is fucked
    [SerializeField] List<HeadPart> headParts;


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
        HeadPart target = null;
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

        onPunchHeadPart.Invoke(target.name);
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
    class HeadPart
    {
        public string name;
        public Vector2 pos;
    }
}