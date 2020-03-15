using UnityEngine;
using RPGM.Core;
using RPGM.Gameplay;
using System.IO;

namespace RPGM.Gameplay
{
    /// <summary>
    /// The global game controller. It contains the game model and executes the schedule.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        //This model is public and can be modified in the inspector.
        //The reference is shared where needed, and Unity will deserialize
        //over the shared reference, rather than create a new instance.
        //To preserve this behaviour, this script must be deserialized last.
        public GameModel model;

        protected virtual void OnEnable()
        {
            Schedule.SetModel<GameModel>(model);
        }

        protected virtual void Update()
        {
            Schedule.Tick();
        }

        private void Start()
        {
            if(PlayerPrefs.GetInt("loadLevel") != 0)
            {
                LoadGame();
            }
        }

        public void SaveGame()
        {
            string json = model.SaveGame();
            Debug.Log(json);
            FileStream fileStream = new FileStream(
                                            Path.Combine(
                                                Application.persistentDataPath,
                                                "savedGame.json"),
                                            FileMode.Create);
            using(StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
            Debug.Log("Game is saved");
        }

        public void LoadGame()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "savedGame.json");
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    PlayerSave save = JsonUtility.FromJson<PlayerSave>(json);
                    model.LoadGame(save);
                }
            }
            else
            {
                Debug.LogWarning("No save file found");
            }
        }
    }
}