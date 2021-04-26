using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    public static PostProcessManager instance;

    public Volume volume;

    public VolumeProfile[] postProcessProfiles;

    //Vignette vignette;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        //vignette = (Vignette)volume.profile.components[0];
    }

    public void ChangeProfile(int _profileIndex)
    {
        volume.profile = postProcessProfiles[_profileIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
