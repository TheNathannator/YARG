﻿using TMPro;
using UnityEngine;
using YARG.Replays;

namespace YARG.Menu.Replays
{
    public class ReplayView : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private GameObject _normalBackground;
        [SerializeField]
        private GameObject _selectedBackground;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _songName;
        [SerializeField]
        private TextMeshProUGUI _artistName;
        [SerializeField]
        private TextMeshProUGUI _score;

        private ReplayEntry _replay;

        public void ShowAsReplay(bool selected, ReplayEntry replay)
        {
            _canvasGroup.alpha = 1f;

            _replay = replay;

            // TODO: Make speed work
            _songName.text = _replay.SongName;
            _artistName.text = _replay.ArtistName;
            _score.text = _replay.BandScore.ToString("N0");

            // TODO
            // _percent.text = $"{Mathf.FloorToInt(_replay.percent)}%";
            // ... = _replay.Stars;

            // Set correct background
            _normalBackground.SetActive(!selected);
            _selectedBackground.SetActive(selected);

            if (selected)
            {
                _songName.text = $"<color=white><font-weight=700>{_songName.text}</font-weight></color>";
            }

            // Set the opacity for the artist text
            var c = _artistName.color;
            c.a = selected ? 1f : 0.5f;
            _artistName.color = c;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0f;

            _replay = null;
        }
    }
}