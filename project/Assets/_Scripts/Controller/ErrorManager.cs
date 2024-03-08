using UnityEngine;

namespace Game.Controller
{
    public static class ErrorManager
    {
        public static void LogError(this GameObject go, MonoBehaviour script, string message)
        {
            Debug.LogError($"Chyba! {go.name} ve skriptu {script.name}. - Zpráva: {message}");
        }
    }
}
