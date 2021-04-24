using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipScenes : MonoBehaviour
{
    private PlayableDirector _playableDirector;
    private double clipduration;
    
    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
        clipduration = _playableDirector.duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            skip();
        }
    }

    public void skip()
    {
        _playableDirector.time = clipduration;
    }
}
