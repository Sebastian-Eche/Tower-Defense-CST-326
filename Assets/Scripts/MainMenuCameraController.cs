using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraController : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(switchCamera());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchCamera()
    {
        // yield return new WaitForSeconds(1f);
        Camera.SetActive(true);
    }
}
