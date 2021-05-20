using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject[] cameraList;
    private int currentCamera;
    [SerializeField] private float gameTime;
    [SerializeField] private float timeForCameraSwitch;
    private bool stopCount = false;
    void Start()
    {
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }

        if (cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
        if (!stopCount)
        {
            CalculateGameTime();
        }
    }
    public void SwitchCamera()
    {
        currentCamera++;
        if (currentCamera < cameraList.Length)
        {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            cameraList[currentCamera].gameObject.SetActive(true);
        }
        else
        {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
        }
    }

    public void ChooseFarCamera()
    {
        cameraList[0].gameObject.SetActive(false);
        cameraList[1].gameObject.SetActive(true);
    }

    private void CalculateGameTime()
    {
        gameTime += Time.deltaTime;
        if(gameTime >= timeForCameraSwitch)
        {
            stopCount = true;
            SwitchCamera();
        }
    }
}
