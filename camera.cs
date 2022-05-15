using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class camera : MonoBehaviour
{

    public float playerYaxis;
    public float playerZaxis;
    public float playerXaxis;

    public float playerYaxisRot;
    public float playerXaxisRot;


    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        
 

        if (mousePos.x >= 0 || mousePos.x <= Screen.width && mousePos.y >= 0 || mousePos.y <= Screen.height) {
            //Up and down 90 degrees

            if(mousePos.y >= (Screen.height / 2f) && mousePos.y <= Screen.height) {
                float whatsleft = mousePos.y - (Screen.height / 2f);
                float degrees = whatsleft / ((Screen.height / 2f) / 90f);
                playerYaxisRot = -degrees;                
            };
            if(mousePos.y < (Screen.height / 2f) && mousePos.y >= 0) {
                float whatsleft1 = (Screen.height / 2f) - mousePos.y;
                float degrees1 = whatsleft1 / ((Screen.height / 2f) / 90f);
                playerYaxisRot = degrees1;                
            };

            // Left and right 720

            if (mousePos.x >= (Screen.width / 2f) && mousePos.x <= Screen.width) {
                float thatsleft = mousePos.x - (Screen.width / 2f);
                float xdegrees = thatsleft / ((Screen.width / 2f) / 720f);
                playerXaxisRot = xdegrees;
            };
            if (mousePos.x < (Screen.width / 2f) && mousePos.x >= 0) {
                float thatsleft1 = (Screen.width / 2f) - mousePos.x;
                float xdegrees1 = thatsleft1 / ((Screen.width / 2f) / 720f);
                playerXaxisRot = -xdegrees1;
            };

            // controller for rotating the camera up, down, 90 and left, right 720
            transform.eulerAngles = new Vector3(playerYaxisRot, playerXaxisRot, 0);
        }; 

        playerXaxis = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        playerYaxis = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        playerZaxis = GameObject.FindGameObjectWithTag("Player").transform.position.z;


        //playerScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;

        transform.position = new Vector3(playerXaxis, playerYaxis, playerZaxis);
    }
}
