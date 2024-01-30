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
        isGrounded = false;
        RaycastHit hit;
        if(Physics.Raycast(groundCheck1.transform.position, Vector3.down, out hit, 0.1f)){
            if(hit.transform.tag == "Ground" || hit.transform.tag == "Player" || hit.transform.tag == "Abomination"){
                isGrounded = true;
            }
        }
        if(Physics.Raycast(groundCheck2.transform.position, Vector3.down, out hit, 0.1f)){
            if(hit.transform.tag == "Ground" || hit.transform.tag == "Player" || hit.transform.tag == "Abomination"){
                isGrounded = true;
            }
        }

        // Controls
        if(isGrounded){
            float horizontalVel = GetComponent<Rigidbody>().velocity.x;
            float horizontalForce = horizontalAccel * GetComponent<Rigidbody>().mass;
            if(Input.GetKey(left)){
                if(horizontalVel >= -maxHorizontalSpeed){
                    GetComponent<Rigidbody>().AddForce(Vector3.left * horizontalForce);
                }
            }

            if(Input.GetKey(right)){
                if(horizontalVel <= maxHorizontalSpeed){
                    GetComponent<Rigidbody>().AddForce(Vector3.right * horizontalForce);
                }
            }
        }

        if(Input.GetKey(jump) && isGrounded){
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpVelocity, 0);
        }
    }
}
