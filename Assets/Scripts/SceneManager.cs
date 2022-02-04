using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneManager : MonoBehaviour
{
    public PointsManager pointsManager;

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private int MaxNumberOfCubes = 10;
    [SerializeField]
    private int InitialNumberOfCubes = 5;

    private int currentNumberOfCubes;

    // Start is called before the first frame update
    void Start()
    {
        for (int cubeCounter = 0; cubeCounter < InitialNumberOfCubes; cubeCounter++)
        {
            if (cubeCounter < MaxNumberOfCubes)
            {
                SpawnRandomCube();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(currentNumberOfCubes < MaxNumberOfCubes)
            {
                
                SpawnRandomCube();
            }
        }
    }

    private void SpawnRandomCube()
    {
        if(cubePrefab)
        {
            currentNumberOfCubes++;
            Instantiate(cubePrefab, RandomVector3Value(-4, 4), Random.rotation);
        }
        else
        {
            Debug.LogError("Nie mamy ustawionego obiektu do generowania na scenie!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }

    private Vector3 RandomVector3Value(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }

    public void DecreseNumberOfCubes()
    {
        currentNumberOfCubes--;
        if(pointsManager)
        {
            pointsManager.IncreaseScore();
        }
        else
        {
            pointsManager = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<PointsManager>();
            pointsManager.IncreaseScore();
        }
        
    }
}
