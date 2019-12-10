using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float life = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
           Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Player>().fire)
            life -= 4*other.GetComponentInParent<Player>().damage;
        else
            life -= other.GetComponentInParent<Player>().damage;

        Debug.Log("Life: " + life);
    }
}
