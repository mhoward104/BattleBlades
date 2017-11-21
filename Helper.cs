using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Helper : MonoBehaviour
    {
        [Range(0, 1)]
        public float vertical;
        //[Range(1, 1)]
        public float horizontal;

        //public string animName;
        public bool playAnim;
        public string[] oh_attacks;
        public string[] th_attacks;
        public bool lockon;

        public bool twoHanded;
        public bool enableRm;
        Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

            enableRm = !anim.GetBool("canMove");
            anim.applyRootMotion = enableRm;

            if (enableRm)
                return;


            anim.SetBool("two_handed", twoHanded);

           if(lockon == true)
            {
                horizontal = 0;
                vertical = Mathf.Clamp01(vertical);
            }

            anim.SetBool("lockon", lockon);

            if (playAnim)
            {
                string targetAnim;

                if(!twoHanded)
                {
                    int r = Random.Range(0, oh_attacks.Length);
                    targetAnim = oh_attacks[r];
                    
                    if(vertical > .05f)
                    {
                        targetAnim = "oh_attack_3";
                    }
                }
                else
                {
                    int r = Random.Range(0, th_attacks.Length);
                    targetAnim = th_attacks[r];

                    if (vertical > .05f)
                    {
                        targetAnim = "oh_attack_3";
                    }
                }
                vertical = 0;

                anim.CrossFade(targetAnim, 0.2f);
                //anim.SetBool("canMove", false);
                //enableRm = true;
                
               
                playAnim = false;
                

            }
            anim.SetFloat("vertical", vertical);
            anim.SetFloat("horizontal", horizontal);

            
        }
    }
}
