using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

	IEnumerator Start () {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("robs-sandbox");
    }	
}
