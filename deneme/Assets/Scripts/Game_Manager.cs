using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;
    public bool isRunnerOver = false ;
    public GameObject player;
    private Vector3 currentVelocity;
    private float smoothTime = 0.2f;
    Vector3 target;

    public GameObject wallPaint;
    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        target = new Vector3(1.49f, 0.019f, 62.7f);

    }
    void Update()
    {
        if (isRunnerOver)
        {
            wallPaint.SetActive(true);
            player.transform.localPosition = Vector3.SmoothDamp(player.transform.localPosition, target, ref currentVelocity, smoothTime);
        }
    }
    public void Restart_Level()
    {
        SceneManager.LoadScene("Demo_Scene");
    }
}
