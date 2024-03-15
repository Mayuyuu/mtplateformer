using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameplay : MonoBehaviour
{
    //--------------------------------------------------------- ShockWave Variables
    private bool SWactivable = true;
    [SerializeField] private float RangeSW = 10f;
    [SerializeField] Sprite RevealSprite;
    [SerializeField] ParticleSystem ShockWavePS;
    [SerializeField] private float DurationMaxPS;
    [SerializeField] private float DurationMinPS = 0f;
    private float AlphaLerpDelay;
    private float InteractionDelay;
    //--------------------------------------------------------------------------------
    
    void Start()
    {
        ShockWavePS = gameObject.GetComponentInChildren<ParticleSystem>();      //On récupère le particle System enfant du player et on l'assigne à ShockWavePS
        DurationMaxPS = ShockWavePS.startLifetime;      //On récupère le lifetime du PS et on l'assigne à DurationMaxPS
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("ShockWave") && SWactivable == true)        //Si Player appuie R et SWactivable tru : on lance une 1ere Coroutine (Celle qui sert de Cooldown)
        {
            StartCoroutine(SWcooldown());
            
        }
        
       
        
    }


    IEnumerator SWcooldown()
    {
        ShockWavePS.Play();     //Lancement du PS
        SWactivable = false;        //On empêche de Spam R
        //print("bite en bois");      //IMPORTANT NE PAS TOUCHER !!!


        Collider2D[] SWzone = Physics2D.OverlapCircleAll(transform.position, RangeSW);      // le overlap cr�� un circle Collider2D �ph�m�re, ils ajoute tous les collider d�tect�s dans la liste SWzone


        //Pour chaque Collider de la liste SWzone on active la Coroutine SWdetection
        foreach (Collider2D coll in SWzone)     
        {
            
            StartCoroutine (SWDetection(coll));
        }        

        //Après 2sec d'attentes on réactive la possibilite de lancer la ShockWave
        yield return new WaitForSeconds(2);     

        SWactivable = true;
        //print("karsher dans le cul");       //IMPORTANT NE PAS TOUCHER !!!


    }



    IEnumerator SWDetection(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("RevealPlateform"))      //Si le go contenant le coll a le tag "Reveal" : on recupere son sprite renderer et on le change
            {
                
                AlphaLerpDelay = ((gameObject.transform.position - coll.gameObject.transform.position).magnitude) / RangeSW;        //On calcul la distance entre le joueur et la plateforme ce qui determine l'Alpha du Lerp Ci-Dessous
                InteractionDelay = Mathf.Lerp(DurationMinPS, DurationMaxPS, AlphaLerpDelay);        //On determine le temps que mets la SW à atteindre la plateforme grace à l'Alpha Lerp et donc la distance player -> Plateforme
                yield return new WaitForSeconds(InteractionDelay);      //On attend et on lance l'effet voulu
                coll.gameObject.GetComponent<SpriteRenderer>().sprite = RevealSprite; //Changer le sprite des plateformes par celui voulu (à définir directement dans l'inspecteur du player)
              
        }

            else if (coll.gameObject.CompareTag("DestructPlateform"))       //Si le go contenant le coll a le tag "Destruct" : on le detruit
            {
                AlphaLerpDelay = ((gameObject.transform.position - coll.gameObject.transform.position).magnitude) / RangeSW;
                InteractionDelay = Mathf.Lerp(DurationMinPS, DurationMaxPS, AlphaLerpDelay);
                yield return new WaitForSeconds(InteractionDelay);
                Destroy(coll.gameObject);
            }
        }

    

    /*void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, 255, 0, 70);
        Gizmos.DrawSphere(transform.position, RangeSW);
    }*/
    
    
}
