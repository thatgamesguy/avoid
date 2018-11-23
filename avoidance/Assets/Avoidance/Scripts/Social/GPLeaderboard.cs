using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

namespace Avoidance
{
    /// <summary>
    /// Responsible for posting a score to the Google Play leaderboard and showing the leaderboard UI.
    /// </summary>
    public class GPLeaderboard : Singleton<GPLeaderboard>
    {
        /// <summary>
        /// Posts the score if on Android platform.
        /// </summary>
        /// <param name="score">Score.</param>
        public void PostScore(int score)
        {
#if UNITY_ANDROID
            Social.ReportScore(score, GP_Constants.leaderboard_avoidance, (bool success) =>
            {
                Debug.Log("Leaderboard score stored: " + success);
            });
#endif
        }

        /// <summary>
        /// Shows the Android leaderboard UI.
        /// </summary>
        public void ShowUI()
        {
#if UNITY_ANDROID
            Debug.Log("Attempting to open leaderboard: " + GP_Constants.leaderboard_avoidance);
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GP_Constants.leaderboard_avoidance);
#endif
        }
    }
}