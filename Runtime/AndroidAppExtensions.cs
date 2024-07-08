// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class AndroidAppExtensions
    {
        private const string COM_UNITY_3D_PLAYER_UNITY_PLAYER = "com.unity3d.player.UnityPlayer";
        private const string JAVA_OBJECT_CURRENT_ACTIVITY = "currentActivity";
        private const string ACTION = "moveTaskToBack";


        /// <summary>
        /// Minimizes the Android application by moving the task to the back.
        /// </summary>
        public static void Minimize()
        {
#if UNITY_EDITOR
            Debug.LogWarning("App Minimized!");
#endif

            if (Application.platform != RuntimePlatform.Android)
                return;

            var player = new AndroidJavaClass(COM_UNITY_3D_PLAYER_UNITY_PLAYER);
            var activity = player.GetStatic<AndroidJavaObject>(JAVA_OBJECT_CURRENT_ACTIVITY);
            activity.Call<bool>(ACTION, true);
        }
    }
}