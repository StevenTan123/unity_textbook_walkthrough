using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    void Update() {
        detectedObject = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);
        for (int i = 0; i < colliders.Length; i++) {
            Collider collider = colliders[i];
            Vector3 toCollider = Vector3.Normalize(collider.bounds.center - transform.position);
            float colliderAngle = Vector3.Angle(transform.forward, toCollider);
            if (colliderAngle < angle) {
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers)) {
                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                } else {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
        }   
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Vector3 rightDir = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDir * distance);
        Gizmos.DrawRay(transform.position, rightDir * distance);
    }
}
