using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            GameManager.Instance.ScorePoints();
            this.gameObject.SetActive(false);
        }
    }
}
