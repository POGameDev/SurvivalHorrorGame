using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strength : MonoBehaviour
{
    public Text StrengthText;
    public static int Str = 100;
    public static int JumpLoseStr = 20;
    public static bool HaveStr = true;
    private float RegenerationDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Regeneration", RegenerationDelay);
    }

    // Update is called once per frame
    void Update()
    {
        StrengthText.text = $"STR: {Str}";
        if(Str <= JumpLoseStr && HaveStr)
        {
            HaveStr = false;
        }
        else if (Str > JumpLoseStr && !HaveStr)
        {
            HaveStr = true;
        }
    }
    public void Regeneration()
    {
        if(Str < 100)
            Str += 1;
        Invoke("Regeneration", RegenerationDelay);
    }
}
