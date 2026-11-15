using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
