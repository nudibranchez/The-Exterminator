using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject healthPrefab;

    [SerializeField]
    public float healthInterval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnKit(healthInterval,healthPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnKit(float interval, GameObject medKit)
    {
        yield return new WaitForSeconds(interval);
        GameObject newKit = Instantiate(medKit, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnKit(interval, medKit));
    }
}
