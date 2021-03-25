using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureScript : MonoBehaviour
{

    public Animation animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay()
    {
        if (Input.GetKey("e"))
        {
            animator.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
