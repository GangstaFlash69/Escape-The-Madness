using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public int Range;
    private MeshRenderer target;
    public LayerMask interactionlayer;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * Range);
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast (transform.position, transform.forward, out hit, Range, interactionlayer))
        {
            target = hit.collider.GetComponent< MeshRenderer > ();
            target.material.color = Color.red;
        }
        else if (target != null)
        {
            target.material.color = Color.white;
        }
    }
}
