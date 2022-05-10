using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeathController : MonoBehaviour
{   static public HeathController instance;
    [SerializeField] Slider heathBar;
    [SerializeField] float heath = 100;

    [SerializeField] GameObject GameOverScreen;

    void Awake (){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    void Update (){
        if(this.heath <= 0) {
            GameOverScreen.SetActive(true);
            if(Input.anyKeyDown) {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            }
        }
    }


    public void TakeDamage (){
        this.heath -= 10;
        UpdateHeathBar();
    }

    public void GetHeath (float value){
        this.heath += value;
        UpdateHeathBar();
    }

    private void UpdateHeathBar (){
        heathBar.value = heath;
    }
}
