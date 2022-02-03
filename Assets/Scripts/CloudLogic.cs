using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLogic : MonoBehaviour
{
    public GameObject original_cloud;
    public GameObject storm_cloud;
    public GameObject rainbow;
    public int stateNum;
    public int hiddenNum;
    public GameObject bullet;

    void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        original_cloud.SetActive(true);
        storm_cloud.SetActive(false);
        rainbow.SetActive(false);
    }

    void SetState()
    {
        if(hiddenNum == 0)
        {
            original_cloud.SetActive(true); //TRUE
            storm_cloud.SetActive(false);
            rainbow.SetActive(false);

        }else if (hiddenNum == 1)
        {
            original_cloud.SetActive(false);
            storm_cloud.SetActive(true); //TRUE
            rainbow.SetActive(false);
        }
        else if (hiddenNum == 2)
        {
            original_cloud.SetActive(false);
            storm_cloud.SetActive(false);
            rainbow.SetActive(true); //TRUE
        }
        else
        {
            Debug.Log("stateNum error" + stateNum + " : script :" + this);
        }
    }


    //Editor testing : TODO: Delete or comment
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetState();
        }

        if (Input.GetKeyDown("1"))
        {
            SetState();
        }
    }

    //Bullet collision
    private void OnTriggerEnter(Collider other)
    {
        if(TryGetComponent(out Bullet bullet))
        {
            SetState();
        }        
    }
}