using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsNumbersAndAlphabets, prefabsNumbers;
    private readonly float z = -1.21f;
    private int currentIndex = 0;
    string testType;

    void Start()
    {
        StartCoroutine(InstantiatePrefabs());
        testType = PlayerPrefs.GetString("TestType");
    }

    IEnumerator InstantiatePrefabs()
    {
        List<Vector3> usedPositions = new List<Vector3>();

        while (currentIndex < prefabsNumbersAndAlphabets.Length)
        {
            Vector3 spawnPos = GenerateRandomPosition(usedPositions);
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
    }
    Vector3 GenerateRandomPosition(List<Vector3> usedPositions)
    {
        float randomX, randomY;
        Vector3 spawnPos;

        do
        {
            randomX = Random.Range(-6.0f, 4f);
            randomY = Random.Range(0, 3.4f);
            spawnPos = new Vector3(randomX, randomY, z);
        } while (IsPositionUsed(spawnPos, usedPositions));

        return spawnPos;
    }

    bool IsPositionUsed(Vector3 position, List<Vector3> usedPositions)
    {
        foreach (Vector3 usedPos in usedPositions)
        {
            if (Vector3.Distance(position, usedPos) < 1.1f) // Adjust this distance as needed
            {
                return true;
            }
        }
        return false;
    }
}
