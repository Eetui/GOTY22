using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaster : MonoBehaviour
{
    //Transform points
    public Transform spot0;
    public Transform spot1;
    public Transform spot2;

    //objects
    public GameObject cloud0;
    public GameObject cloud1;
    public GameObject cloud2;

    private List<CloudLogic> clouds = new List<CloudLogic>();

    int order;

    void Start()
    {
        RandomizeOrder();
        
        clouds.Add(cloud0.GetComponent<CloudLogic>());
        clouds.Add(cloud1.GetComponent<CloudLogic>());
        clouds.Add(cloud2.GetComponent<CloudLogic>());
    }

    public void ResetClouds()
    {
        foreach (var cloud in clouds)
        {
            cloud.ResetState();
        }
        
        RandomizeOrder();
    }

    public void RandomizeOrder()
    {
        order = Random.Range(0, 3);

        if (order == 0)
        {
            cloud0.transform.position = spot0.position;
            cloud1.transform.position = spot1.position;
            cloud2.transform.position = spot2.position;
        }else if (order == 1)
        {
            cloud0.transform.position = spot2.position;
            cloud1.transform.position = spot0.position;
            cloud2.transform.position = spot1.position;
        }
        else if (order == 2)
        {
            cloud0.transform.position = spot1.position;
            cloud1.transform.position = spot2.position;
            cloud2.transform.position = spot0.position;
        }
        else
        {
            Debug.Log("RandomizeOrder error - CloudMaster");
        }
    }

    //Editor testing : TODO: Delete or comment
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RandomizeOrder();
        }
    }

}
