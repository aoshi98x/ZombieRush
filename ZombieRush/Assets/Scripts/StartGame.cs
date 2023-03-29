using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGameMethod()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
