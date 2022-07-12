using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static int enemyAmount = 0;
    
    private int currentWave = 0;
    private Dictionary<int, List<GameObject>> waves = new Dictionary<int, List<GameObject>>();
    private int wave = 1;
    private int enemyToWave = 0;
    [SerializeField] private TextMeshProUGUI winText; 

    [SerializeField] private GameObject s1;
    [SerializeField] private GameObject s2;
    [SerializeField] private GameObject s3;
    [SerializeField] private GameObject g1;
    [SerializeField] private GameObject g2;
    [SerializeField] private GameObject g3;
    [SerializeField] private GameObject tS;

    void Start()
    {
        waves.Add(1, new List<GameObject>{g1});
        waves.Add(2, new List<GameObject>{g1, s1});
        waves.Add(3, new List<GameObject>{g1, g1, s1, s1});
        waves.Add(4, new List<GameObject>{g1, g1, g1, s1, s1, s1});
        waves.Add(5, new List<GameObject>{g1, g1, g1, g2, g2, s2, s2, s1});
        waves.Add(6, new List<GameObject>{g1, g2, g2, s2, s1, s2, s2});
        waves.Add(7, new List<GameObject>{g1, g1, g1, g1, g1, g1, s1, s1, s1, s1, s1, g2, s2, s3});
        waves.Add(8, new List<GameObject>{g1, g1, g2, g2, g2, s2, s2, s2, s3, s3, g3, g3});
        waves.Add(9, new List<GameObject>{g3, g3, g3, g2, g2, g2, s2, s2, s2, s3, s3});
        waves.Add(10, new List<GameObject>{g1, g1, g1, g1, g1, s1 ,s1, s1, s1, s1, s1, s1, g2, g2, g2, g2, s2, s2, s2, s2, s3, s3, s3, s3, g3 ,g3, g3, g3, tS});
        StartCoroutine("WaveSpawner");
    }

    // Update is called once per frame
    void OnDestroy()
    {
        enemyAmount = 0;
    }

    private IEnumerator WaveSpawner(){
        yield return new WaitForSecondsRealtime(2.5f);
        while (true)
        {
            if(enemyAmount <= enemyToWave && wave <= 10){
                foreach(GameObject e in waves[wave]){
                    Instantiate(e, new Vector3(0,0,0), Quaternion.identity);
                    enemyAmount++;
                    yield return new WaitForSeconds(0.35f);
                }
                wave++;
                if(enemyToWave < 3 && wave % 2 == 1) enemyToWave++;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.05f);
            if(enemyAmount == 0 && wave == 11){
                yield return new WaitForSeconds(1f);
                winText.gameObject.SetActive(true);
            }
        }
    }
}
