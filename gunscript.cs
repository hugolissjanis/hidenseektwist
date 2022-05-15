using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gunscript : MonoBehaviour
{
    public float gunX;
    public float gunZ;

    public GameObject player; 
    public GameObject gun; 
    public GameObject cam;
    public GameObject bullet;

    public float Xvalue;

    public bool haveGun;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gun = GameObject.FindGameObjectWithTag("gun");
        cam = GameObject.FindGameObjectWithTag("camham");
        bullet = GameObject.FindGameObjectWithTag("bullet");

        Cursor.visible = false;
        haveGun = false;
    }


    // Update is called once per frame
    void Update()
    {

        gunX = GameObject.FindGameObjectWithTag("gun").transform.position.x;
        gunZ = GameObject.FindGameObjectWithTag("gun").transform.position.z;

        //Debug.Log(gunZ);

        //Debug.Log(Mathf.Sqrt(Mathf.Pow(transform.position.x - gunX, 2f) + Mathf.Pow(transform.position.z - gunZ, 2f)));

        // Debug.Log(Math.Abs(player.transform.eulerAngles.y - gun.transform.eulerAngles.y));
        // Debug.Log("GUN");
        //Debug.Log(this.transform.position.x - player.transform.position.x));
        // Debug.Log(Math.Abs(this.transform.position.x - player.transform.position.x));
        // Debug.Log(player.transform.position.x);
        // Debug.Log(this.transform.position.x);

        // over 180 it places on the right
        // under 180 it places on the left
        // if its 0 it places in front (good)
        // if its 180 it places behind 

        // 270 x 0.750
        // 90 -0.750
        // 0, 0

        

        Physics.IgnoreCollision(player.transform.GetComponent<Collider>(), this.transform.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(bullet.transform.GetComponent<Collider>(), this.transform.GetComponent<Collider>(), true);
        if (Mathf.Sqrt(Mathf.Pow(GameObject.FindGameObjectWithTag("Player").transform.position.x - gunX, 2f) + Mathf.Pow(GameObject.FindGameObjectWithTag("Player").transform.position.z - gunZ, 2f)) <= 2f) {
            if(Input.GetKeyDown(KeyCode.E)) {
                haveGun = true;
                transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
                Debug.Log("picked up");


                this.GetComponent<Rigidbody>().useGravity = false;


                transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.4f, player.transform.position.z);
                transform.Translate(0.8f, 0, 1.4f);  // very good thing for changes with the arrows axes
                gun.transform.parent = player.transform;

                // fix so when you look up the gun points up and vise versa. fix so that you cant pick it up if its in your hand
                // fix some kind of drop 
                // then lets get to the shooting part aka the fuin part

                //m_Rigidbody.velocity = transform.left;
                //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (speed * Time.deltaTime));
                // if (Math.Abs(this.transform.position.x - player.transform.position.x) > 180) {
                //     transform.position = new Vector3(player.transform.position.x - ((0.75f/90) * Math.Abs(this.transform.position.x - player.transform.position.x)), 1f, player.transform.position.z + 1.5f);
                // }
                // if (Math.Abs(this.transform.position.x - player.transform.position.x) < 180) {
                //     transform.position = new Vector3(player.transform.position.x + ((0.75f/90) * Math.Abs(this.transform.position.x - player.transform.position.x)), 1f, player.transform.position.z + 1.5f);
                // }

                //transform.position = new Vector3(player.transform.position.x  + 3f, 1f, player.transform.position.z + 1.5f);


                //transform.position = new Vector3(-1f *(player.transform.position.x - 0.65f), 1f, player.transform.position.z + 1.5f);
                //transform.localScale = new Vector3(0.125f, 0.09f, 1f);

                // problem when it rotates it also moves to some side so need to some kind of calculation on
                // how many degrees it has to move to become 90 degrees to the player (infront of him)  and dependent on
                // that value move it more to the left, after that the fun begins

                // fix when crouch and proning and having the gun
            }
        }


        if (haveGun) {
            if (cam.transform.localEulerAngles.x <= 360f && cam.transform.localEulerAngles.x >= 270f) {
                Xvalue = cam.transform.localEulerAngles.x - 360f;
            } 

            if (cam.transform.localEulerAngles.x < 270f) {
                Xvalue = cam.transform.localEulerAngles.x;
            }
            transform.eulerAngles = new Vector3(Xvalue * 0.2f, player.transform.eulerAngles.y, 0);
        }

        //make it shoot

        if (Input.GetButton("Fire") && haveGun) {
            Debug.Log("raa raa raa");

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            // Quaternion q = Quaternion.Euler(Xvalue * 0.2f, player.transform.eulerAngles.y, 0);
            // Vector3 tst = new Vector3(gun.transform.position.x + 0.25f, gun.transform.position.y, gun.transform.position.z + 1.7f);
            // GameObject bullets = Instantiate(GameObject.FindGameObjectWithTag("piece"), tst, q);
            // // bullet.transform = transform.Translate(0, 0, 0.01f);
            // Debug.Log(bullet.transform.position.x);
            // bullets.tag = "bullet";
        }


        // lets create a fucking gun with bullts(clones)
        // first if you get close you can pick up the gun   fixed
        // then fix that the gun is attached to the body // almost done its just a big problem when you jump that the 
        // gun dosent follow the player up, think thats a parent-child behaviour issue
        // the fix the shooting aka making bullets fly when holding down mouse 1 // so fun
        // then fix some sort of magazine and reload
         //  at the end fix some sort of collision damage system
         // also make the gun design look like a gun (play dough version)
    }
}
