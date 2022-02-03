using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}


