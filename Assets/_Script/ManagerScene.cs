using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void ChangeScene(string NamaScene)
    {
        SceneManager.LoadScene(NamaScene);
        Debug.Log("berhasil pindah scene");
    }

    public void onExitClicked()
    {
        Application.Quit();
        Debug.Log("Keluar aplikasi");
    }

    private void onAndroidBackButtonClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Homescreen", LoadSceneMode.Single);
        }
    }
}