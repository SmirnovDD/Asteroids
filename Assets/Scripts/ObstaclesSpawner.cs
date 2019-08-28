using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstacles; //метеориты и вражеские корабли
    public GameObject buff; //префаб бафа
    public float obstaclesSpawntime; //как часто появляются

    private float timer;
    void Start()
    {
        timer = Time.time;
    }

    void Update()
    {
        if(Time.time > timer)
        {
            SpawnObstacle();
            timer = Time.time + obstaclesSpawntime;
        }
    }

    void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)],
            new Vector3(Random.Range(-ShipMotor.boundaries, ShipMotor.boundaries), 0, ShipMotor.frustrumHeight + 2f), Quaternion.identity); //добавляем в сцену случайные препятствия с Х от левой до правой границы экрана и высотой на 2м выше границы экрана

        int randomBuffSpawn = Random.Range(0, 10);

        GameObject newBuff;
        if (randomBuffSpawn > 6)
            newBuff = Instantiate(buff, new Vector3(Random.Range(-ShipMotor.boundaries, ShipMotor.boundaries), 0, ShipMotor.frustrumHeight + 2f), Quaternion.identity);
    }
}
