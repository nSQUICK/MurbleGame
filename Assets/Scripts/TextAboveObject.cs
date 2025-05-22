using UnityEngine;
using TMPro;

public class TextAboveObject : MonoBehaviour
{
    public Transform marble; // ������ �� �����
    public Transform textObject; // ������ �� ������ � �������
    public Camera mainCamera; // ������
    public Vector3 offset = new Vector3(0, 1f, 0); // �������� ������ ��� ��������

    private TextMeshProUGUI textMesh; // ��������� ������

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; // ��������������� ������, ���� �� ������

        if (textObject != null)
        {
            textMesh = textObject.GetComponent<TextMeshProUGUI>();
            textMesh.text = gameObject.name; // ������������� �������� �������
        }
    }

    void Update()
    {
        if (marble != null && textObject != null)
        {
            // ��������� ������� ������ ��� �������
            textObject.position = marble.position + offset;

            // ������������ ����� � ������
            textObject.LookAt(mainCamera.transform);
            textObject.Rotate(0, 180, 0); // ������������� �����, ��� ��� LookAt ������ ��� ����������
        }
    }
}
