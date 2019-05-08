using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject leftSpawn;
	public GameObject rightSpawn;
	public GameObject[] fish; // Lista jossa on eri kalat asetettuina
    [Header("Lists Have to be the same size!")]
    public int[] weight; // Lista kalojen "painoista" eli kuinka suurella todennäköisyydellä valitaan

    [Header("Spawn")]

    public float spawnDelay;
    public float spawnDelayRandomness;
    public float spawnTimer;

    [Header("Size")]

    public float ySize;
    float sum = 0;
	int side = 0; // 0 on vasen, 1 on oikea

    void Start () {

        if (spawnTimer == 0)
            spawnTimer = spawnDelay;
        if (weight.Length < fish.Length)
            Debug.Log("Ei vittu make nyt ne listat saman kokosiks");

        // painojen summa valintaa varten
        for (int i = 0; i<weight.Length; i++) {
            sum += weight[i];
        }
    }
	
	
	void FixedUpdate () {
        if (spawnTimer >= 0)
            spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
            spawnTimer = spawnDelay + Random.Range(0f,spawnDelayRandomness);
            SpawnFish();
        }
	}

    void SpawnFish() {
       
        // Kalan valinta joka spawnataan
        float randomWeight = Random.Range(0,sum); // sattumanvarainen paino nollan ja kaikkien kalojen yhteen lasketun painon välillä
        float selectionWeight = 0;   // Paino jonka halutaan vastaavan randomWeightiä, kasvatetaan aina seuraavan kalan painolla listaa läpi käydessä
        int currentFish = 0; // Tämän hetkisen esineen numero kala listassa
        while (selectionWeight < randomWeight)
        {
            selectionWeight = selectionWeight + weight[currentFish];
            currentFish++;
        }
		Vector3 spawnPos;
		GameObject spawnedFish;
        // paikka johon kala spawnataan
		if (side == 0) {
        	spawnPos = leftSpawn.transform.position;
			side = 1;
			spawnedFish = fish[currentFish - 1];
			spawnedFish.GetComponent<Fish>().right = true;
		} else {
			spawnPos = rightSpawn.transform.position;
			side = 0;
			spawnedFish = fish[currentFish - 1];
			spawnedFish.GetComponent<Fish>().right = false;
		}
        spawnPos.y += Random.Range(0f, ySize);
        Instantiate(spawnedFish, spawnPos, Quaternion.identity);
    }
}
