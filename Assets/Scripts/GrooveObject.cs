using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrooveObject : MonoBehaviour
{
    
    [SerializeField]
    private Material defaultMat;
    
    [SerializeField]
    private Material beatMat;

    private MeshRenderer mesh;

    [SerializeField]
    private float defaultBpm;

    [SerializeField]
    private GameObject conductor;
    private Conductor conductorScript;
    
    private bool grooving = false;
    private bool beatOn = false;
    private float secPerBeat;

    private float currentTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        conductorScript = conductor.GetComponent<Conductor>();
        secPerBeat = 60f / defaultBpm;
    }

    // Update is called once per frame
    void Update()
    {
        if(!grooving)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= secPerBeat)
            {
                triggerBeat(beatOn);
                currentTime = 0f;
            }
        }
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(!grooving)
                {
                    conductorScript.triggerBeatHandler += new Conductor.OnTriggerBeatDelegate(triggerBeat);
                }
                else
                {
                    conductorScript.triggerBeatHandler -= new Conductor.OnTriggerBeatDelegate(triggerBeat);
                }
                grooving = !grooving;
            }
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
