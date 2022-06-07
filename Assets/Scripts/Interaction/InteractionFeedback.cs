using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFeedback : MonoBehaviour
{
    [SerializeField] Animator objectAnimator;

    [SerializeField] Transform feedbackTransform;

    [SerializeField] Transform feedbackFinishPosition;

    [SerializeField] float feedbackTime;

    enum MovementType {Move, Rotate}

    [SerializeField] MovementType movementType;

    private Item charada;
    private bool hasGiven = false;

    float time = 0;
    bool activated = false;

    void Update (){
        if(activated){
            if(time < feedbackTime){
                time += Time.deltaTime;
                switch (movementType){
                    case MovementType.Move : Move (); break;
                    case MovementType.Rotate : Rotate(); break;
                }
            }else{
                activated = false;
            }
        }
    }

    public void Activate (){
        activated = true;
        GiveCharada();
    }

    void Move (){
        feedbackTransform.position = Vector3.Lerp (feedbackTransform.position, feedbackFinishPosition.position, feedbackTime * Time.deltaTime );
    }

    void Rotate (){
        feedbackTransform.position = Vector3.Lerp (feedbackTransform.position, feedbackFinishPosition.position, feedbackTime * Time.deltaTime );
        feedbackTransform.rotation = Quaternion.Slerp(feedbackTransform.rotation, feedbackFinishPosition.rotation, feedbackTime * Time.deltaTime );
    }

    public void GetCharada (Item item){
        charada = item;
    }

    void GiveCharada () {
        if(!hasGiven){
            CharadaController.instance.ActivateNextCharada();
            Inventory.instance.PopulateIventory(charada.texto, charada.charada);    
            hasGiven = true;
        }
    }
}
