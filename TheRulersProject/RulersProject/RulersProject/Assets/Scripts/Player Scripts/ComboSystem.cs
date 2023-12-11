using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ComboSystem : MonoBehaviour
{
    public GameObject sword;
    public GameObject OneHandedSword;
    private Animator anim;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
      
        if (!sword.activeInHierarchy && !OneHandedSword.activeInHierarchy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
            {
                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
            {

                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
            {
                PlayerController.instance.speed = 5;
                noOfClicks = 0;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_10"))
            {
                PlayerController.instance.speed = 5;
            }
        }
     
        if (sword.activeInHierarchy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_16"))
            {
                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_17"))
            {

                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_18"))
            {
                PlayerController.instance.speed = 5;
                noOfClicks = 0;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_06"))
            {
                PlayerController.instance.speed = 5;
            }
        }

        if (OneHandedSword.activeInHierarchy)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_07"))
            {
                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_12"))
            {
                PlayerController.instance.speed = 5;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_14"))
            {
                PlayerController.instance.speed = 5;
                noOfClicks = 0;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_06"))
            {
                PlayerController.instance.speed = 5;
            }
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            if (sword.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && noOfClicks == 0)
                {
                    anim.Play("Attack_06");
                    PlayerController.instance.speed = 0;
                }
            }
            if (OneHandedSword.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && noOfClicks == 0)
                {
                    anim.Play("Attack_06");
                    PlayerController.instance.speed = 0;
                }
            }
            if (!sword.activeInHierarchy && !OneHandedSword.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && noOfClicks == 0)
                {
                    anim.Play("Attack_10");
                    PlayerController.instance.speed = 0;
                }
            }
            // Check for mouse input
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnClick();
 
            }
        }
    }
 
    void OnClick()
    {      
        lastClickedTime = Time.time;
        noOfClicks++;
        if(!sword.activeInHierarchy && !OneHandedSword.activeInHierarchy)
        {
            if (noOfClicks == 1)
            {
                PlayerController.instance.speed = 0;
                anim.Play("hit1");
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

            if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("hit2");
            }
            if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("hit3");
            }
        }
        if (sword.activeInHierarchy)
        {
            if (noOfClicks == 1)
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_16");
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

            if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_16"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_17");
            }
            if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_17"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_18");
            }
        }
        if (OneHandedSword.activeInHierarchy)
        {
            if (noOfClicks == 1)
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_07");
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

            if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.55f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_07"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_12");
            }
            if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.55f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack_12"))
            {
                PlayerController.instance.speed = 0;
                anim.Play("Attack_14");
            }
        }
    }
}
