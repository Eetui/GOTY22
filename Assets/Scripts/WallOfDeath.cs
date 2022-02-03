using System;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private float multiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        var platform = other.GetComponentInParent<Platform>();
        
        if (platform != null)
        {
            ResetPosition(platform);
            platform.GetComponentInChildren<CloudMaster>().ResetClouds();
        }
    }
    
    private void ResetPosition(Platform platform)
    {
        var pos = platform.transform.position;
        platform.transform.position = new Vector3(
            pos.x,
            pos.y,
            pos.z + platforms.Length * (platforms[0].transform.lossyScale.z * multiplier));
    }
}
