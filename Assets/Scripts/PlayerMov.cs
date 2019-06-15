using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float jumpStrength;

    private bool isJumping;
    Rigidbody playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        isJumping = false;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.Playing)
        {
            if (Input.GetKey(KeyCode.Space) && !isJumping)
            {
                playerRB.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
                isJumping = true;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                playerRB.AddForce(Vector3.forward * speed, ForceMode.Acceleration);



            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                playerRB.AddForce(Vector3.back * speed, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                playerRB.AddForce(Vector3.left * speed, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                playerRB.AddForce(Vector3.right * speed, ForceMode.Acceleration);
        }

        

    }

    void OnCollisionEnter(Collision o)
    {
        string oTag = o.gameObject.tag;
        switch (oTag)
        {
            case "Floor":
                isJumping = false;
                break;
            case "Lava":
                PlayerLooses();
                GameManager.Instance.GameOver = true;
                break;
            case "FinishLine":
                GameManager.Instance.Win = true; 
                break;
        }
    }
    void PlayerLooses()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}
