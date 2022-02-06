using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == true)
        {
            GameManager.Instance.TakeDamage();
            this.gameObject.SetActive(false);
        }
    }
}
