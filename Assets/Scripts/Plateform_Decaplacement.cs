using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform_Decaplacement : Plateformes
{
    protected Dictionary<Transform, Transform> Familles = new Dictionary<Transform, Transform>();
        // Start is called before the first frame update
        protected new void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (TestTag(collision.gameObject))
            {

                Familles.Add(collision.gameObject.transform, collision.gameObject.transform.parent);
                collision.gameObject.transform.SetParent(transform, true);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (TestTag(collision.gameObject))
            {
                Transform ancienParent;
                Familles.TryGetValue(collision.gameObject.transform, out ancienParent);
                collision.gameObject.transform.SetParent(ancienParent, true);
                Familles.Remove(collision.gameObject.transform);
            }
        }

        private bool TestTag(GameObject go)
        {
            return (go.CompareTag("Player") /*|| go.CompareTag("Enemy")*/);
        }
    
}