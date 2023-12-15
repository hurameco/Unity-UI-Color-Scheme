using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI.UIColor.Palette;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace UI.UIColor.Theme
{
    [ExecuteInEditMode]
    public sealed class ColorTheme : ScriptableObject, IObservable<ColorPalette>
    {
        [SerializeField]
        [Hide]
        private string _currentTheme;

        [Title("Themes")]
        [SerializeField]
        private SerializedDictionary<string, ColorPalette> _themes = new();

        private static ColorTheme _instance;
        private readonly HashSet<IObserver<ColorPalette>> _observers = new();

        public static ColorTheme Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Resources.Load<ColorTheme>("UI.ColorPalette/Themes");

                return _instance;
            }
        }

        public ColorPalette CurrentTheme
        {
            get
            {
                return _themes[_currentTheme];
            }
        }

        public List<string> themeKeys
        {
            get
            {
                return _themes.Keys.ToList();
            }
        }

        public List<ColorPalette> themeValues
        {
            get
            {
                return _themes.Values.ToList();
            }
        }

        public IDisposable Subscribe(IObserver<ColorPalette> observer)
        {
            _observers.Add(observer);
            // TODO: observer.OnNext();
            return new Unsubscriber(_observers, observer);
        }

        public void NotifyObservers(ColorPalette ColorPalette)
        { 
            foreach(var observer in _observers)
            {
                observer.OnNext(ColorPalette);
            }
        }

        public void Reset()
        {
            foreach(var ColorPalette in Resources.FindObjectsOfTypeAll<ColorPalette>())
            {
                _themes.Add(ColorPalette.name, ColorPalette);
            }
        }

        public void OnDestroy()
        {
            foreach(var observer in _observers)
            {
                observer.OnCompleted();
            }

            _observers.Clear();
        }



        public sealed class Unsubscriber : IDisposable
        {
            private readonly ISet<IObserver<ColorPalette>> _observers;
            private readonly IObserver<ColorPalette> _observer;

            internal Unsubscriber(ISet<IObserver<ColorPalette>> observers, IObserver<ColorPalette> observer) => (_observers, _observer) = (observers, observer);

            public void Dispose()
            {
                _observers.Remove(_observer);
            }
        }
    }

}