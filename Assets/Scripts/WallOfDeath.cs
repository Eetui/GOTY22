using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
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
        platform.transform.position = new Vector3(pos.x, pos.y, 98f);
        //pos.z + (platforms.Count - 1) * (platforms[0].transform.lossyScale.z * multiplier));
    }
}
