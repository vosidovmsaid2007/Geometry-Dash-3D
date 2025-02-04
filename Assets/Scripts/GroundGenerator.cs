using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Префаб куба
    public int numberOfCubes = 3; // Количество стартовых кубов
    public float spacing = 19.5f; // Расстояние между кубами
    public Transform player; // Камера или объект, который движется

    private List<GameObject> activeCubes = new List<GameObject>();
    private float lastZPosition;

    void Start()
    {
        // Создаем первые кубы
        for (int i = 0; i < numberOfCubes; i++)
        {
            SpawnCube(i * spacing);
        }
    }

    void Update()
    {
        if (player.position.z >= lastZPosition - spacing) // Если камера приближается к последнему
        {
            SpawnCube(lastZPosition + spacing);
            RemoveOldCube(); // Удаляем старый
        }
    }

    void SpawnCube(float zPos)
    {
        Vector3 spawnPosition = new Vector3(0, 0, zPos);
        GameObject newCube = Instantiate(cubePrefab, spawnPosition, cubePrefab.transform.rotation);
        activeCubes.Add(newCube);
        lastZPosition = zPos;
    }

    void RemoveOldCube()
    {
        if (activeCubes.Count > numberOfCubes)
        {
            Destroy(activeCubes[0]); // Удаляем старый куб
            activeCubes.RemoveAt(0);
        }
    }
}
