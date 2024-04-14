using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickable : MonoBehaviour
{
    public GameObject ob;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player") && transform.name == "win")
            SceneManager.LoadScene("SampleScene");
        else
            ob.SetActive(true);
    }
}