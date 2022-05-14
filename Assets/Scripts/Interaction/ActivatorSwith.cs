using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActivatorSwith : MonoBehaviour
{
    /*<summary>
		Script que representa um ativador de ações em outros objetos. 
	    Quando um gameObject com alguma das tags na lista activatingTags se aproxima, ele mostra na UI o botão correspondente que deve ser pressionado para ativar.
	    Ao ser ativado ele executa o evento configurado no eventToCall depois do tempo colocado em timeToActivate.
	    Ele também toca um sound ao ser ativado.
        Se o Evento é do tipo que retorna um valor ao finalizar este só podera ser restartado após o final do evento chamado.
	</summary>*/

    [Header ("Activator Settings ----")]
    [SerializeField] bool withoutCollider = false;      //ativa sem collider?
    [SerializeField] bool stayCollider = false;
    [SerializeField] bool desactiveAfterUseIt = true;   //É desativado após o uso?

    [Header ("Key Settings")]
    [SerializeField] bool withAnyKey = false;           //ativa com qualquer botão?
    [SerializeField] bool useKeyToActivate = true;      //Deve usar key Para ativar?
    [SerializeField] string keyActive = "Submit";       //Botão que aciona o ativador

    [Header ("Time Settings")]
    [SerializeField] bool afterTime = false;            //ativa depois de que
    [SerializeField] float timeToActivate = 0f;         //Timer de ativação       

    [Header ("Activator Necessary ----")]        
    [SerializeField] List<string> activatingTags;       //Quem pode ativar este evento  
    [SerializeField] UnityEvent eventToCall;            //Evento para ser chamado

    [Header ("Active FeedBack Settings")]
    [SerializeField] Sprite imageUIAlert;               //Imagem que deve aparecer ao poder ativar
    [SerializeField] string MessageUIAlert;             //Mensagem que ira aparecer ao ativar
	[SerializeField] AudioClip activationSound;         //Som que deve ser tocado ao ativar;
	
	private bool useEnabled = false;    //Pode ser usado
	private bool actived = false;       //Foi ativado anteriormente

	protected virtual void Update(){
        //Não precisa de um collider
        if(this.withoutCollider && !this.actived){
            this.ActivationLogic();	
        }else
        //É ativo com um collider
		if (this.useEnabled && !this.actived){
            this.ActivationLogic();		
		}
	}

    //Metodo usado para temporizar a ivocação da função que deve ser chamada pelo ativador
	IEnumerator ExecutarActive(float time){
		yield return new WaitForSeconds (time);

        //Se tiver algum som ao ser ativado
        // if (this.activationSound != null){
        //     AudioController.instance.PlaySfx(activationSound);
        // }

        this.eventToCall.Invoke ();
	}

    #region Controladores
    //É chamado no momento que o ativador deve passar a estar disponível
    public void Enabled(){
		if (!actived) {
			this.useEnabled = true;
           // GameController.instance.ActivateInteractiveButton(keyActive,MessageUIAlert);
        }
	}

	//É chamado no momento que o ativador não deve estar disponível
	public void Disabled(){
		this.useEnabled = false;
        //GameController.instance.DesactivateInteractiveButton();
    }

    //Reseta o trigger para que ele possa ser acionado novamente
    public void Reset(){
        this.actived = false;
    }
    #endregion

    #region Logic
    //Logica do update
    void ActivationLogic(){
        // É ativado apenas com o timer
        if(this.afterTime){
            this.Active();
        }
        else
        //Não é ativado após o tempo
        if(!this.afterTime){           
           //Se deve ser ativo com uma key
            if(this.useKeyToActivate) {
                //Se pode ser ativo com qualquer botão
                if(this.withAnyKey){
                    if (Input.anyKeyDown){
                        this.Active();
                    }
                }
                else
                //Se DEVE ser ativo com um botão especifico
                if (Input.GetButtonDown(this.keyActive)){
                    this.Active();
                }
            }
            //Se não precisa de uma key para ativar (apenas executa)
            else{
                this.timeToActivate = 0;
                this.Active();
            }
        }	
    }

    //Metodo chamado no momento que é acionado a tecla que o ativador aceita
    public void Active(){
        //Se for pra desativar após usar digo que ele já foi usado
		if (this.desactiveAfterUseIt){
			this.actived = true;
		}

        //Para não permitir ativações consecutivas 
        this.Disabled();

        //Invoco o evento
		StartCoroutine (ExecutarActive (this.timeToActivate));
	}
    #endregion

	#region Trigger Events
    //Se a tag entrar
    void OnTriggerEnter(Collider other){
        Debug.Log("OnTriggerEnter");
		if (this.activatingTags.IndexOf(other.tag) != -1) {
			this.Enabled ();
		}
	}
    //Se a tag ficar
	void OnTriggerStay(Collider other){
        Debug.Log("OnTriggerStay");
		if (this.activatingTags.IndexOf(other.tag) != -1) {
            if(this.stayCollider){
                this.Enabled ();
            }
		}
	}
    //Se a tag sair
	void OnTriggerExit(Collider other){
        Debug.Log("OnTriggerExit");
		if (this.activatingTags.IndexOf(other.tag) != -1) {
			this.Disabled ();
		}
	}
	#endregion

    #region Custon Editor

    #endregion
}
