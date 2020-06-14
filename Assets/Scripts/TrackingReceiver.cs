using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.Linq;
using System.Diagnostics;

public class TrackingReceiver : MonoBehaviour
{
    //GameObjects to be controlled with Posenet
    public GameObject leftWrist;
    //private  GameObject rightWrist;
    //public GameObject wristR;

    //OSC Variables
    private OSCReceiver _receiver;
    private const string _oscAddress = "/pose/0";

    //Dictionary to store pose data
    public Dictionary<string, Vector3> pose = new Dictionary<string, Vector3>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Set up OSC receiver
        StartOSCReceiver();

        //Initialize pose
        StartPose();
    }

    void StartOSCReceiver() {
        // Creating a receiver.
        _receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        _receiver.LocalPort = 9876;

        // Bind "MessageReceived" method to special address.
        _receiver.Bind(_oscAddress, MessageReceived);
    }

    void StartPose() {
        //pose.Add("rightWrist", Vector3.zero);
        pose.Add("rightWrist", transform.position);
        //pose.Add("rightWrist", Vector3.zero);
    }
    

    // Update is called once per frame
    void Update()
    {
        leftWrist.transform.position = pose["rightWrist"];
        //rightWrist.transform.position = pose["leftWrist"];
        //wristR.transform.position = pose["rightWrist"];

    }

    protected void MessageReceived(OSCMessage message)
    {
        List<OSCValue> list = message.Values;
        //UnityEngine.Debug.Log(list.Count);

        for(int i=0;i<list.Count; i+=3)
        {
            string key = "";
            Vector3 position = transform.position;

            OSCValue val0 = list.ElementAt(i);
            if (val0.Type == OSCValueType.String) key = val0.StringValue;
            OSCValue val1 = list.ElementAt(i+1);
            if (val1.Type == OSCValueType.Float) position.x = val1.FloatValue-250;
            UnityEngine.Debug.Log("test: " + val1.FloatValue);
            OSCValue val2 = list.ElementAt(i+2);
            if (pose.ContainsKey(key)) {
                pose[key] = position; 
            }
        }

    }
}
