using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlicthManager : MonoBehaviour
{

    public Image GlitchBar;
    public float glitchAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        /*if (glitchAmount <= 0)
        {
            SceneManager.SetActiveScene();
        }
        */

        {
            
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }



    public void TakeDamage(float damage)
    {
        glitchAmount -= damage; 
        GlitchBar.fillAmount = glitchAmount/100f;
    }


    public void Heal(float amount)
    {
        glitchAmount += amount; //??
        glitchAmount = Mathf.Clamp(glitchAmount, 0, 100);

        GlitchBar.fillAmount = glitchAmount / 100f;
    }
}
