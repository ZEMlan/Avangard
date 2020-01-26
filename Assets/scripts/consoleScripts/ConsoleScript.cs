using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WindowsInput;

public class ConsoleScript : MonoBehaviour
{
    private static InputField input;
    private SpriteRenderer screenRed, screenGreen;
    private Button butNext, butOK, butExitR, butExitG;
    private InputSimulator inputSimulator = new InputSimulator();
    public static GameObject hero;
    private Canvas canvas;
    private int attempts = 0;
    public int score = 14;
    private int maxScore;
    public robotStatistics stat;
    private int bestScore;
    //всё далее должно храниться в xml
    private string error = "\n\nFatal error code DI35: encoding error.\nCannot read inner code files: unknown symbol ‘?’.";
    private static string codeTask;
    private static string codeAns;
    private static string[] answer;

    void Start()
    {
        InitAll();
        answer = codeAns.Split('\n');
        //первым делом выводим ошибку
        input.text = error;
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0.0f && input.isFocused)
        {
            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.UP);
        }
        else if (scroll < 0.0f && input.isFocused)
        {
            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.DOWN); 
        }
    }

    void InitAll()
    {
        hero = GameObject.Find("hero");
        canvas = ConsoleHandleScript.consoleCanvas;
        input = ConsoleHandleScript.input;
        screenGreen = ConsoleHandleScript.screenGreen;
        screenRed = ConsoleHandleScript.screenRed;
        butExitG = ConsoleHandleScript.butExitG;
        butExitR = ConsoleHandleScript.butExitR;
        butNext = ConsoleHandleScript.butNext;
        butOK = ConsoleHandleScript.butOK;
    }

    public void CalculateScore()
    {
        maxScore = score;
        heroCounters.attempts += 1;
        string[] playerAnswer = Clean(input.text.Split('\n'));
        answer = Clean(answer);
        for (int i = 0; i < playerAnswer.Length; i++)
        {
            try
            {
                if (!(playerAnswer[i] == answer[i]))
                    score--;
            } catch 
            {
                score--;
            }
        }
        
        if (score < 0)
            score = 0;

        if (score > bestScore)
            bestScore = score;

        if (score == maxScore || heroCounters.attempts == 3)
        {
            FindObjectOfType<questObjScr>().CompleteTask();
            heroCounters.score += bestScore;
            heroCounters.maxScore += maxScore;
            bestScore = 0;
            heroCounters.attempts = 0;
            consoleOpen.can_open = false;
            consoleOpen.need_to_update = true;
        }


        ExitConsole();
        stat.OpenWindow(score, maxScore);
        score = maxScore;
    }

    private string[] Clean(string[] array)
    {
        string res = "";
        foreach(var i in array)
        {
            if (!i.Equals(""))
                res += i + "\n";
            i.Replace(' ', '$');
        }
        return res.Split('\n');
    }

    public void ExitConsole()
    {
        canvas.gameObject.SetActive(false);
        Input.ResetInputAxes();
        consoleOpen.is_open = false;
        heromove.is_moving = true;
    }

    public void ChangeScreene()
    {
        input.interactable = true;
        input.text = codeTask;
        butExitG.gameObject.SetActive(true);
        butExitR.gameObject.SetActive(false);
        butNext.gameObject.SetActive(false);
        butOK.gameObject.SetActive(true);
        screenGreen.enabled = true;
        screenRed.enabled = false;
    }

    public static void UpdateTask()
    {
        input.text = codeTask;
        answer = codeAns.Split('\n');
    }

    public void SetCode(string task, string answer, int count)
    {
        codeTask = task;
        codeAns = answer;
        score = count;
    }

    public void OpenFinalConsole()
    {
        canvas.gameObject.SetActive(true);
        heromove.is_moving = false;
        ChangeScreene();
        codeTask = string.Format("\n\n\nНабранно баллов: {0} из {1}.\n" +
        "Время прохождение: {2}\n\nДля завершения игры нажмите \"ОК\".", heroCounters.score, heroCounters.maxScore,
        GetTime());
        UpdateTask();
        butOK.onClick.AddListener(delegate { CloseGame(); });
    }

    private void CloseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private string GetTime()
    {
        System.DateTime first = heroCounters.StartTime;
        System.DateTime last = System.DateTime.Now;
        int calc = last.Second - first.Second;
        return calc/60 + " мин. " + (calc - calc/60) +" сек.";
    }
}
