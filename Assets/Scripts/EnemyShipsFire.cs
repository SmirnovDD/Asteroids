using UnityEngine;

public class EnemyShipsFire : ShipFire
{
    public override void Fire()
    {
        foreach (Transform gp in gunPoint) //для каждой из пушек
        {
            GameObject newProjectile = Instantiate(projectilePrefab, gp.position, Quaternion.identity); //создаем снаряд
            newProjectile.GetComponent<Rigidbody>().AddForce((playerPos.position - gp.position).normalized * projectileSpeed); //добавляем ему силу
        }
        timer = Time.time + fireCooldown; //после выстрела создаем временной промежуток до следующего выстрела
    }
}
