using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tutorialText;
    private bool OnOff = false;

    public void TutorialOnOff()
    {
        OnOff = !OnOff;
        TutorialDescribe();
    }

    void TutorialDescribe()
    {
        if (OnOff)
        {
            tutorialText.text = $"A/D  :  Move\n" +
                                $"SPACE  :  Jump\n" +
                                $"F  :  Attack\n";
        }
        else
        {
            tutorialText.text = "";
        }
    }
}
