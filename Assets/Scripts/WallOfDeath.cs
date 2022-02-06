using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Platform")) return;
        
        Platform platform = other.GetComponentInParent<Platform>();

        if (platform != null)
        {
            MoveToLastPosition(platform);
            platform.GetComponentInChildren<CloudMaster>().ResetClouds();
        }
    }
    
    private void MoveToLastPosition(Platform platform)
    {
        var pos = platform.transform.position;
        platform.transform.position = new Vector3(pos.x, pos.y, 98f);
        //pos.z + (platforms.Count - 1) * (platforms[0].transform.lossyScale.z * multiplier));
    }
}
