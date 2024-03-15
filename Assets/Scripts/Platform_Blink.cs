using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Blink : Plateformes
{
    private SpriteRenderer SR;
    private Color OriginalColor;
    private Color GhostColor;
    private bool IsSolid= true;

    [SerializeField] private float GhostAlpha = 0.5f;
    [SerializeField] private float SwitchIntervalle = 2f;
    // Start is called before the first frame update
    /*void Start()
    
        base.Start();
        SR = GetComponent<SpriteRenderer>();
        OriginalColor = SR.color;
        GhostColor = SR.color;
        GhostColor.a = 0.5f;
        InvokeRepeating("SwitchState", SwitchIntervalle, SwitchIntervalle);
    }

    // Update is called once per frame
    void Update()
    {
    private void BeSolid()
        {
            Col.enabled = true;
            SR.color = OriginalColor;
        }

        private void BeGhost()
        {
            Col.enabled = false;
            SR.color = GhostColor;
        }

        private void SwitchState()
        {
            if (IsSolid)
            {
                BeGhost();
            }
            else
            {
                BeSolid();
            }
            IsSolid = !IsSolid;
        }
    }*/
}
