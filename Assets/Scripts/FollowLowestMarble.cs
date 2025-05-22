using UnityEngine;

public class FollowLowestMarble : MonoBehaviour
{
    public string marbleTag = "Marble"; // Тег шаров
    public float smoothSpeed = 5f;      // Скорость следования
    public float offsetY = 2f;          // Смещение камеры по высоте

    private Transform target;

    void Update()
    {
        FindLowestMarble();
        FollowTarget();
    }

    // Находим шар с минимальным Y
    private void FindLowestMarble()
    {
        GameObject[] marbles = GameObject.FindGameObjectsWithTag(marbleTag);
        float minY = float.MaxValue;
        Transform lowestMarble = null;

        foreach (GameObject marble in marbles)
        {
            if (marble.transform.position.y < minY)
            {
                minY = marble.transform.position.y;
                lowestMarble = marble.transform;
            }
        }

        if (lowestMarble != null)
        {
            target = lowestMarble;
        }
    }

    // Следим за шаром
    private void FollowTarget()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, target.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
