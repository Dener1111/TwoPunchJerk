using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] SphereCollider coll;

    [SerializeField] DKEvents.DKEventVector2 onPunchPosition;

    void OnCollisionEnter(Collision other)
    {
        Vector3 collisionPos = other.contacts[0].point;
        collisionPos -= coll.transform.position + coll.center;

        Vector2 normilizedPos;
        normilizedPos.x = (Mathf.InverseLerp(-coll.radius, coll.radius, collisionPos.x) - .5f) * 2f;
        normilizedPos.y = (Mathf.InverseLerp(-coll.radius, coll.radius, collisionPos.y) - .5f) * 2f;
        
        onPunchPosition.Invoke(normilizedPos);
    }
}
