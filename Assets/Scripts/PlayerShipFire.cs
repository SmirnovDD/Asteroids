using UnityEngine;

public class PlayerShipFire : ShipFire
{
    public override void Fire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject newProjectile = Instantiate(projectilePrefab, gunPoint[0].position, Quaternion.identity); //создаем снаряд
            newProjectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileSpeed); //добавляем ему силу
            timer = Time.time + fireCooldown; //после выстрела создаем временной промежуток до следующего выстрела
        }
    }
}
