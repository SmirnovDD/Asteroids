using UnityEngine;

public class ShipFire : MonoBehaviour //базовый класс стрельбы кораблей
{
    public GameObject projectilePrefab; //префаб снарядов
    public Transform[] gunPoint; //точка, из которой стреляем
    public float projectileSpeed; //скорость полета снарядов
    public float fireCooldown; //время между выстрелами
    [HideInInspector]
    public Transform playerPos; //нужна для стрельбы вражеских кораблей
    [HideInInspector]
    public float timer; //переменная для задержки между выстрелами
    void Start()
    {
        timer = Time.time;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Time.time > timer)
        {
            Fire();
        }
    }

    virtual public void Fire()
    {

    }
}
