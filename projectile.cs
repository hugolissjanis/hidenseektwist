using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    static float NextFloat(float min, float max) {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
    
    public float speed;
    public bool flag;
    public Transform Sphere;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        float randomPos = NextFloat(-10.67f, 9.3f);
        if (flag) {
            transform.position += new Vector3(0, 0, speed -= 0.0001f);
        }
        if (speed < -0.1) {
            transform.position = new Vector3(randomPos, 0, 35.44f);
            speed = 0;
        };

        Instantiate(Sphere, new Vector3(randomPos, -2.64f, 35.44f), Quaternion.identity);

    }
}
