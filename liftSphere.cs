using UnityEngine;
using System.Collections;

public class liftSphere : MonoBehaviour {

    public float height = 2.46f;

    private float baseHeight;

    public float val;
    public int offset = 100;

    public float smoothness = 2;

    void Start()
    {
        baseHeight = height;
    }

	// Update is called once per frame
	void Update () {
        val = gameObject.GetComponent<grabJson>().values[41];

        /*if (height >= (baseHeight+1))
            height = (baseHeight + 1);
        else if (height <= (baseHeight - 1))
            height = (baseHeight - 1);
        */

        
        height = val * offset;

        //Get the future position based on the values passed through JSON 
        Vector3 update = new Vector3(transform.position.x, height, transform.position.z);
        //Create a value that will LERP based on current position and future position 
        float trans = Mathf.Lerp(transform.position.y, update.y, Time.deltaTime * smoothness);
        //Change the position based on the lerp value 
        transform.position = new Vector3(transform.position.x, trans, transform.position.z);
	}
}
