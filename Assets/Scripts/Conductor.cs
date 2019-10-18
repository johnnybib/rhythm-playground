using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Conductor : MonoBehaviour
{
    public delegate void OnTriggerBeatDelegate(bool beatOn);
    public OnTriggerBeatDelegate triggerBeatHandler;


    [SerializeField]
    private Material defaultMat;
    
    [SerializeField]
    private Material beatMat;

    private MeshRenderer mesh;

    private double previousFrameTime = 0;
    private double lastReportedPlayheadPosition = 0;
    private double songTime = 0;
    private double songPositionInBeats;
    private double secPerBeat;
    
    
    private float beatThresh = 0.03f;
    private bool beatTriggered = false; //To not trigger a beat twice in one beat
    private bool beatOn = false; //To toggle between materials

    [SerializeField]
    private double songBpm;    
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        triggerBeatHandler += new OnTriggerBeatDelegate(triggerBeat);
        secPerBeat = 60f / songBpm;
    }

    // Update is called once per frame
    void Update()
    {
        songTime += AudioSettings.dspTime - previousFrameTime;
        previousFrameTime = AudioSettings.dspTime;
        songPositionInBeats = songTime / secPerBeat;
        if((Math.Abs(songPositionInBeats - Math.Round(songPositionInBeats)) < beatThresh) && !beatTriggered)
        {
            triggerBeatHandler(beatOn);           
            beatTriggered = true;
        }
        else if((Math.Abs(songPositionInBeats - Math.Round(songPositionInBeats)) > beatThresh) && beatTriggered)
        {
            beatTriggered = false;
        }
    }

    private void triggerBeat(bool incomingBeat)
    {
        if(!incomingBeat)
        {
            mesh.material = beatMat;
            beatOn = true;
        }
        else
        {
            mesh.material = defaultMat;
            beatOn = false;
        }
    }
}
