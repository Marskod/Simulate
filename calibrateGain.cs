using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class calibrateGain : MonoBehaviour {

    List<float> samples;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getGain(float sampRate) {
        float sampPeriod = 3; // 3 second sampling period

        InvokeRepeating("sampleAlpha", 0, sampRate);

        // Wait for sample data to populate
        StartCoroutine(wait(sampPeriod));

        CancelInvoke("sampleAlpha");

        return calcGain();
    }

    void sampleAlpha () {
        samples.Add(gameObject.GetComponent<grabJson>().values[41]);
    }

    int calcGain () {
        double objMass = 1.0;

        double avg = samples.Average();

        // Since [ avg * gain = objMass * gravity_acc ] makes the object stable
        return (int)( (objMass * 9.81) / avg);
    }

    IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
