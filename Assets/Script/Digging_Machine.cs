using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging_Machine : MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 endPosition_OnStart = new Vector3(-20, -1.36f, 0);
    private Vector3 endPosition_OnDead = new Vector3(45, -1.36f, 0);
    
    [SerializeField] private float desiredDuration_OnStart = 3f;
    [SerializeField] private float desiredDuration_OnDead = 3f;

    private float elpasedTime;

    private Player player;
    
    bool isDone = false;

    void Start()
    {
        startPosition = transform.position;
        player = FindObjectOfType<Player>();
        var myValue = Mathf.Lerp(0, 10, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            OnPlayerDeathMachineLocation();
        }
        else
        {
            OnPlayerStartMachineLocation();
        }
        elpasedTime += Time.deltaTime;
    }

    void OnPlayerDeathMachineLocation()
    {
        if (!isDone)
        {
            elpasedTime = 0;
            isDone = true;
        }
        float percentageComplete = elpasedTime / desiredDuration_OnDead;
        transform.position = Vector3.Lerp(endPosition_OnStart, endPosition_OnDead, Mathf.SmoothStep(0, 1, percentageComplete));
    }

    void OnPlayerStartMachineLocation()
    {
        float percentageComplete = elpasedTime / desiredDuration_OnStart;
        transform.position = Vector3.Lerp(startPosition, endPosition_OnStart, Mathf.SmoothStep(0, 1, percentageComplete));
    }
}