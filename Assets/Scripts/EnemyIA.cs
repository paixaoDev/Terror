using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;


    public void Update () {
        if (Vector3.Distance(target.position, transform.position) > 3f){
            agent.destination = target.position;
        }else{
            // Debug.Log("Você Morreu");
            // GameOverScreen.SetActive(true);
            // if(Input.anyKeyDown) {
            //     SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            // }
        }
    }
}
