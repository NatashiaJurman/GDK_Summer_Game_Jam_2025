using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuFuncionality : MonoBehaviour
{
public void BeginGame()
    {
        SceneManager.LoadScene("LowPolyScene");
    }

public void Quit()
    {
        Application.Quit(); 
    }
}
