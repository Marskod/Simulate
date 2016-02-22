using UnityEngine;
using System.Collections;

public class grabJson : MonoBehaviour {

    string url = "localhost:3000/session/front_test/fft";
    public string data = "";

    public float[] values;
    private int c = 0;

    public float timer = .5f;
    private float timer2;

    public bool on = false;  
    public bool startOn = false; 
	// Use this for initialization
	void Start () {
        timer2 = timer;

        // Initialize BCI board
        StartCoroutine(checkJSON("localhost:3000/session/front_test/start"));
        if (startOn == true)
            on = true;
        else
            Debug.Log("ERROR: Cannot grab initial JSON");
    }
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                StartCoroutine(WaitForRequest());
                timer = timer2;
            }
        }

            /*string encodedString = "{\"field1\": 0.5,\"field2\": \"sampletext\",\"field3\": [1,2,3]}";
            JSONObject j = new JSONObject(encodedString);
            accessData(j);*/
	}

    void OnGUI()
    {
        if(GUILayout.Button("Start")){
            StartCoroutine(checkJSON("localhost:3000/session/front_test/start"));
            if (startOn == true)
                on = true;
            else
                Debug.Log("ERROR: Cannot grab initial JSON");
        } 
    }

    void OnApplicationQuit()
    {
        url = "localhost:3000/session/front_test/stop";
        startOn = false;
        on = false; 
    }

    IEnumerator WaitForRequest()
    {
        WWW www = new WWW(url);
        
        yield return www;
        data = www.text; 
        // check for errors
        if (www.error == null)
        {
            c = 0;
            //Debug.Log("WWW Ok!: " + www.data);
            JSONObject j = new JSONObject(data);
            accessData(j);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator checkJSON(string start)
    {
        WWW www = new WWW(start);

        //yield return www;

        // check for errors
        if (www.error == null)
        {
            startOn = true; 
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        yield return www;
    }

    void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    //Debug.Log(key);
                    accessData(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    accessData(j);
                }
                break;
            case JSONObject.Type.STRING:
                Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                //JSONObject arr = obj["fft"];
                //Debug.Log(arr[40].n);
                fill(obj.n);
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;
        }
    }

    void fill(float x)
    {
        values[c] = x;
        c++;
    }
}
