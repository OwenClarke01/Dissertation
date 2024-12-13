using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    // all animations
    private string[] names = { "idle", "applause", "applause2", "celebration", "celebration2", "celebration3" };

    void Start()
    {
        // identifying animation controllers
        // all audience members are under parent gameobject
        Animation[] AudienceMembers = gameObject.GetComponentsInChildren<Animation>();
        foreach (Animation anim in AudienceMembers)
        {
            string thisAnimation = names[Random.Range(0, 5)];

            anim.wrapMode = WrapMode.Loop;
            anim.GetComponent<Animation>().CrossFade(thisAnimation);
            anim[thisAnimation].time = Random.Range(0f, 3f);
        }
    }
}
