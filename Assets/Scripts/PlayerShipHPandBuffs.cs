using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerShipHPandBuffs : MonoBehaviour
{
    public float PlayerShipHP
    {
        get { return playerShipHP; }
        set { playerShipHP = value; if (playerShipHP <= 0) RestartGame(); } //перезагрузку уровня я решил оставить в этом скрипте
    }

    private GameController gc; //ссылка нужна для отображения панели здоровья, весь UI я хотел иметь в одном скрипте

    [SerializeField]
    private float playerShipHP; //уровень HP
    private float maxPlayerShipHP;

    private PlayerShipFire playerShipFire; //ссылка для бафа скорости атаки

    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController; //самая малость отражения
        playerShipFire = GetComponent<PlayerShipFire>(); //и еще немного
        maxPlayerShipHP = PlayerShipHP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Buff"))
        {
            RandomBuff(); //если стокнулся баф, то не отнимаем здоровье, а вызываем функцию
            Destroy(collision.gameObject);
            return;
        }

        PlayerShipHP--;
        gc.UpdateHPBar(Mathf.Clamp(PlayerShipHP / maxPlayerShipHP, 0, 1)); //передаем процент заполнения шкалы здоровья в скрипте game controller

        if (collision.gameObject.CompareTag("EnemyProjectile") || collision.gameObject.CompareTag("EnemyShip")) //метеориты уничтожаются сами в скрипте HP_and_Score
            Destroy(collision.gameObject);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void RandomBuff()
    {
        int chooseRandomBuff = Random.Range(0, 2); //от 0 до 1, коварный момент, верхняя граница не включается
        if (chooseRandomBuff == 0)
        {
            PlayerShipHP++;
            PlayerShipHP = Mathf.Clamp(PlayerShipHP, 0, maxPlayerShipHP); //в данном случае прибавлять больше изначального максимума нельзя
            gc.UpdateHPBar(Mathf.Clamp(PlayerShipHP / maxPlayerShipHP, 0, 1)); //передаем процент заполнения шкалы здоровья в скрипте game controller
        }
        else
        {
            playerShipFire.fireCooldown /= 1.1f; //не добавляю минимальный кулдаун
        }
    }
}
