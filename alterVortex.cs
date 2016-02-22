using UnityEngine;
using System.Collections;

using UnityStandardAssets.ImageEffects;

public class alterVortex : MonoBehaviour {


    public float iTime = 56f;
    public float zTime = 1.0f;

    public float lowerBound = -.02f;
    public float upperBound = .03f;

    public GameObject particles;
    public GameObject particles2;

    public GameObject[] front;


    public int mult = 40;
    /*public GameObject cube;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;*/
    void Start()
    {
        //Resources.Load("Music/Listen.mp3") = gameObject.GetComponent<AudioSource>().audio; 
        front = GameObject.FindGameObjectsWithTag("front");
    }

	void Update () {
        //iTime -= Time.deltaTime;

        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
        ParticleSystem ps2 = particles2.GetComponent<ParticleSystem>();

        //front[0].GetComponent<ParticleSystem>().startSpeed = 100;
        ParticleSystem[] p = new ParticleSystem[front.Length]; 
        for (int i = 0; i < front.Length; i++)
        {
            p[i] = front[i].GetComponent<ParticleSystem>();
        }

        p[0].startLifetime = (Mathf.Pow(2, 1+detectSound("c1")*10));
        p[0].startSpeed = (Mathf.Pow(2, 1 + detectSound("c1") * 10));

        p[1].startLifetime = (Mathf.Pow(2, 1 + detectSound("c3") * 10));
        p[1].startSpeed = (Mathf.Pow(2, 1 + detectSound("c3") * 10));

        p[2].startLifetime = (Mathf.Pow(2, 1 + detectSound("c4") * 10));
        p[2].startSpeed = (Mathf.Pow(2, 1 + detectSound("c4") * 10));

        p[3].startLifetime = (Mathf.Pow(2, 1 + detectSound("c5") * 10));
        p[3].startSpeed = (Mathf.Pow(2, 1 + detectSound("c5") * 10));

        /*Ps2*/
        ps2.startSpeed = (detectSound("c1") * 100);
        ps2.startLifetime = (detectSound("c1") * 50);
        ps2.startSize = (detectSound("c1") * 3);
        
        /*Ps*/
        ps.emissionRate = (detectSound("c1") * 40);

        //UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(particles.GetComponent<ParticleSystem>());

        //so.FindProperty("ShapeModule.angle").floatValue = (detectSound("c1") * 400);
        //so.ApplyModifiedProperties();

        //cube = GameObject.FindGameObjectWithTag("MoveCube");
        /*cube.transform.position = new Vector3(detectSound("c1")*400*Time.deltaTime, cube.transform.position.y, cube.transform.position.z);
        cube1.transform.position = new Vector3(detectSound("c3") * 400 * Time.deltaTime, 1.9f, cube.transform.position.z);
        cube2.transform.position = new Vector3(detectSound("c4") * 400 * Time.deltaTime, 3.43f, cube.transform.position.z);
        cube3.transform.position = new Vector3(detectSound("c5") * 400 * Time.deltaTime, 5.05f, cube.transform.position.z);*/
        //if (iTime < 0)


        swayHI(Random.Range(lowerBound, 0), Random.Range(0, upperBound + .5f));
	}

    void swayHI(float min, float max)
    {
        float sway = Mathf.Lerp(min, max, Time.time);

        zTime -= Time.deltaTime;

        //Move forward  
        if (zTime > 0 && zTime < 1)
        {
            switch (Random.Range(1, 4)) { 
                case 1:
                    gameObject.GetComponent<Vortex>().angle += detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x -= detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y += detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x += detectSound("c5") * mult/3 * Time.deltaTime;
                    break;
                case 2:
                    gameObject.GetComponent<Vortex>().angle -= detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x += detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y -= detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x -= detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
                case 3:
                    gameObject.GetComponent<Vortex>().angle += detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x -= detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y += detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x -= detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
                case 4:
                    gameObject.GetComponent<Vortex>().angle -= detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x += detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y -= detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x += detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
            }
        }
        //Move back
        else if(zTime < 0 && zTime > -1)
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    gameObject.GetComponent<Vortex>().angle -= detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x -= detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y -= detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x += detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
                case 2:
                    gameObject.GetComponent<Vortex>().angle += detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x += detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y += detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x += detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
                case 3:
                    gameObject.GetComponent<Vortex>().angle -= detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x -= detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y -= detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x -= detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
                case 4:
                    gameObject.GetComponent<Vortex>().angle += detectSound("c1") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.x += detectSound("c3") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().radius.y += detectSound("c4") * mult * Time.deltaTime;
                    gameObject.GetComponent<Vortex>().center.x += detectSound("c5") * mult / 3 * Time.deltaTime;
                    break;
            }
        }

        if (zTime < -1)
            zTime = 1;
    }

    float detectSound(string c)
    {
        float[] sound = gameObject.GetComponent<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.Hamming);

        //sound[0] 0  - 21hz ...
        float c1 = sound[4] + sound[2] + sound[3];
        float c3 = sound[12] + sound[13] + sound[11];
        float c4 = sound[22] + sound[23] + sound[24];
        float c5 = sound[44] + sound[45] + sound[46] + sound[47] + sound[48] + sound[49];
          
        switch (c)
        {
            case "c1":
                return c1;
                break;
            case "c3":
                return c3;
                break;
            case "c4":
                return c4;
                break;
            case "c5":
                return c5;
                break;
        }

        return -1;
    }
}

