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

    [SerializeField] bool canKill = true;
    [SerializeField] bool jumpScare = false;

    [SerializeField] List<AudioClip> scareAudio;
    [SerializeField] AudioSource source;


    public void Update () {
        if (Vector3.Distance(target.position, transform.position) > 3f){
            agent.destination = target.position;
        }else{
            if(canKill) {
                if(!jumpScare){
                    JumpScare();
                    jumpScare = true;
                }

                Debug.Log("Você Morreu");
                GameOverScreen.SetActive(true);
                if(Input.anyKeyDown) {
                    SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                }   
            }
        }
    }

     void JumpScare (){
        source.clip = scareAudio[Random.Range(0, scareAudio.Count)];
        source.Play();
    }
}
