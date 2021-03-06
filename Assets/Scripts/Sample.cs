﻿using UnityEngine;
using UnityFinger;

public class Sample : MonoBehaviour
{
    ScreenInputBase input;
    FingerObserverSupervisor supervisor;
    FingerEventManager manager;

    void Start()
    {
        input = new EditorInput();

        supervisor = new FingerObserverSupervisor(input);
        manager = new FingerEventManager(supervisor, new DefaultFingerObserverConfig());

        manager.AddOnScreenListener(p => Debug.Log(p));

        manager.AddOnDragStartListener(dragInfo => {
            Debug.LogFormat("DragStart: {0}", dragInfo.Current);
        });

        manager.AddOnDragListener(dragInfo => {
            Debug.LogFormat("Drag: {0}", dragInfo.Current);
        });

        manager.AddOnDragEndListener(dragInfo => {
            Debug.LogFormat("DragEnd: {0}", dragInfo.Current);
        });

        manager.AddOnLongTapListener(p => Debug.Log(p));
    }

    void Update()
    {
        input.Update();
        supervisor.Update();
    }
}
