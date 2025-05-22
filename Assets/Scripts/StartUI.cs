using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public GameObject objectToSpawn;
    public TMP_InputField inputField;
    public Button startButton;
    public TextMeshProUGUI ErrorText;


    public BoxCollider areaCollider;

    private void Awake()
    {
        // Получаем BoxCollider у объекта, к которому прикреплён скрипт

        if (areaCollider == null || !areaCollider.isTrigger)
        {
            Debug.LogError("На объекте отсутствует BoxCollider с isTrigger = true!");
        }

        startButton.onClick.AddListener(StartSpawning);
    }

    private void StartSpawning()
    {
        // Считываем количество объектов из InputField
        if (int.TryParse(inputField.text, out int objectCount))
        {
            if (objectCount > 0)
            {
                SpawnObjects(objectCount);
            }
            else
            {
                ErrorText.text ="Введите положительное число.";
            }
        }
        else
        {
            ErrorText.text ="Введите корректное число.";
        }
    }
    public void SpawnObjects(int objectCount)
    {
        if (areaCollider == null) return;

        // Вычисляем границы области
        Vector3 minBounds = areaCollider.bounds.min;
        Vector3 maxBounds = areaCollider.bounds.max;

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );

            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            spawnedObject.name = $"Murble_{i + 1}";
            AssignRandomColor(spawnedObject);
        }
    }
    private void AssignRandomColor(GameObject obj)
    {
        // Ищем компонент Renderer у дочернего объекта
        Renderer sphereRenderer = obj.GetComponentInChildren<Renderer>();

        if (sphereRenderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            sphereRenderer.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning($"У объекта {obj.name} не найден Renderer у дочерних элементов.");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
