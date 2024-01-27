using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;

    public float maxHorizontalSpeed;
    public float horizontalAccel;

    public GameObject groundCheck1;
    public GameObject groundCheck2;
    public bool isGrounded = false;
    

    public float jumpVelocity = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ground check
        RaycastHit2D[] hits;
        hits = Physics2D.LinecastAll(groundCheck1.transform.position, groundCheck2.transform.position);
        isGrounded = false;
        for (int i = 0; i < hits.Length; i++){
            RaycastHit2D hit = hits[i];
            if(hit.transform.tag == "Ground"){
                isGrounded = true;
            }
        }

        // Controls
        if(isGrounded){
            float horizontalVel = GetComponent<Rigidbody2D>().velocity.x;
            float horizontalForce = horizontalAccel * GetComponent<Rigidbody2D>().mass;
            if(Input.GetKey(left)){
                if(horizontalVel >= -maxHorizontalSpeed){
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * horizontalForce);
                }
            }

            if(Input.GetKey(right)){
                if(horizontalVel <= maxHorizontalSpeed){
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalForce);
                }
            }
        }

        if(Input.GetKey(jump) && isGrounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
        }
    }
}
