using UnityEngine;

public class Buster : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.left;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb;
        if (other.CompareTag("Marble"))
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(direction, ForceMode.Impulse);
            Debug.Log("Толкнули в лево");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
