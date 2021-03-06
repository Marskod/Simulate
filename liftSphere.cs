﻿using UnityEngine;
using System.Collections;

public class liftSphere : MonoBehaviour {

    public float height = 2.46f;

    private float baseHeight;
    public int gain;
    public int gain_audio = 10; 

    public float smoothness = 2;

    public Rigidbody rb;

    float alpha;
    float lowBound, highBound;

    void Start()
    {
        baseHeight = height;
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y > 75)
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        //for (int i = 40; i < 3; i++)
          // alpha += gameObject.GetComponent<grabJson>().values[i]; // ~10hz avg
        //alpha /= 3.0f;
        alpha = gameObject.GetComponent<grabJson>().values[41] + gameObject.GetComponent<grabJson>().values[42] + gameObject.GetComponent<grabJson>().values[40];
        alpha /= 3f;
        //Debug.Log(alpha);
        lowBound = gameObject.GetComponent<grabJson>().values[18]; // Corresponds to ~7hz
        highBound = gameObject.GetComponent<grabJson>().values[55]; // Corresponds to ~13hz

        /*if (height >= (baseHeight+1))
            height = (baseHeight + 1);
        else if (height <= (baseHeight - 1))
            height = (baseHeight - 1);
        */

        /*
        gain = gameObject.GetComponent<calibrateGain>().getGain(.5f);

        if (gain == null)
            gain = 0;
        Debug.Log(gain);
        */

        //height = val * offset;

        gameObject.GetComponent<AudioSource>().pitch = (transform.position.y)/25;

        // Find difference between alpha band and adjacent frequencies
        float diff =  Mathf.Pow(alpha,3) - (lowBound + highBound) / 2.0f;

        // Don't allow negative forces
        if (diff < 0.0f)
            diff = 0.0f;

        Vector3 mindForce = new Vector3(0.0f, alpha*gain, 0.0f);

        //Get the future position based on the values passed through JSON 
        //Vector3 update = new Vector3(transform.position.x, height, transform.position.z);
        //Create a value that will LERP based on current position and future position 
        //float trans = Mathf.Lerp(transform.position.y, update.y, Time.deltaTime * smoothness);
        //Change the position based on the lerp value 
        //transform.position = new Vector3(transform.position.x, trans, transform.position.z);
        Debug.Log(mindForce);
        rb.AddForce(mindForce);
	}
}
