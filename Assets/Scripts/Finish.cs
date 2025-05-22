using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private GameObject Canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.parent != null && other.transform.parent.CompareTag("Marble")) ;
        {
            Time.timeScale = 0;
            Canvas.SetActive(true);
            m_TextMeshPro.text="���������� - "+ other.transform.parent.name;
        }
    }
    public void RestartScene()
    {
        // �������� �������� ����� � ������������� �
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
