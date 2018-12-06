using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

	/* IEnumerator Start () {
        yield return new WaitForSeconds(1);
        StartGame();
    }*/

    public void StartGame()
    {
        SceneManager.LoadScene("newmap");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            StartGame();
        }
    }
}
