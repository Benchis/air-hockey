using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Level");
    }
}