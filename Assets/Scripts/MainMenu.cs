using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Option()
    {
        SceneManager.LoadScene("OptionMenu");
    }
}
