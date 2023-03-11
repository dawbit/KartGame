using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RaceLauncher : MonoBehaviour
{
public InputField playerName;
void Start()
{
if (PlayerPrefs.HasKey("PlayerName")) playerName.text =
PlayerPrefs.GetString("PlayerName");
}
public void SetName(string name)
{
PlayerPrefs.SetString("PlayerName", name);
}
public void StartTrial()
{
SceneManager.LoadScene(0);
}
}