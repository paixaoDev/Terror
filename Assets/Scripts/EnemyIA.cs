using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;


    public void Update () {
        if (Vector3.Distance(target.position, transform.position) > 3f){
            agent.destination = target.position;
        }
    }
}
