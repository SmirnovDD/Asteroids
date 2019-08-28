using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GameController : MonoBehaviour
{
    public static int totalScore;
    public static Text totalScoreText;

    public Image mainMenuPanel; //панель, на которой расположены кнопки начала и выхода из игры
    public Image HUDPanel; //панель, на которой расположены кнопки паузы, выхода и набираемые очки
    public Text _totalScoreText; //чтобы удобно было присваивать текст из инспетора статической переменной я сделал еще по одной переменной, можно было конечно присвоить ее с помощью поиска по тэгам

    public Image playerHPBar; //панель HP игрока

    private bool gameIsPaused = true;
    // Start is called before the first frame update
    void Start()
    {
        PauseGame(); //игра на паузе
        totalScoreText = _totalScoreText; //присваиваем значение статической переменной
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateScore(int addedScore)
    {
        totalScore += addedScore;
        totalScoreText.text = totalScore.ToString();
    }

    public void StartGame()// вызывается кнопкой startGameButton
    {
        PauseGame(); //сняли с паузы
        mainMenuPanel.gameObject.SetActive(false);
        HUDPanel.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = gameIsPaused ? 0 : 1;
        gameIsPaused = !gameIsPaused; //если была на паузе, то следующим нажатием снимаем с нее и наоборот
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    public void UpdateHPBar(float fillAmount)
    {
        playerHPBar.fillAmount = fillAmount;
    }
}
