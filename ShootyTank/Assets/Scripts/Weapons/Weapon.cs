using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected GameObject bullet;
    protected int[] damages = new int[6]{60, 75, 100, 150, 200, 250};
    protected float[] cooldowns = new float[6]{1f, 0.8f, 0.7f, 0.6f, 0.4f, 0.3f};
    protected float[] shotSpeeds = new float[6]{10f, 12f, 14f, 16, 18f, 20f};
    [SerializeField] protected int damage = 0;
    protected SoundManager sound;

    private void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        cooldown = cooldowns[Bank.playerDmg];
        damage = damages[Bank.playerDmg];
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    protected void Update()
    {
        Vector2 myPositionVector = transform.position;
        Vector2 mousePositionVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f,0f, (-Mathf.Atan2(myPositionVector.x - mousePositionVector.x, myPositionVector.y - mousePositionVector.y) * Mathf.Rad2Deg) - 90f));
    }

    protected IEnumerator Shoot(){
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
            if(shot.GetComponent<Projectile>() != null) {
                shot.GetComponent<Projectile>().damage = damage;
                sound.PlaySound("Shot", 1f);
                shot.GetComponent<Projectile>().shotSpeed = shotSpeeds[Bank.playerDmg];
            }
            else {
                sound.PlaySound("LaserShot", 1f);
                shot.GetComponentInChildren<LaserProjectile>().damage = damage;
            }
        }
    }
}
