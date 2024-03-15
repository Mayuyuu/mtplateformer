using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlitchBar : MonoBehaviour
{

    public float GlitchPower;
    public float GlitchMax;
    public Image GlitchImage;

    public Material glitchMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GlitchImageSetFillAmount();
        GlitchAberationChromatiqueParameterAugmentationCFaitUnPeuLong();
    }

    public void GlitchImageSetFillAmount()
    {
        GlitchImage.fillAmount = /*1 - */(GlitchPower / GlitchMax); //permet de varier entre 0 et 1
    }

    public void GlitchAberationChromatiqueParameterAugmentationCFaitUnPeuLong()
    {
        glitchMaterial.SetFloat("_ParamGlitch", GlitchPower);
    }


    private void OnApplicationQuit()
    {
        glitchMaterial.SetFloat("_ParamGlitch", 0);
    }

}
