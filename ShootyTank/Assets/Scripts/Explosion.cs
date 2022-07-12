using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    [SerializeField]public int explosions = 0;
    [SerializeField] private GameObject copy;
    private SpriteRenderer sprite;
    [SerializeField] protected Sprite[] sprites = new Sprite[3];
    private SoundManager sound;

    void Start()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        StartCoroutine("BOOM");
        sound.PlaySound("Explosion", 1f);
        sprite = transform.GetComponent<SpriteRenderer>();
        StartCoroutine("Anim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BOOM(){
        yield return new WaitForSeconds(0.4f);
        for(int i = 0; i < explosions; i++){
            GameObject bum = Instantiate(copy, new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1f, 1f), transform.position.z), Quaternion.identity);
            bum.GetComponent<Explosion>().explosions = 0;
            bum.transform.localScale = new Vector3(2.194592f, 2.194592f, 2.194592f);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(0.2f);
        if(explosions > 4){
            SceneManager.LoadScene("UpgradeStation");
        }
        Destroy(gameObject);
    }

    private IEnumerator Anim(){
        sprite.sprite = sprites[0];
        yield return new WaitForSeconds(0.3f + explosions * 10);
        sprite.sprite = sprites[1];
        yield return new WaitForSeconds(0.3f);
        sprite.sprite = sprites[2];
        yield return new WaitForSeconds(0);
    }
}
