using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int counter;
    public Text counterText;
    public Text winText;
    public Text speedText;
    private float timeCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        SetCountText();
        winText.text = "";
        speedText.text = "";
        timeCounter = 0.0f;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * (speed + (counter*5)));

        if (Time.deltaTime - timeCounter > 3.0f && !speedText.text.Equals(""))
        {
            speedText.text = "";
        }
    }

    private void Update()
    {
        SetSpeedText();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            counter++;
            SetCountText();
        }

       
    }

    void SetCountText() {
        counterText.text = "Count: " + counter.ToString();
        if (counter >= 9)
        {
            winText.text = "You win";
        }
        else {
            speedText.text = "Speed X" + (speed + (counter * 5)).ToString();
            timeCounter = 2.0f;
        }
    }


    void SetSpeedText() {
        timeCounter -= Time.deltaTime;
        if (timeCounter < 0.0f && !speedText.text.Equals(""))
        {
            speedText.text = "";
        }
    }
}
