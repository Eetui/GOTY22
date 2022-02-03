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

    int order;

    void Start()
    {
        RandomizeOrder();
    }

    void RandomizeOrder()
    {
        order = Random.Range(0, 3);
        Debug.Log("?" + order);

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
