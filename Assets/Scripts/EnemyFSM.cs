using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour {
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer };
    public EnemyState currentState;
    
    public Transform baseTransform;

    public float baseAttackDistance;
    public float playerAttackDistance;
    
    public GameObject bulletPrefab;
    public GameObject shootPoint;
    public float lastShootTime;
    public float fireRate;

    private NavMeshAgent agent;

    private void Awake() {
        baseTransform = GameObject.Find("Base").transform;
        print(baseTransform);
        agent = GetComponentInParent<NavMeshAgent>();
    }

    void Update() {
        if (currentState == EnemyState.GoToBase) {
            GoToBase();
        } else if (currentState == EnemyState.AttackBase) {
            AttackBase();
        } else if (currentState == EnemyState.ChasePlayer) {
            ChasePlayer();
        } else if (currentState == EnemyState.AttackPlayer) {
            AttackPlayer();
        }
    }

    void GoToBase() {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);

        Sight sightSensor = GetComponent<Sight>();
        if (sightSensor.detectedObject != null) {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance) {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase() {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void ChasePlayer() {
        Sight sightSensor = GetComponent<Sight>();
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(sightSensor.detectedObject.transform.position);

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance) {
            currentState = EnemyState.AttackPlayer;
        }
    }
    
    void AttackPlayer() {
        Sight sightSensor = GetComponent<Sight>();
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.isStopped = true;
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f) {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void LookTo(Vector3 targetPosition) {
        Vector3 dirToTarget = Vector3.Normalize(targetPosition - transform.parent.position);
        dirToTarget.y = 0;
        transform.parent.forward = dirToTarget;
    }

    void Shoot() {
        float timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate) {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
