using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private Player player;
    private PlayerUI ui;
    private PlayerConfig playerConfig;
    private PlayerSoundConfig soundConfig;
    private List<Vector3> checkPoints = new List<Vector3>();
    private SaveGame saveGame;
    private PersistentMusic mainMenuMusic = null;
    private FadeSceneTransition fade = null;
    public void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public static GameManager Instance { get => instance; set => instance = value; }
    public static Player Player { get => Instance.player; set => Instance.player = value; }
    public static PlayerConfig PlayerConfig { get => Instance.playerConfig; set => Instance.playerConfig = value; }
    public static PlayerUI Ui { get => Instance.ui; set => Instance.ui = value; }
    public static List<Vector3> CheckPoints { get => Instance.checkPoints; set => Instance.checkPoints = value; }
    public static SaveGame SaveGame { get => Instance.saveGame; set => Instance.saveGame = value; }
    public static PersistentMusic MainMenuMusic { get => Instance.mainMenuMusic; set => Instance.mainMenuMusic = value; }
    public static PlayerSoundConfig SoundConfig { get => Instance.soundConfig; set => Instance.soundConfig = value; }
    public static FadeSceneTransition Fade { get => Instance.fade; set => Instance.fade = value; }
    public static void LoadLevel(string levelName)
    {
        SaveGame.AddLevel(levelName);
        SceneManager.LoadScene(SceneUtility.GetBuildIndexByScenePath(levelName), LoadSceneMode.Single);
    }
    public static IEnumerator LoadAsyncLevel(string levelName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SaveGame.AddLevel(levelName);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath(levelName), LoadSceneMode.Single);

        while (!asyncLoad.isDone)
            yield return null;
    }
    public static void SaveProgress()
    {
        if (SaveGame == null)
            return;

        SaveGame.SaveProgress();
    }
    public static void LoadSaveGame(string filename)
    {
        if (!Directory.Exists(SaveGame.SAVE_PATH))
            return;
        if (!File.Exists(SaveGame.SAVE_PATH + filename))
            return;

        SaveGame = JsonConvert.DeserializeObject<SaveGame>(File.ReadAllText(SaveGame.SAVE_PATH + filename));
    }
    public static void PlaySound(AudioClip clip, AudioMixerGroup mixer)
    {
        GameObject sound = new GameObject("sound", typeof(AudioSource), typeof(Fx));
        sound.GetComponent<AudioSource>().outputAudioMixerGroup = mixer;
        sound.GetComponent<AudioSource>().PlayOneShot(clip);
        sound.GetComponent<Fx>().OnFinish();
    }
}