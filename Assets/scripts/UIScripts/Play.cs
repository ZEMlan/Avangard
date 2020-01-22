using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {
    public int ProgrammngLanguage;
    public void BAMSPressed()
    {
        ProgrammngLanguage = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CSPressed()
    {
        ProgrammngLanguage = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void JavaPressed()
    {
        ProgrammngLanguage = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
