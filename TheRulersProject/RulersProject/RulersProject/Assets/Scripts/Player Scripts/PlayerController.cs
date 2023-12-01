using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }
    CharacterController charController;
    Animator thisAnimator;
    float hor;
    float ver;

    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        thisAnimator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hor , 0 , ver);

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation , 5);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
        }       

        thisAnimator.SetFloat("Speed" , direction.normalized.magnitude, 0.1F, Time.deltaTime );
        charController.Move( transform.forward * direction.magnitude * speed * Time.deltaTime);
    }
}
