using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace UI.UIColor.Palette
{
    [CreateAssetMenu(fileName = "Default UI Palette", menuName = "Color Scheme/Create Color Palette", order = 1)]
    [ExecuteInEditMode]
    public class ColorPalette : ScriptableObject
    {
        [Tooltip("TMP Font Asset to be used on all text components")]
        [NewLabel("Font Asset")]
        [NotNull]
        [SerializeField] TMP_FontAsset _fontAsset;

        [Tooltip("High-emphasis fills, texts, and icons against surface")]
        [NewLabel("Primary")]
        [SerializeField] private Color _primary;

        [Tooltip("Text and icons against primary")]
        [NewLabel("On Primary")]
        [SerializeField] private Color _onPrimary;

        [Tooltip("Standout fill color against surface, for key components")]
        [NewLabel("Primary Container")]
        [SerializeField] private Color _primaryContainer;

        [Tooltip("Text and icons against primary container")]
        [NewLabel("On Primary Container")]
        [SerializeField] private Color _onPrimaryContainer;

        [Tooltip("Less prominent fills, text, and icons against surface")]
        [NewLabel("Secondary")]
        [SerializeField] private Color _secondary;

        [Tooltip("Text and icons against secondary")]
        [NewLabel("On Secondary")]
        [SerializeField] private Color _onSecondary;

        [Tooltip("Less prominent fill color against surface, for recessive components like tonal buttons")]
        [NewLabel("Secondary Container")]
        [SerializeField] private Color _secondaryContainer;

        [Tooltip("Text and icons against secondary container")]
        [NewLabel("On Secondary Container")]
        [SerializeField] private Color _onSecondaryContainer;

        [Tooltip("Complementary fills, text, and icons against surface")]
        [NewLabel("Tertiary")]
        [SerializeField] private Color _tertiary;

        [Tooltip("Text and icons against tertiary")]
        [NewLabel("On Tertiary")]
        [SerializeField] private Color _onTertiary;

        [Tooltip("Complementary container color against surface, for components like input fields")]
        [NewLabel("Tertiary Container")]
        [SerializeField] private Color _tertiaryContainer;

        [Tooltip("Text and icons against tertiary container")]
        [NewLabel("On Tertiary Container")]
        [SerializeField] private Color _onTertiaryContainer;

        [Tooltip("Attention-grabbing color against surface for fills, icons, and text, indicating urgency")]
        [NewLabel("Error")]
        [SerializeField] private Color _error;

        [Tooltip("Text and icons against error")]
        [NewLabel("On Error")]
        [SerializeField] private Color _onError;

        [Tooltip("Attention-grabbing fill color against surface")]
        [NewLabel("Error Container")]
        [SerializeField] private Color _errorContainer;

        [Tooltip("Text and icons against error container")]
        [NewLabel("On Error Container")]
        [SerializeField] private Color _onErrorContainer;

        [Tooltip("Primary color used against surface. This color maintain the same tone in light and dark themes, as opposed to regular container colors, which change in tone between these themes")]
        [NewLabel("Primary Fixed")]
        [SerializeField] private Color _primaryFixed;

        [Tooltip("Primary fixed dim role provide a stronger, more emphasized tone relative to the equivalent fixed color")]
        [NewLabel("Primary Fixed Dim")]
        [SerializeField] private Color _primaryFixedDim;

        [Tooltip("Text and icons against Primary Fixed")]
        [NewLabel("On Primary Fixed")]
        [SerializeField] private Color _onPrimaryFixed;

        [Tooltip("Alternative color for text and icons against Primary Fixed")]
        [NewLabel("On Primary Fixed Variant")]
        [SerializeField] private Color _onPrimaryFixedVariant;

        [Tooltip("Secondary color used against surface. This color maintain the same tone in light and dark themes, as opposed to regular container colors, which change in tone between these themes")]
        [NewLabel("Secondary Fixed")]
        [SerializeField] private Color _secondaryFixed;

        [Tooltip("Secondary fixed dim role provide a stronger, more emphasized tone relative to the equivalent fixed color")]
        [NewLabel("Secondary Fixed Dim")]
        [SerializeField] private Color _secondaryFixedDim;

        [Tooltip("Text and icons against Secondary Fixed")]
        [NewLabel("On Secondary Fixed")]
        [SerializeField] private Color _onSecondaryFixed;

        [Tooltip("Alternative color for text and icons against Secondary Fixed")]
        [NewLabel("On Secondary Fixed Variant")]
        [SerializeField] private Color _onSecondaryFixedVariant;

        [Tooltip("Tertiary color used against surface. This color maintain the same tone in light and dark themes, as opposed to regular container colors, which change in tone between these themes")]
        [NewLabel("Tertiary Fixed")]
        [SerializeField] private Color _tertiaryFixed;

        [Tooltip("Tertiary fixed dim role provide a stronger, more emphasized tone relative to the equivalent fixed color")]
        [NewLabel("Tertiary Fixed Dim")]
        [SerializeField] private Color _tertiaryFixedDim;

        [Tooltip("Text and icons against Tertiary Fixed")]
        [NewLabel("On Tertiary Fixed")]
        [SerializeField] private Color _onTertiaryFixed;

        [Tooltip("Alternative color for text and icons against Secondary Fixed")]
        [NewLabel("On Tertiary Fixed Variant")]
        [SerializeField] private Color _onTertiaryFixedVariant;

        [Tooltip("A role used for backgrounds and large, low-emphasis areas of the screen")]
        [NewLabel("Surface")]
        [SerializeField] private Color _surface;

        [Tooltip("Alternative role used for backgrounds and large, low-emphasis areas of the screen")]
        [NewLabel("Surface Variant")]
        [SerializeField] private Color _surfaceVariant;

        [Tooltip("Dimmest surface color in light and dark themes")]
        [NewLabel("Surface Dim")]
        [SerializeField] private Color _surfaceDim;

        [Tooltip("Brightest surface color in light and dark themes")]
        [NewLabel("Surface Bright")]
        [SerializeField] private Color _surfaceBright;

        [Tooltip("Default container color")]
        [NewLabel("Surface Container")]
        [SerializeField] private Color _surfaceContainer;

        [Tooltip("Low-emphasis container color")]
        [NewLabel("Surface Content Low")]
        [SerializeField] private Color _surfaceContainerLow;

        [Tooltip("Lowest-emphasis container color")]
        [NewLabel("Surface Container Lowest")]
        [SerializeField] private Color _surfaceContainerLowest;

        [Tooltip("High-emphasis container color")]
        [NewLabel("Surface Container High")]
        [SerializeField] private Color _surfaceContainerHigh;

        [Tooltip("Highest-emphasis container color")]
        [NewLabel("Surface Container Highest")]
        [SerializeField] private Color _surfaceContainerHighest;

        [Tooltip("Text and icons against any surface color")]
        [NewLabel("On Surface")]
        [SerializeField] private Color _onSurface;

        [Tooltip(" Lower-emphasis color for text and icons against any surface color")]
        [NewLabel("On Surface Variant")]
        [SerializeField] private Color _onSurfaceVariant;

        [Tooltip("Important boundaries, such as a text field outline")]
        [NewLabel("Outline")]
        [SerializeField] private Color _outline;

        [Tooltip("Decorative elements, such as dividers")]
        [NewLabel("Outline Variant")]
        [SerializeField] private Color _outlineVariant;

        [Tooltip("Background fills for elements which contrast against surface")]
        [NewLabel("Inverse Surface")]
        [SerializeField] private Color _inverseSurface;

        [Tooltip("Text and icons against inverse surface")]
        [NewLabel("Inverse On Surface")]
        [SerializeField] private Color _inverseOnSurface;

        [Tooltip("Actionable elements, such as text buttons, against inverse surface")]
        [NewLabel("Inverse Primary")]
        [SerializeField] private Color _inversePrimary;

        [Tooltip("Scrim is a temporary treatment that can be applied to Material surfaces for the purpose of making content on a surface less prominent. It helps direct user attention to other parts of the screen, away from the surface receiving a scrim.")]
        [NewLabel("Scrim")]
        [SerializeField] private Color _scrim;

        [Tooltip("Shadow color cast by elements")]
        [NewLabel("Shadow")]
        [SerializeField] private Color _shadow;


        List<string> _availableProperties = new();


        public TMP_FontAsset FontAsset { get => _fontAsset; private set => _fontAsset = value; }
        public Color Primary { get => _primary; private set => _primary = value; }
        public Color OnPrimary { get => _onPrimary; private set => _onPrimary = value; }
        public Color PrimaryContainer { get => _primaryContainer; private set => _primaryContainer = value; }
        public Color OnPrimaryContainer { get => _onPrimaryContainer; private set => _onPrimaryContainer = value; }
        public Color Secondary { get => _secondary; private set => _secondary = value; }
        public Color OnSecondary { get => _onSecondary; private set => _onSecondary = value; }
        public Color SecondaryContainer { get => _secondaryContainer; private set => _secondaryContainer = value; }
        public Color OnSecondaryContainer { get => _onSecondaryContainer; private set => _onSecondaryContainer = value; }
        public Color Tertiary { get => _tertiary; private set => _tertiary = value; }
        public Color OnTertiary { get => _onTertiary; private set => _onTertiary = value; }
        public Color TertiaryContainer { get => _tertiaryContainer; private set => _tertiaryContainer = value; }
        public Color OnTertiaryContainer { get => _onTertiaryContainer; private set => _onTertiaryContainer = value; }
        public Color Error { get => _error; private set => _error = value; }
        public Color OnError { get => _onError; private set => _onError = value; }
        public Color ErrorContainer { get => _errorContainer; private set => _errorContainer = value; }
        public Color OnErrorContainer { get => _onErrorContainer; private set => _onErrorContainer = value; }
        public Color PrimaryFixed { get => _primaryFixed; private set => _primaryFixed = value; }
        public Color PrimaryFixedDim { get => _primaryFixedDim; private set => _primaryFixedDim = value; }
        public Color OnPrimaryFixed { get => _onPrimaryFixed; private set => _onPrimaryFixed = value; }
        public Color OnPrimaryFixedVariant { get => _onPrimaryFixedVariant; private set => _onPrimaryFixedVariant = value; }
        public Color SecondaryFixed { get => _secondaryFixed; private set => _secondaryFixed = value; }
        public Color SecondaryFixedDim { get => _secondaryFixedDim; private set => _secondaryFixedDim = value; }
        public Color OnSecondaryFixed { get => _onSecondaryFixed; private set => _onSecondaryFixed = value; }
        public Color OnSecondaryFixedVariant { get => _onSecondaryFixedVariant; private set => _onSecondaryFixedVariant = value; }
        public Color TertiaryFixed { get => _tertiaryFixed; private set => _tertiaryFixed = value; }
        public Color TertiaryFixedDim { get => _tertiaryFixedDim; private set => _tertiaryFixedDim = value; }
        public Color OnTertiaryFixed { get => _onTertiaryFixed; private set => _onTertiaryFixed = value; }
        public Color OnTertiaryFixedVariant { get => _onTertiaryFixedVariant; private set => _onTertiaryFixedVariant = value; }
        public Color Surface { get => _surface; private set => _surface = value; }
        public Color SurfaceVariant { get => _surfaceVariant; private set => _surfaceVariant = value; }
        public Color SurfaceDim { get => _surfaceDim; private set => _surfaceDim = value; }
        public Color SurfaceBright { get => _surfaceBright; private set => _surfaceBright = value; }
        public Color SurfaceContainer { get => _surfaceContainer; private set => _surfaceContainer = value; }
        public Color SurfaceContainerLow { get => _surfaceContainerLow; private set => _surfaceContainerLow = value; }
        public Color SurfaceContainerLowest { get => _surfaceContainerLowest; private set => _surfaceContainerLowest = value; }
        public Color SurfaceContainerHigh { get => _surfaceContainerHigh; private set => _surfaceContainerHigh = value; }
        public Color SurfaceContainerHighest { get => _surfaceContainerHighest; private set => _surfaceContainerHighest = value; }
        public Color OnSurface { get => _onSurface; private set => _onSurface = value; }
        public Color OnSurfaceVariant { get => _onSurfaceVariant; private set => _onSurfaceVariant = value; }
        public Color Outline { get => _outline; private set => _outline = value; }
        public Color OutlineVariant { get => _outlineVariant; private set => _outlineVariant = value; }
        public Color InverseSurface { get => _inverseSurface; private set => _inverseSurface = value; }
        public Color InverseOnSurface { get => _inverseOnSurface; private set => _inverseOnSurface = value; }
        public Color InversePrimary { get => _inversePrimary; private set => _inversePrimary = value; }
        public Color Scrim { get => _scrim; private set => _scrim = value; }
        public Color Shadow { get => _shadow; private set => _shadow = value; }

        private void Reset()
        {
            Primary = new Color(0, 0, 0, 1);
            OnPrimary = new Color(0, 0, 0, 1);
            PrimaryContainer = new Color(0, 0, 0, 1);
            OnPrimaryContainer = new Color(0, 0, 0, 1);
            Secondary = new Color(0, 0, 0, 1);
            OnSecondary = new Color(0, 0, 0, 1);
            SecondaryContainer = new Color(0, 0, 0, 1);
            OnSecondaryContainer = new Color(0, 0, 0, 1);
            Tertiary = new Color(0, 0, 0, 1);
            OnTertiary = new Color(0, 0, 0, 1);
            TertiaryContainer = new Color(0, 0, 0, 1);
            OnTertiaryContainer = new Color(0, 0, 0, 1);
            Error = new Color(0, 0, 0, 1);
            OnError = new Color(0, 0, 0, 1);
            ErrorContainer = new Color(0, 0, 0, 1);
            OnErrorContainer = new Color(0, 0, 0, 1);
            PrimaryFixed = new Color(0, 0, 0, 1);
            PrimaryFixedDim = new Color(0, 0, 0, 1);
            OnPrimaryFixed = new Color(0, 0, 0, 1);
            OnPrimaryFixedVariant = new Color(0, 0, 0, 1);
            SecondaryFixed = new Color(0, 0, 0, 1);
            SecondaryFixedDim = new Color(0, 0, 0, 1);
            OnSecondaryFixed = new Color(0, 0, 0, 1);
            OnSecondaryFixedVariant = new Color(0, 0, 0, 1);
            TertiaryFixed = new Color(0, 0, 0, 1);
            TertiaryFixedDim = new Color(0, 0, 0, 1);
            OnTertiaryFixed = new Color(0, 0, 0, 1);
            OnTertiaryFixedVariant = new Color(0, 0, 0, 1);
            Surface = new Color(0, 0, 0, 1);
            SurfaceVariant = new Color(0, 0, 0, 1);
            SurfaceDim = new Color(0, 0, 0, 1);
            SurfaceBright = new Color(0, 0, 0, 1);
            SurfaceContainer = new Color(0, 0, 0, 1);
            SurfaceContainerLow = new Color(0, 0, 0, 1);
            SurfaceContainerLowest = new Color(0, 0, 0, 1);
            SurfaceContainerHigh = new Color(0, 0, 0, 1);
            SurfaceContainerHighest = new Color(0, 0, 0, 1);
            OnSurface = new Color(0, 0, 0, 1);
            OnSurfaceVariant = new Color(0, 0, 0, 1);
            Outline = new Color(0, 0, 0, 1);
            OutlineVariant = new Color(0, 0, 0, 1);
            InverseSurface = new Color(0, 0, 0, 1);
            InverseOnSurface = new Color(0, 0, 0, 1);
            InversePrimary = new Color(0, 0, 0, 1);
            Scrim = new Color(0, 0, 0, 1);
            Shadow = new Color(0, 0, 0, 1);
        }

        public List<string> allProperties
        {
            get
            {
                _availableProperties.Clear();
                if (_availableProperties.Count == 0)
                {

                    foreach (var property in this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if(property.PropertyType == typeof(Color))
                            _availableProperties.Add(property.Name);
                    }
                }
                return _availableProperties;
            }
        }

        public List<string> mainProperties => allProperties.Where(x => !x.StartsWith("On")).ToList();

        public Color GetColor(string propertyName) => (Color)this.GetType().GetProperty(propertyName).GetValue(this);
    }

}