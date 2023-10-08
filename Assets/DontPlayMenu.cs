using UnityEngine;
using UnityEngine.SceneManagement;

public class DontPlayMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        Application.Quit();
    }
}
