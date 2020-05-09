using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{

    bool up;

    private void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveTraps();
    }


    void moveTraps() {
        
        float movement = 3.0f * Time.deltaTime;
        if (transform.position.y > 10.0f )
        {
            up = false;
        }
        else if(transform.position.y < 2.0f) {
            up = true;
        }


        if (up)
        {
            transform.Translate(new Vector3(0.0f, movement, 0.0f));
        }
        else {
            transform.Translate(new Vector3(0.0f, -movement, 0.0f));
        }

    }

}
