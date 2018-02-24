using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityStandardAssets.Utility.TimedObjectActivator;

public class LightArray : MonoBehaviour {
    public List<GameObject> lightsOff = new List<GameObject>();
    public List<GameObject> lightsOn = new List<GameObject>();
    public int lightPos;
    public int trail;
    private bool stop = false;
    public AudioSource winSound;
    // Use this for initialization

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stop = true;
          
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stop = false;
        }

        if (lightsOn.Count < 1)
        {
            for (int i = 0; i < trail; i++)
            {
                lightsOn.Add(lightsOff[i + lightPos]);
                lightsOff.Remove(lightsOff[i + lightPos]);

            }
        }
      


        Invoke("lightClear", .0001f);

        for (int i = 0; i < lightsOn.Count; i++)
        {
            lightsOn[i].SetActive(true);
        }

        for (int i = 0; i < lightsOff.Count; i++)
        {
            lightsOff[i].SetActive(false);
        }
        //  if (lightList.Count <= 10)
        // {
        //  lightList.Add(Random.Range(0, 90));

        // }
        // lightList.Remove(Random.Range(0, 90));


        if ((lightsOn[0].tag == "winLight") && (stop == true))
        {
            winSound.Play();
            Debug.Log("WINNER");

            stop = false;
            lightsOn.Remove(lightsOn[0]);
            trail = 30;
         
            }
        }
    



        void lightClear()
    {
            if (stop == false)
            {

                for (int i = 0; i < 100; i++)
                {
                    lightsOff.Add(lightsOn[i]);
                    lightsOn.Remove(lightsOn[i]);

                }

                lightsOn.Clear();
           
            }
        }

    }

