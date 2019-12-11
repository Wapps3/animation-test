using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;

    Animator animator;

    public float speed = 10;

    public float damage = 10.0f;

    public bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Cast");
            fire = true;
            GameObject tmp = GameObject.Find("Mutant:RightHand").gameObject;

            Instantiate(prefab, tmp.transform.position + new Vector3(0, 0.1f, -0.1f), Quaternion.identity, tmp.transform);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(.0f, 90.0f * Time.deltaTime, 0.0f, Space.World);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                gameObject.transform.Rotate(.0f, -90.0f * Time.deltaTime, 0.0f, Space.World);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                animator.SetFloat("Speed", Time.deltaTime * speed);
                gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("Speed", Time.deltaTime * speed);
                gameObject.transform.position += gameObject.transform.forward * -1 * Time.deltaTime * speed;
            }
        }

       
    }
}
