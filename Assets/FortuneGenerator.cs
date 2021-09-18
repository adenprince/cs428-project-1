using TMPro;
using UnityEngine;

public class FortuneGenerator : MonoBehaviour
{
    public TextMeshPro fortuneText;
    public Transform cameraTransform;
    
    public enum SayingType
    {
        Classic,
        Modern
    }

    public SayingType sayingType;

    string[] classicSayings = { "It is Certain", "It is decidedly so", "Without a doubt", "Yes definitely", "You may rely on it",
        "As I see it, yes.", "Most likely", "Outlook good", "Yes", "Signs point to yes", "Reply hazy, try again", "Ask again later",
        "Better not tell you now", "Cannot predict now", "Concentrate and ask again", "Don't count on it", "My reply is no",
        "My sources say no", "Outlook not so good", "Very doubtful" };
    string[] modernSayings = { "B)", ":D", ";)", ":)", ":/", "(._.)", ".-.", ":|", "D:", "＞_＜", ":(", "/_\\" };

    enum OrientationState
    {
        None,
        TurnedUp,
        TurnedDownAfterTurnedUp
    }

    OrientationState orientationState = OrientationState.None;

    bool beingTracked;

    void Update()
    {
        if (beingTracked)
        {
            float angleFromUp = Vector3.Angle(cameraTransform.up, transform.up);

            // Turned up
            if (angleFromUp <= 30f && orientationState != OrientationState.TurnedUp)
            {
                if (orientationState == OrientationState.TurnedDownAfterTurnedUp)
                {
                    fortuneText.text = GenerateFortune();
                }

                orientationState = OrientationState.TurnedUp;
            }

            // Turned down
            if (angleFromUp >= 150f && orientationState == OrientationState.TurnedUp)
            {
                orientationState = OrientationState.TurnedDownAfterTurnedUp;
            }
        }
    }

    string GenerateFortune()
    {
        if (sayingType == SayingType.Classic)
        {
            int fortuneIndex = Random.Range(0, classicSayings.Length);
            return classicSayings[fortuneIndex];
        }
        else
        {
            int fortuneIndex = Random.Range(0, modernSayings.Length);
            return modernSayings[fortuneIndex];
        }
    }

    public void ResetOrientationState()
    {
        orientationState = OrientationState.None;
    }

    public void SetBeingTracked(bool newBeingTracked)
    {
        beingTracked = newBeingTracked;
    }
}
