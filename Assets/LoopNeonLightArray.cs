using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopNeonLightArray : MonoBehaviour {
    public GameObject[] lights;
    public float speed;
    private bool lightOn;

	// Use this for initialization
	void Start () {
        InvokeRepeating("lightShow", speed, speed);

    }
	
	// Update is called once per frame
	void Update () {
        if (lightOn == true)
        {
            lights[0].SetActive(true);
            lights[1].SetActive(false);
            lights[3].SetActive(true);
            lights[2].SetActive(false);
        }
        else {
            lights[1].SetActive(true);
            lights[0].SetActive(false);
            lights[2].SetActive(true);
            lights[3].SetActive(false);
        }
       
        Debug.Log("LS="+lightOn);
	}
    void lightShow()
    {
    if (lightOn == true)
        {
            lightOn = false;
        }

        else if(lightOn==false) 
            {
            lightOn = true;
        }

    }


}
