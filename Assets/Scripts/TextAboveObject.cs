using UnityEngine;
using TMPro;

public class TextAboveObject : MonoBehaviour
{
    public Transform marble; // Ссылка на шарик
    public Transform textObject; // Ссылка на объект с текстом
    public Camera mainCamera; // Камера
    public Vector3 offset = new Vector3(0, 1f, 0); // Смещение текста над объектом

    private TextMeshProUGUI textMesh; // Компонент текста

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; // Автоопределение камеры, если не задана

        if (textObject != null)
        {
            textMesh = textObject.GetComponent<TextMeshProUGUI>();
            textMesh.text = gameObject.name; // Устанавливаем название объекта
        }
    }

    void Update()
    {
        if (marble != null && textObject != null)
        {
            // Обновляем позицию текста над шариком
            textObject.position = marble.position + offset;

            // Поворачиваем текст к камере
            textObject.LookAt(mainCamera.transform);
            textObject.Rotate(0, 180, 0); // Разворачиваем текст, так как LookAt делает его зеркальным
        }
    }
}
