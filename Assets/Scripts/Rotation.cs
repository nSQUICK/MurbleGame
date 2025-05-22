using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float Speed = 10f;
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 0, -1);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis*Speed*Time.deltaTime);
    }
}
