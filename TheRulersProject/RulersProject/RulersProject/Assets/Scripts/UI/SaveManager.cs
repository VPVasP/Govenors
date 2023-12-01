using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public TextMeshProUGUI UpgradePoints;
    public Transform Player;
//    public MovementStateManager ourMovement;
    public void SaveGame()
    {
        PlayerPrefs.SetString("UpgradePoints", UpgradePoints.text);
        //PlayerPrefs.SetFloat("WalkSpeed",ourMovement.walkSpeed);
        //PlayerPrefs.SetFloat("WalkBackSpeed", ourMovement.walkBackSpeed);
        //PlayerPrefs.SetFloat("RunSpeed", ourMovement.runSpeed);
        PlayerPrefs.SetFloat("PlayerPosX", Player.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", Player.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", Player.position.z);
        Debug.Log("We saved");
    }
    public void LoadSaveData()
    {
        UpgradePoints.text = PlayerPrefs.GetString("UpgradePoints");
        //PlayerPrefs.GetString("UpgradePoints", UpgradePoints.text);
        //PlayerPrefs.GetFloat("WalkSpeed", ourMovement.walkSpeed);
        //PlayerPrefs.GetFloat("WalkBackSpeed", ourMovement.walkBackSpeed);
        //PlayerPrefs.GetFloat("RunSpeed", ourMovement.runSpeed);
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY", PlayerPrefs.GetFloat("PlayerPosZ")));
        Debug.Log("We loaded");
    }
}
