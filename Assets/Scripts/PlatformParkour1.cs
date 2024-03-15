using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformParkour1 : MonoBehaviour
{

    private List<Vector2> CheckpointPositions = new List<Vector2>();
    private int NextCheckPoint=0;
    private float Speed = 1f;
    private int Sens = 1;

    [SerializeField] private bool IsPingPong;
    [SerializeField] private UnityEngine.Color TextColor=Color.white;
    [SerializeField] private Vector2 TextOffset;
    [SerializeField] private int TextSize=20;
    [SerializeField] private float StartDelay;
    [SerializeField] private float EndDelay;
    [SerializeField] private float CheckpointDelay;



    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<transform.childCount;i++)
        {
            CheckpointPositions.Add(transform.GetChild(i).position);
        }
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private IEnumerator Move()
    {
        float step = Speed * 0.01f;
        Vector3 target = CheckpointPositions[NextCheckPoint];

        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if (transform.position == target)
        {
            yield return new WaitForSeconds(CheckpointDelay);

            if(NextCheckPoint==0)
            {
                yield return new WaitForSeconds(StartDelay);
            }

            if (NextCheckPoint== CheckpointPositions.Count-1)
            {
                yield return new WaitForSeconds(EndDelay);
            }

            if (Sens > 0 && NextCheckPoint < CheckpointPositions.Count - 1 || (Sens < 0 && NextCheckPoint > 0))
            {
                NextCheckPoint += Sens;
            }
            else
            {
                if (IsPingPong)
                {
                    Sens = -Sens;
                }
                else
                {
                    NextCheckPoint = 0;
                }

            }

        }
        yield return new WaitForSeconds(CheckpointDelay);
        StartCoroutine(Move());
    }
    private void OnDrawGizmos()
    {
        
        GUI.color = TextColor;
        GUIStyle labelStyle = GUI.skin.label;
        labelStyle.fontStyle = FontStyle.Bold;
        labelStyle.fontSize = TextSize;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        
        for (int i=0; i<transform.childCount;i++)
        {
           
            Handles.Label((Vector2)transform.GetChild(i).position + TextOffset, i.ToString(),labelStyle);
            if (i< transform.childCount -1)
            {
                Handles.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position, 2f);
            }
            else
            {
                Handles.DrawLine(transform.GetChild(i).position, transform.GetChild(0).position, 2f);
            }
        }
        

    }
}
