using UnityEngine;

public class ShipMotor : MonoBehaviour
{
    public float speed; //максимальная скорость движения корабля по горизонтали
    public static float frustrumHeight; //высота экрана на проецируемой плоскости заданной длины, пригодится в скрипте obstacleSpawner
    public static float boundaries; //границы движения корабля по горизонтали, тоже статичная, чтобы не считать ее заного в скрипте obstacleSpawner
    private bool blockLeftMovement, blockRightMovement; //переменные для блокировки движения корабля влево или вправо
    void Start()
    {
        Camera mainCam = Camera.main;
        frustrumHeight = mainCam.transform.position.y * Mathf.Tan(mainCam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        boundaries = frustrumHeight * mainCam.aspect - 1f; //находим границы движения по горизонтали, 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!blockLeftMovement)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!blockRightMovement)
                transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.x <= -boundaries)            
            blockLeftMovement = true;       
        else if (transform.position.x >= boundaries)            
            blockRightMovement = true;            
        else            
            blockRightMovement = blockLeftMovement = false;           
    }
}
