using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsNumbersAndAlphabets, prefabsNumbers;
    private readonly float z = -1.21f;
    private int currentIndex = 0;
    private List<Vector3> usedPositions = new List<Vector3>();
    private string testType;

    void Start()
    {
        testType = PlayerPrefs.GetString("TestType");
        if (currentIndex == 0)  // Ensure that instantiation only happens once
        {
            StartCoroutine(InstantiatePrefabs());
        }
    }

    IEnumerator InstantiatePrefabs()
    {
        while (currentIndex < prefabsNumbersAndAlphabets.Length)
        {
            Vector3 spawnPos = GenerateRandomPosition();
            if (testType == "B")
            {
                Instantiate(prefabsNumbersAndAlphabets[currentIndex], spawnPos, prefabsNumbersAndAlphabets[currentIndex].transform.rotation);
            }
            else
            {
                Instantiate(prefabsNumbers[currentIndex], spawnPos, prefabsNumbers[currentIndex].transform.rotation);
            }
            usedPositions.Add(spawnPos);
            currentIndex++;
            yield return null;
        }

        // Disable the SpawnManager component after instantiation
        this.enabled = false;
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX, randomY;
        Vector3 spawnPos;

        do
        {
            randomX = Random.Range(-6.0f, 4f);
            randomY = Random.Range(0, 3.4f);
            spawnPos = new Vector3(randomX, randomY, z);
        } while (IsPositionUsed(spawnPos));

        return spawnPos;
    }

    bool IsPositionUsed(Vector3 position)
    {
        foreach (Vector3 usedPos in usedPositions)
        {
            if (Vector3.Distance(position, usedPos) < 1.1f)
            {
                return true;
            }
        }
        return false;
    }
}