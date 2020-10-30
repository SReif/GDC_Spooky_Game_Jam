using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public GameObject objBase;

    private void Update()
    {
        if(objBase.gameObject.GetComponent<PlantHealth>().health <= 0)
        {
            Lose();
        }
    }

    void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
