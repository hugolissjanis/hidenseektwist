using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public float speed;

    Color colorStart = Color.red;
    public float test;
    Renderer rend;

    public float fatigue = 0;
    public float fatigueCount = 0;
    public bool runFatigue = true; 

    public float jumpForce = 50f;

    Rigidbody rb;

    public bool groundColliderBool = false;

    public bool playerSizeNormal;


    // 3.3 5.72     3.53   6.12  23 40          2.3 3.97 2.5 4.32  20 35     

    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector3(0, 2, 0);
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // check if player collides with ground
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ground") {
            groundColliderBool = true;
        }
    }

    // check if player leaves the ground (does not collide with the groud anymore)
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "ground") {
            groundColliderBool = false;
        }
    }

    void WASD() {
        speed = 10f;
        // crouch but needs tweaking with going back to normal stance, also change speed, fix crouch to prone stance
        // maybe switch to just getbutton if we wanna do hold and not toggle
        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            if (transform.localScale.x != 2f || transform.localScale.y != 2f || transform.localScale.z != 1f) {
                transform.localScale = new Vector3(2f, 2f, 1f);             
            } else {
                if (transform.localScale.x == 2f && transform.localScale.y == 2f && transform.localScale.z == 1f) {
                    transform.localScale = new Vector3(2f, 4f, 1f); 
                }
            }            
        } 
        // prone fuck yesa, everything listed like crouch but also cam needs to change because of the +2f to the z scale (lay down)
        if(Input.GetKeyDown(KeyCode.Z)) {
            if (transform.localScale.x != 2f || transform.localScale.y != 1.7f || transform.localScale.z != 3f) {
                transform.localScale = new Vector3(2f, 1.7f, 3f);
            } else {
                if (transform.localScale.x == 2f && transform.localScale.y == 1.7f && transform.localScale.z == 3f) {
                    transform.localScale = new Vector3(2f, 4f, 1f);
                }
            }
        }

        // change speed when crouch and prone
        if(transform.localScale.x == 2f && transform.localScale.y == 2f && transform.localScale.z == 1f) {
            speed = 6f;
            playerSizeNormal = false;
        }
        if(transform.localScale.x == 2f && transform.localScale.y == 1.7f && transform.localScale.z == 3f) {
            speed = 3f;
            playerSizeNormal = false;
        }
        // check if normal size
        if(transform.localScale.x == 2f && transform.localScale.y == 4f && transform.localScale.z == 1f) {
            playerSizeNormal = true;
        }
        // run, make some kind of run fatigue / stamina, make so you can only run forward (WHEN PRESSING W)
        // in futher make some kind of counter of the sprint fatigue thing
        if (Input.GetButton("Run") && Input.GetButton("Wvertical") && runFatigue && playerSizeNormal && groundColliderBool) {
            speed = 18f;
            fatigue += 1f;
            if (fatigue >= 1200f) {
                Debug.Log("you have to wait");
                fatigue = 0;
                runFatigue = false;
            }
        }

        if (fatigue != 0 && !Input.GetButton("Run")) {
            fatigue -= 0.5f;
        }

        if (!runFatigue) {
            fatigueCount += 1f;
            if (fatigueCount >= 1600f) {
                Debug.Log("you can run again");
                fatigueCount = 0;
                runFatigue = true;
            }
        }

        // handling the jump and jump when on ground
        if (Input.GetKeyDown(KeyCode.Space) && playerSizeNormal) {
            if (groundColliderBool) {
                rb.AddForce((new Vector3(0, 2f, 0)) * jumpForce, ForceMode.Impulse);
            }
        }
        // fix the shitty jump mechanic Input.GetAxis("Jump"), more important
        // fix when you have sprinted and stops that the bar refills, probably do later, fucko thing

        // To Do 
        // fix that you cant jump when you crouch or prone     check
        // fix so yuo cant run while crouch or prone      check
        // FIX so when you jump and leave the ground that you cant affect the speed by running

        // to do
        // fix the run fatigue so when you run but dont crush the stamina bar to the grave (when you just walk or stand still) -
        // you regain stamina    // check

        // is movement + camera done ????????, then start this fkn game

        // to do sabado
        // start with pieces
        // then multiplayer part and beginning of game / end winning loosing, stun gun, coutning, UI
        // create map, this step will kill me, almost get a templete

        // pieces, radius of something will prompt you to pick it up and that will add to your collection

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (speed * Time.deltaTime));

    }

    // Update is called once per frame
    void Update() {      
        WASD();

        test = GameObject.FindGameObjectWithTag("camham").transform.eulerAngles.y;        
        transform.eulerAngles = new Vector3(0, test, 0);

        rend.material.color = colorStart; 
    }
}


