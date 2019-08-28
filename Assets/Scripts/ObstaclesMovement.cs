using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public enum ObstacleType
    {
        meteor,
        smallShip,
        mediumShip,
        largeShip
    };
    public ObstacleType obstacleType;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if(obstacleType == ObstacleType.meteor) //если появился простой метиорит
            GetComponent<Rigidbody>().AddForce(Vector3.back * speed + Vector3.right * Random.Range(-10, 11));//добавляем метеориту скорость движения вниз экрана под случайным углом
    }

    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        if (obstacleType == ObstacleType.meteor)
            return;

        if (obstacleType == ObstacleType.smallShip)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if(obstacleType == ObstacleType.mediumShip)
        {
            transform.Translate((Vector3.back * speed + Vector3.right * Mathf.Sin(Time.time) * 10) * Time.deltaTime);
        }
        else if (obstacleType == ObstacleType.largeShip)
        {
            transform.Translate((Vector3.back * speed + Vector3.right * Mathf.Cos(Time.time) * 10) * Time.deltaTime);
        }
    }
}
