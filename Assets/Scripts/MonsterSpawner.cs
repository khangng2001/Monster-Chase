using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform rightPos, leftPos;
    private GameObject spwanMonster;
    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        // rightPos = gameObject.transform.Find("Right").GetComponent<Transform>();
        // leftPos = gameObject.transform.Find("Left").GetComponent<Transform>();
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spwanMonster = Instantiate(monsterReference[randomIndex]);
            if (randomSide==0)
            {
                spwanMonster.transform.position = leftPos.position;
                spwanMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                spwanMonster.GetComponent<Monster>().transform.localScale = new Vector3(1f, 1f, 1f);
            }else{
                spwanMonster.transform.position = rightPos.position;    
                spwanMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spwanMonster.GetComponent<Monster>().transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
