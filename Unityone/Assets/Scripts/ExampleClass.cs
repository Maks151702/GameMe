using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("UnityOne");
        Debug.Log("No");
    }
}