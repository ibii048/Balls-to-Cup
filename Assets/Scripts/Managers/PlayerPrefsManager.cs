using UnityEngine;

namespace Managers
{
    public static class PlayerPrefsManager
    {
        public static void SetLevel(int value)
        {
            PlayerPrefs.SetFloat(Const.LEVEL_NUMBER, value);
            PlayerPrefs.Save();

        }

        public static int GetLevel()
        {
            return PlayerPrefs.GetInt(Const.LEVEL_NUMBER,1);
        }
    }
}
