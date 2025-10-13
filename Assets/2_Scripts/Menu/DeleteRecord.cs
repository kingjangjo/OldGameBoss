using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRecord : MonoBehaviour
{
    public void DeleteRecordClicked()
    {
        PlayerPrefs.DeleteAll();
    }
}
