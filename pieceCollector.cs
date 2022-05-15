using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceCollector : MonoBehaviour
{
    public float pieceX;
    public float pieceZ;

    public GameObject[] test;

    public float pieceCollection = 0;

    public int pieceAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (float i = 0; i < (float)pieceAmount; i++) {
            GameObject clones = Instantiate(GameObject.FindGameObjectWithTag("piece"), new Vector3(-10f, 2.5f, i), Quaternion.identity);
            clones.tag = "piece";
        } 

    }

    // Update is called once per frame
    void Update()
    {
        test = GameObject.FindGameObjectsWithTag("piece");

        for (int i = 0; i < pieceAmount; i++) {
            pieceX = test[i].transform.position.x;
            pieceZ = test[i].transform.position.z;

            // if the player is near some value then he will be prompted to pick it up
            // THEN ALSO CHECK FOR the y axis value to determine that youre on the right floor
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - pieceX, 2f) + Mathf.Pow(transform.position.z - pieceZ, 2f)) <= 2f) {
                if(Input.GetKeyDown(KeyCode.E)) {
                    pieceCollection += 1f;
                    Debug.Log(pieceCollection);
                    test[i].SetActive(false);
                }

            }
        }
        //Debug.Log(test[1].transform.position.x);

        // every piece needs to have their own id to mark them as collected // fixed

        // chess piece collection system fixed, now its just placing them out and fix the count to 25 thing to win
        // but that is a thing for later   ------- - look at me

        // lets create a fucking gun yeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaahhhhhhhhhhhhh
    }
}
