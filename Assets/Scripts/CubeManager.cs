using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Material cubeMaterial;
    private int clickCount;

    private SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        cubeMaterial = GetComponent<MeshRenderer>().material;
        clickCount = 0;
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform == this.transform)
                {   
                    clickCount++;
                    ChangeMaterial();
                }
                
            }
                
        }
    }

    private void ChangeMaterial()
    {
        if(clickCount == 1)
        {
            cubeMaterial.color = Color.red;
        }
        else if (clickCount == 2)
        {
            cubeMaterial.color = Color.green;
        }
        else if (clickCount == 3)
        {
            cubeMaterial.color = Color.blue;
        }
        else
        {
            Destroy(this.gameObject);
            sceneManager.DecreseNumberOfCubes();
        }
    }
}
