using System;
using TMPro;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class ScoreKeeper : MonoBehaviour
    {
        public TextMeshPro player1Score;
        public TextMeshPro player2Score;
        public bool scoreLimit;
        public int scoreLimitValue = 5;
        private int player1ScoreValue;
        private int player2ScoreValue;
        public UltEvent onPlayer1Score;
        public UltEvent onPlayer2Score;
        public UltEvent onScoreLimitReached;
        public UltEvent onPlayer1Win;
        public UltEvent onPlayer2Win;
        
        public void Player1Scored()
        {
            player1ScoreValue++;
            player1Score.text = player1ScoreValue.ToString();
            onPlayer1Score.Invoke();
            if (scoreLimit)
            {
                if (player1ScoreValue == scoreLimitValue)
                {
                    onScoreLimitReached.Invoke();
                    onPlayer1Win.Invoke();
                    Reset();
                }
            }
        }
        
        public void Player2Scored()
        {
            player2ScoreValue++;
            player2Score.text = player2ScoreValue.ToString();
            onPlayer2Score.Invoke();
            if (scoreLimit)
            {
                if (player2ScoreValue == scoreLimitValue)
                {
                    onScoreLimitReached.Invoke();
                    onPlayer2Win.Invoke();
                    Reset();
                }
            }
        }

        public void Reset()
        {
            player1ScoreValue = 0;
            player2ScoreValue = 0;
            player1Score.text = player1ScoreValue.ToString();
            player2Score.text = player2ScoreValue.ToString();
        }
        
#if !UNITY_EDITOR
        public ScoreKeeper(IntPtr ptr) : base(ptr) { }
#endif
    }
}