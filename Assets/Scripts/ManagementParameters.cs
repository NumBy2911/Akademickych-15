using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementParameters : MonoBehaviour
{
    private static ManagementParameters instance;
    public float finishedTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setFinishedTime(float _finishedTime)
    {
        instance.finishedTime = _finishedTime;
    }

    public float getFinishedTime()
    {
        return instance.finishedTime;
    }



}
