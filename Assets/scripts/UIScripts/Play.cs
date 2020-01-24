using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {
    public int ProgrammngLanguage;
    public void BAMSPressed()
    {
        heroCounters.lang = heroCounters.Language.Python;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CSPressed()
    {
        heroCounters.lang = heroCounters.Language.Csharp;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void JavaPressed()
    {
        heroCounters.lang = heroCounters.Language.Java;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
