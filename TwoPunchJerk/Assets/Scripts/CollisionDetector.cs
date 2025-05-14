using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;

    [Space]
    [SerializeField] SphereCollider coll;
    [SerializeField] float scaleFactor; //model/animations is fucked

    void OnCollisionEnter(Collision other)
    {
        float radius = coll.radius * scaleFactor;
        
        Vector3 collisionPos = other.contacts[0].point;
        collisionPos -= coll.transform.position + coll.center;

        Vector2 normilizedPos;
        normilizedPos.x = (Mathf.InverseLerp(-radius, radius, collisionPos.x) - .5f) * 2f;
        normilizedPos.y = (Mathf.InverseLerp(-radius, radius, collisionPos.y) - .5f) * 2f;
        
        onPunchPosition.Invoke(normilizedPos);
    }
}
