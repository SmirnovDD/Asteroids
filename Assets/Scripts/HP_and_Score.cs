using UnityEngine;

public class HP_and_Score : MonoBehaviour
{
    private int HP //с помощью свойства прибавляем очки за сбитое припятствие при уничтожении объекта
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0 && hitByPlayer) GameController.UpdateScore(score); //прибавляем счет, только если последнее попадание от снаряда игрока
            Destroy(gameObject);
        }
    }
    public int score;
    public int hp;

    private ObstaclesMovement obstMove; //скрипт движения на этом припятствии
    private bool hitByPlayer; //мы хотим начислять очки, только если объект был уничтожен игроком, для этого при попадании проверяем, со снарядом ли игрока произошло столконовение
    void Start()
    {
        obstMove = GetComponent<ObstaclesMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitByPlayer = collision.gameObject.CompareTag("PlayerProjectile") ? true : false; //если попали снарядом игрока, то отмечаем переменную
        HP--;

        if(collision.gameObject.CompareTag("EnemyProjectile") || collision.gameObject.CompareTag("PlayerProjectile"))
            Destroy(collision.gameObject); //уничтожаем снаряд
    }
}
