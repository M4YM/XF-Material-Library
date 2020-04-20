using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.Resources;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Internals;

namespace XF.Material.Forms.UI
{
    /// <inheritdoc />
    /// <summary>
    /// A control that let users enter and edit text.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialTextField : ContentView, IMaterialElementConfiguration
    {
        #region BINDABLE PROPERTIES
        public static readonly BindableProperty AlwaysShowUnderlineProperty = BindableProperty.Create(nameof(AlwaysShowUnderline), typeof(bool), typeof(MaterialTextField), false);

        public static new readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#DCDCDC"));

        public static readonly BindableProperty ChoiceSelectedCommandProperty = BindableProperty.Create(nameof(ChoiceSelectedCommand), typeof(ICommand), typeof(MaterialTextField));

        public static readonly BindableProperty ChoicesProperty = BindableProperty.Create(nameof(Choices), typeof(IList), typeof(MaterialTextField));

        public static readonly BindableProperty SelectedChoiceProperty = BindableProperty.Create(nameof(SelectedChoice), typeof(object), typeof(MaterialTextField), null, BindingMode.TwoWay, null, propertyChanged: SelectedChoicePropertyChange);

        public static readonly BindableProperty ErrorColorProperty = BindableProperty.Create(nameof(ErrorColor), typeof(Color), typeof(MaterialTextField), Material.Color.Error);

        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(MaterialTextField));

        public static readonly BindableProperty FloatingPlaceholderColorProperty = BindableProperty.Create(nameof(FloatingPlaceholderColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#99000000"));

        public static readonly BindableProperty FloatingPlaceholderEnabledProperty = BindableProperty.Create(nameof(FloatingPlaceholderEnabled), typeof(bool), typeof(MaterialTextField), true);

        public static readonly BindableProperty FloatingPlaceholderFontSizeProperty = BindableProperty.Create(nameof(FloatingPlaceholderFontSize), typeof(double), typeof(MaterialTextField), 0d);

        public static readonly BindableProperty FocusCommandProperty = BindableProperty.Create(nameof(FocusCommand), typeof(Command<bool>), typeof(MaterialTextField));

        public static readonly BindableProperty HasErrorProperty = BindableProperty.Create(nameof(HasError), typeof(bool), typeof(MaterialTextField), false);

        public static readonly BindableProperty HelperTextColorProperty = BindableProperty.Create(nameof(HelperTextColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#99000000"));

        public static readonly BindableProperty HelperTextFontFamilyProperty = BindableProperty.Create(nameof(HelperTextFontFamily), typeof(string), typeof(MaterialTextField));

        public static readonly BindableProperty HelperTextProperty = BindableProperty.Create(nameof(HelperText), typeof(string), typeof(MaterialTextField), string.Empty);

        public static readonly BindableProperty HorizontalPaddingProperty = BindableProperty.Create(nameof(HorizontalPadding), typeof(MaterialHorizontalThickness), typeof(MaterialTextField), new MaterialHorizontalThickness(12d), defaultBindingMode: BindingMode.OneTime);

        public static readonly BindableProperty InputTypeProperty = BindableProperty.Create(nameof(InputType), typeof(MaterialTextFieldInputType), typeof(MaterialTextField), MaterialTextFieldInputType.Default);

        public static readonly BindableProperty IsAutoCapitalizationEnabledProperty = BindableProperty.Create(nameof(IsAutoCapitalizationEnabled), typeof(bool), typeof(MaterialTextField), false);

        public static readonly BindableProperty IsTextAllCapsProperty = BindableProperty.Create(nameof(IsTextAllCaps), typeof(bool), typeof(MaterialTextField), false);

        public static readonly BindableProperty IsMaxLengthCounterVisibleProperty = BindableProperty.Create(nameof(IsMaxLengthCounterVisible), typeof(bool), typeof(MaterialTextField), true);

        public static readonly BindableProperty IsSpellCheckEnabledProperty = BindableProperty.Create(nameof(IsSpellCheckEnabled), typeof(bool), typeof(MaterialTextField), false);

        public static readonly BindableProperty IsTextPredictionEnabledProperty = BindableProperty.Create(nameof(IsTextPredictionEnabled), typeof(bool), typeof(MaterialTextField), false);

        //public static readonly BindableProperty LeadingIconProperty = BindableProperty.Create(nameof(LeadingIcon), typeof(ImageSource), typeof(MaterialTextField));

        public static readonly BindableProperty LeadingIconProperty = BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialTextField), string.Empty);

        public static readonly BindableProperty LeadingIconTintColorProperty = BindableProperty.Create(nameof(LeadingIconTintColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#99000000"));

        public static readonly BindableProperty ErrorIconProperty = BindableProperty.Create(nameof(ErrorIcon), typeof(string), typeof(MaterialTextField), "\uf06a");

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialTextField), 0);

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#99000000"));

        public static readonly BindableProperty PlaceholderFontFamilyProperty = BindableProperty.Create(nameof(PlaceholderFontFamily), typeof(string), typeof(MaterialTextField));

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialTextField), string.Empty);

        public static readonly BindableProperty ReturnCommandParameterProperty = BindableProperty.Create(nameof(ReturnCommandParameter), typeof(object), typeof(MaterialTextField));

        public static readonly BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(MaterialTextField));

        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialTextField), ReturnType.Default);

        public static readonly BindableProperty ShouldAnimateUnderlineProperty = BindableProperty.Create(nameof(ShouldAnimateUnderline), typeof(bool), typeof(MaterialTextField), true);

        public static readonly BindableProperty TextChangeCommandProperty = BindableProperty.Create(nameof(TextChangeCommand), typeof(Command<string>), typeof(MaterialTextField));

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#D0000000"));

        public static readonly BindableProperty TextFontFamilyProperty = BindableProperty.Create(nameof(TextFontFamily), typeof(string), typeof(MaterialTextField));

        public static readonly BindableProperty TextFontSizeProperty = BindableProperty.Create(nameof(TextFontSize), typeof(double), typeof(MaterialTextField), 16d);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialTextField), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(MaterialTextField), Material.Color.Secondary);

        public static readonly BindableProperty UnderlineColorProperty = BindableProperty.Create(nameof(UnderlineColor), typeof(Color), typeof(MaterialTextField), Color.FromHex("#99000000"));

        public static readonly BindableProperty KeepErrorShownProperty = BindableProperty.Create(nameof(KeepErrorShown), typeof(bool), typeof(MaterialTextField), false);

        public static readonly BindableProperty ShowHelperOnlyOnFocusProperty = BindableProperty.Create(nameof(ShowHelperOnlyOnFocus), typeof(bool), typeof(MaterialTextField), true);

        //public static readonly BindableProperty ChoicesBindingNameProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialTextField), string.Empty, BindingMode.TwoWay);
        #endregion

        private const double AnimationDuration = 0.85;
        private readonly Easing _animationCurve = Easing.SinInOut;
        private readonly Dictionary<string, Action> _propertyChangeActions;
        private IList<string> _choices;
        private IList<string> _choicesResults;
        private bool _counterEnabled;
        private DisplayInfo _lastDeviceDisplay;
        private int _selectedIndex = -1;
        private bool _wasFocused;

        /// <summary>
        /// Initializes a new instance of <see cref="MaterialTextField"/>.
        /// </summary>
        public MaterialTextField()
        {
            InitializeComponent();
            SetPropertyChangeHandler(ref _propertyChangeActions);
            SetControl();
            _lastDeviceDisplay = DeviceDisplay.MainDisplayInfo;
        }

        public event EventHandler<SelectedItemChangedEventArgs> ChoiceSelected;

        /// <summary>
        /// Raised when this text field receives focus.
        /// </summary>
        public new event EventHandler<FocusEventArgs> Focused;

        /// <summary>
        /// Raised when this text field loses focus.
        /// </summary>
        public new event EventHandler<FocusEventArgs> Unfocused;

        /// <summary>
        /// Raised when the input text of this text field has changed.
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Raised when the user finalizes the input on this text field using the return key.
        /// </summary>
        public event EventHandler Completed;

        /// <summary>
        /// Raised when the user finalizes the input on this text field using the return key.
        /// </summary>
        public new event EventHandler HelperIsVisble;

        /// <summary>
        /// Gets or sets whether the underline accent of this text field should always show or not.
        /// </summary>
        public bool AlwaysShowUnderline
        {
            get => (bool)GetValue(AlwaysShowUnderlineProperty);
            set => SetValue(AlwaysShowUnderlineProperty, value);
        }

        /// <summary>
        /// Gets or sets the background color of this text field.
        /// </summary>
        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }


        #region CHOICES

        /// <summary>
        /// Gets or sets the collection of objects which the user will choose from. This is required when <see cref="InputType"/> is set to <see cref="MaterialTextFieldInputType.Choice"/>.
        /// </summary>
        public IList Choices
        {
            get => (IList)GetValue(ChoicesProperty);
            set => SetValue(ChoicesProperty, value);
        }

        public object SelectedChoice
        {
            get => (object)GetValue(SelectedChoiceProperty);
            set => SetValue(SelectedChoiceProperty, value);
        }


        /// <summary>
        /// Gets or sets the name of the property to display of each object in the <see cref="Choices"/> property. This will be ignored if the objects are strings.
        /// </summary>


        /// <summary>
        /// Gets or sets the command that will execute if a choice was selected when the <see cref="InputType"/> is set to <see cref="MaterialTextFieldInputType.Choice"/>.
        /// </summary>
        public ICommand ChoiceSelectedCommand
        {
            get => (ICommand)GetValue(ChoiceSelectedCommandProperty);
            set => SetValue(ChoiceSelectedCommandProperty, value);
        }

        private IList<string> GetChoices(out IList<string> choicesResults)
        {
            var choiceStrings = new List<string>(Choices.Count);
            choicesResults = new List<string>(Choices.Count);
            var listType = Choices[0].GetType();
            foreach (var item in Choices)
            {
                string choice = item.ToString();
                if (!string.IsNullOrEmpty(ChoicesBindingName))
                {
                    var propInfo = listType.GetProperty(ChoicesBindingName);

                    if (propInfo != null)
                    {
                        var propValue = propInfo.GetValue(item);
                        choice = propValue.ToString();
                    }
                }

                choiceStrings.Add(choice);

                string choiceResult = choice;
                if (!string.IsNullOrEmpty(ChoicesResultBindingName))
                {
                    var propInfo = listType.GetProperty(ChoicesResultBindingName);

                    if (propInfo != null)
                    {
                        var propValue = propInfo.GetValue(item);
                        choiceResult = propValue.ToString();
                    }
                }

                choicesResults.Add(choiceResult);
            }

            return choiceStrings;
        }

        private object GetSelectedChoice(int index)
        {
            if (index < 0)
            {
                return null;
            }
            return Choices[index];
        }

        #endregion

        /// <summary>
        /// Gets or sets the color to indicate an error in this text field.
        /// The default value is the color of <see cref="MaterialColorConfiguration.Error"/>.
        /// </summary>
        public Color ErrorColor
        {
            get => (Color)GetValue(ErrorColorProperty);
            set => SetValue(ErrorColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the error text of this text field.
        /// </summary>
        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the boolean value whether the error should continue to show once it has lost focus.
        /// </summary>
        public bool KeepErrorShown
        {
            get => (bool)GetValue(KeepErrorShownProperty);
            set => SetValue(KeepErrorShownProperty, value);
        }

        /// <summary>
        /// Gets or sets the boolean value whether the helper text should only show once it has focus.
        /// </summary>
        public bool ShowHelperOnlyOnFocus
        {
            get => (bool)GetValue(ShowHelperOnlyOnFocusProperty);
            set => SetValue(ShowHelperOnlyOnFocusProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the floating placeholder.
        /// </summary>
        public Color FloatingPlaceholderColor
        {
            get => (Color)GetValue(FloatingPlaceholderColorProperty);
            set => SetValue(FloatingPlaceholderColorProperty, value);
        }

        /// <summary>
        /// Gets or sets whether the placeholder label will float at top of the text field when focused or when it has text.
        /// </summary>
        public bool FloatingPlaceholderEnabled
        {
            get => (bool)GetValue(FloatingPlaceholderEnabledProperty);
            set => SetValue(FloatingPlaceholderEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets the font size of the floating placeholder.
        /// </summary>
        public double FloatingPlaceholderFontSize
        {
            get => (double)GetValue(FloatingPlaceholderFontSizeProperty);
            set => SetValue(FloatingPlaceholderFontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the command that will be executed when this text field receives or loses focus.
        /// </summary>
        public Command<bool> FocusCommand
        {
            get => (Command<bool>)GetValue(FocusCommandProperty);
            set => SetValue(FocusCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the boolean value whether this text field has an error, and if it will show the its error text.
        /// </summary>
        public bool HasError
        {
            get => (bool)GetValue(HasErrorProperty);
            set => SetValue(HasErrorProperty, value);
        }

        /// <summary>
        /// Gets or sets the helper text of this text field.
        /// </summary>
        public string HelperText
        {
            get => (string)GetValue(HelperTextProperty);
            set => SetValue(HelperTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of this text field's helper text.
        /// </summary>
        public Color HelperTextColor
        {
            get => (Color)GetValue(HelperTextColorProperty);
            set => SetValue(HelperTextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the font family of this text field's helper text.
        /// </summary>
        public string HelperTextFontFamily
        {
            get => (string)GetValue(HelperTextFontFamilyProperty);
            set => SetValue(HelperTextFontFamilyProperty, value);
        }

        /// <summary>
        /// Gets or sets the horizontal padding of the text field.
        /// </summary>
        public MaterialHorizontalThickness HorizontalPadding
        {
            get => (MaterialHorizontalThickness)GetValue(HorizontalPaddingProperty);
            set => SetValue(HorizontalPaddingProperty, value);
        }

        /// <summary>
        /// Gets or sets the keyboard input type of this text field.
        /// </summary>
        public MaterialTextFieldInputType InputType
        {
            get => (MaterialTextFieldInputType)GetValue(InputTypeProperty);
            set => SetValue(InputTypeProperty, value);
        }

        /// <summary>
        /// Gets or sets whether auto capitialization is enabled.
        /// </summary>
        public bool IsAutoCapitalizationEnabled
        {
            get => (bool)GetValue(IsAutoCapitalizationEnabledProperty);
            set => SetValue(IsAutoCapitalizationEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets whether the input text should be in All Caps.
        /// </summary>
        public bool IsTextAllCaps
        {
            get => (bool)GetValue(IsTextAllCapsProperty);
            set => SetValue(IsTextAllCapsProperty, value);
        }

        /// <summary>
        /// Gets or sets whether the counter for the max input length of this text field is visible or not.
        /// </summary>
        public bool IsMaxLengthCounterVisible
        {
            get => (bool)GetValue(IsMaxLengthCounterVisibleProperty);
            set => SetValue(IsMaxLengthCounterVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets whether spell checking is enabled.
        /// </summary>
        public bool IsSpellCheckEnabled
        {
            get => (bool)GetValue(IsSpellCheckEnabledProperty);
            set => SetValue(IsSpellCheckEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets whether text prediction is enabled.
        /// </summary>
        public bool IsTextPredictionEnabled
        {
            get => (bool)GetValue(IsTextPredictionEnabledProperty);
            set => SetValue(IsTextPredictionEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets the image source of the icon to be showed at the left side of this text field.
        /// </summary>
        public string LeadingIcon
        {
            get => (string)GetValue(LeadingIconProperty);
            set => SetValue(LeadingIconProperty, value);
        }

        //public ImageSource LeadingIcon
        //{
        //    get => (ImageSource)GetValue(LeadingIconProperty);
        //    set => SetValue(LeadingIconProperty, value);
        //}

        /// <summary>
        /// Gets or sets the tint color of the icon of this text field.
        /// </summary>
        public Color LeadingIconTintColor
        {
            get => (Color)GetValue(LeadingIconTintColorProperty);
            set => SetValue(LeadingIconTintColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the image source of the icon to be showed at the left side of this text field.
        /// </summary>
        public string ErrorIcon
        {
            get => (string)GetValue(ErrorIconProperty);
            set => SetValue(ErrorIconProperty, value);
        }

        /// <summary>
        /// Gets or sets the maximum allowed number of characters in this text field.
        /// </summary>
        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        /// <summary>
        /// Gets or sets the text of this text field's placeholder.
        /// </summary>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Placeholder)} must not be null, empty, or a white space.");
                }

                SetValue(PlaceholderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of this text field's placeholder.
        /// </summary>
        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the font family of this text field's placeholder
        /// </summary>
        public string PlaceholderFontFamily
        {
            get => (string)GetValue(PlaceholderFontFamilyProperty);
            set => SetValue(PlaceholderFontFamilyProperty, value);
        }

        /// <summary>
        /// Gets or sets the command that will run when the user returns the input in this textfield.
        /// </summary>
        public ICommand ReturnCommand
        {
            get => (ICommand)GetValue(ReturnCommandProperty);
            set => SetValue(ReturnCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the parameter of <see cref="ReturnCommand"/>.
        /// </summary>
        public object ReturnCommandParameter
        {
            get => GetValue(ReturnCommandParameterProperty);
            set => SetValue(ReturnCommandParameterProperty, value);
        }

        /// <summary>
        /// Gets or sets the return type of this textfield.
        /// </summary>
        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        /// <summary>
        /// Gets or sets whether the underline indicator will be animated. If set to false, the underline will not be shown.
        /// </summary>
        public bool ShouldAnimateUnderline
        {
            get => (bool)GetValue(ShouldAnimateUnderlineProperty);
            set => SetValue(ShouldAnimateUnderlineProperty, value);
        }

        public string ChoicesBindingName { get; set; }

        public string ChoicesResultBindingName { get; set; }

        //public string ChoicesBindingName
        //{
        //    get => (string)this.GetValue(ChoicesBindingNameProperty);
        //    set => this.SetValue(ChoicesBindingNameProperty, value);
        //}



        /// <summary>
        /// Gets or sets the input text of this text field.
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                if (!string.IsNullOrEmpty(value) && !FloatingPlaceholderEnabled)
                {
                    placeholder.IsVisible = false;
                }
                else if (string.IsNullOrEmpty(value) && !FloatingPlaceholderEnabled)
                {
                    placeholder.IsVisible = true;
                }

                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the command that will execute if there is a change in this text field's input text.
        /// </summary>
        public Command<string> TextChangeCommand
        {
            get => (Command<string>)GetValue(TextChangeCommandProperty);
            set => SetValue(TextChangeCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of this text field's input text.
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the font family of this text field's input text.
        /// </summary>
        public string TextFontFamily
        {
            get => (string)GetValue(TextFontFamilyProperty);
            set => SetValue(TextFontFamilyProperty, value);
        }

        /// <summary>
        /// Gets or sets the text's font size.
        /// </summary>
        public double TextFontSize
        {
            get => (double)GetValue(TextFontSizeProperty);
            set => SetValue(TextFontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the tint color of the underline and the placeholder of this text field when focused.
        /// The default value is the color of <see cref="MaterialColorConfiguration.Secondary"/>.
        /// </summary>
        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the underline when this text field is activated. <see cref="AlwaysShowUnderline"/> is set to true.
        /// </summary>
        public Color UnderlineColor
        {
            get => (Color)GetValue(UnderlineColorProperty);
            set => SetValue(UnderlineColorProperty, value);
        }

        /// <inheritdoc />
        /// <summary>
        /// For internal use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ElementChanged(bool created)
        {
            if (created)
            {
                entry.PropertyChanged += Entry_PropertyChanged;
                entry.TextChanged += Entry_TextChanged;
                entry.SizeChanged += Entry_SizeChanged;
                entry.Focused += Entry_Focused;
                entry.Unfocused += Entry_Unfocused;
                entry.Completed += Entry_Completed;
                //helper.PropertyChanged += Helper_IsVisible;
                DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
            }
            else
            {
                entry.PropertyChanged -= Entry_PropertyChanged;
                entry.TextChanged -= Entry_TextChanged;
                entry.SizeChanged -= Entry_SizeChanged;
                entry.Focused -= Entry_Focused;
                entry.Unfocused -= Entry_Unfocused;
                entry.Completed += Entry_Completed;
                //helper.PropertyChanged -= Helper_IsVisible;
                DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;
            }
        }

        /// <summary>
        /// Requests to set focus on this text field.
        /// </summary>
        public new void Focus() => entry.Focus();

        /// <summary>
        /// Requests to unset the focus on this text field.
        /// </summary>
        public new void Unfocus() => entry.Unfocus();

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            AnimateToInactiveOrFocusedStateOnStart(BindingContext);
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            AnimateToInactiveOrFocusedStateOnStart(Parent);
        }

        /// <inheritdoc />
        /// <summary>
        /// Method that is called when a bound property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == null)
            {
                return;
            }

            if (_propertyChangeActions != null && _propertyChangeActions.TryGetValue(propertyName, out var handlePropertyChange))
            {
                handlePropertyChange();
            }
        }

        private void AnimateToActivatedState()
        {
            var anim = new Animation();
            var hasText = !string.IsNullOrEmpty(Text);

            if (entry.IsFocused)
            {
                var tintColor = HasError ? ErrorColor : TintColor;

                underline.Color = tintColor;

                if (ShouldAnimateUnderline)
                {
                    anim.Add(0.0, AnimationDuration, new Animation(v => underline.HeightRequest = v, 1, 2, _animationCurve, () =>
                    {
                        //underline.Color = tintColor;
                    }));
                }

                if (ShowHelperOnlyOnFocus)
                {
                    //helper.HeightRequest = 0;
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.HeightRequest = v, 0, 25, _animationCurve, () =>
                    {
                        //helper.HeightRequest = 15;
                    }));
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.Opacity = v, 0, 1, _animationCurve, () =>
                    {
                        //helper.Opacity = 1;
                    }));
                }

                placeholder.TextColor = tintColor;
            }
            else
            {
                var underlineColor = HasError ? ErrorColor : UnderlineColor;
                var placeholderColor = HasError ? ErrorColor : FloatingPlaceholderColor;

                var endHeight = hasText ? 1 : 0;

                underline.Color = underlineColor;

                if (ShouldAnimateUnderline)
                {
                    anim.Add(0.0, AnimationDuration, new Animation(v => underline.HeightRequest = v, underline.HeightRequest, endHeight, _animationCurve, () =>
                    {
                        //underline.Color = underlineColor;
                    }));
                }

                if (ShowHelperOnlyOnFocus)
                {
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.HeightRequest = v, 25, 0, _animationCurve, () =>
                    {
                        helper.HeightRequest = 0;
                    }));
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.Opacity = v, 1, 0, _animationCurve, () =>
                    {
                        helper.Opacity = 0;
                    }));
                }

                placeholder.TextColor = placeholderColor;
            }

            anim.Commit(this, "UnfocusAnimation", rate: 2, length: (uint)(Device.RuntimePlatform == Device.iOS ? 750 : AnimationDuration * 1000), easing: _animationCurve);
        }

        private void AnimateToInactiveOrFocusedState()
        {
            Color tintColor;
            var preferredStartFont = FloatingPlaceholderFontSize == 0 ? entry.FontSize * 0.75 : FloatingPlaceholderFontSize;
            var preferredEndFont = FloatingPlaceholderFontSize == 0 ? entry.FontSize * 0.75 : FloatingPlaceholderFontSize;
            //var startFont = entry.IsFocused ? entry.FontSize : preferredStartFont;
            //var endFOnt = entry.IsFocused ? preferredEndFont : entry.FontSize;
            var startFont = entry.IsFocused ? entry.FontSize * 0.85 : preferredStartFont;
            var endFOnt = entry.IsFocused ? preferredEndFont : entry.FontSize * 0.85;
            var startY = placeholder.TranslationY;
            //WHERE SHOULD THE FLOATING PLACEHOLDER BE PLACED
            var endY = entry.IsFocused ? -(entry.FontSize * 1.1) : 0;

            if (HasError)
            {
                tintColor = entry.IsFocused ? ErrorColor : PlaceholderColor;
            }
            else
            {
                tintColor = entry.IsFocused ? TintColor : PlaceholderColor;
            }

            var anim = FloatingPlaceholderEnabled ? new Animation
            {
                {
                    0.0,
                    AnimationDuration,
                    new Animation(v => placeholder.FontSize = v, startFont, endFOnt, _animationCurve)
                },
                {
                    0.0,
                    AnimationDuration,
                    new Animation(v => placeholder.TranslationY = v, startY, endY, _animationCurve, () =>
                    {
                        if(HasError && entry.IsFocused)
                        {
                            placeholder.TextColor = ErrorColor;
                        }

                        placeholder.TextColor = tintColor;
                    })
                }
            } : new Animation();

            if (entry.IsFocused)
            {
                if (ShouldAnimateUnderline)
                {
                    underline.Color = HasError ? ErrorColor : TintColor;

                    if(AlwaysShowUnderline)
                    {
                        anim.Add(0.0, AnimationDuration, new Animation(v => underline.WidthRequest = v, 0, entry.Width, _animationCurve, () =>
                        {
                            underline.WidthRequest = -1;
                            underline.HorizontalOptions = LayoutOptions.FillAndExpand;
                        }));
                    }
                    else
                    {
                        //var widthCalc = Convert.ToDouble(Width - (entry.Margin.Right * 2));
                        //var widthCalcB = Convert.ToDouble();
                        //var widthCalcC = Convert.ToDouble(entry.WidthRequest);
                        anim.Add(0.0, AnimationDuration, new Animation(v => underline.WidthRequest = v, 0, entry.Width, _animationCurve, () =>
                        {
                            underline.WidthRequest = -1;
                            underline.HorizontalOptions = LayoutOptions.FillAndExpand;
                        }));
                    }

                    if(ShowHelperOnlyOnFocus)
                    {
                        //helper.HeightRequest = 0;
                        anim.Add(0.0, AnimationDuration, new Animation(v => helper.HeightRequest = v, 0, 25, _animationCurve, () =>
                        {
                            //helper.HeightRequest = 15;
                        }));
                        anim.Add(0.0, AnimationDuration, new Animation(v => helper.Opacity = v, 0, 1, _animationCurve, () =>
                        {
                            //helper.Opacity = 1;
                        }));
                    }
                    
                }
            }
            else
            {
                if (ShouldAnimateUnderline)
                {
                    underline.Color = HasError ? ErrorColor : UnderlineColor;

                    anim.Add(0.0, AnimationDuration, new Animation(v => underline.HeightRequest = v, underline.HeightRequest, 0, _animationCurve, () =>
                    {
                        underline.WidthRequest = 0;
                        underline.HeightRequest = 2;
                        underline.HorizontalOptions = LayoutOptions.Center;
                    }));
                }

                if (ShowHelperOnlyOnFocus)
                {
                    
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.HeightRequest = v, 25, 0, _animationCurve, () =>
                    {
                        helper.HeightRequest = 0;
                    }));
                    anim.Add(0.0, AnimationDuration, new Animation(v => helper.Opacity = v, 1, 0, _animationCurve, () =>
                    {
                        helper.Opacity = 0;
                    }));
                }
            }

            anim.Commit(this, "FocusAnimation", rate: 2, length: (uint)(Device.RuntimePlatform == Device.iOS ? 750 : AnimationDuration * 1000), easing: _animationCurve);
        }

        private void AnimateToInactiveOrFocusedStateOnStart(object startObject)
        {
            var placeholderEndY = -(entry.FontSize * 1.1);
            var placeholderEndFont = entry.FontSize * 0.85;

            if (!FloatingPlaceholderEnabled && string.IsNullOrEmpty(entry.Text))
            {
                placeholder.TextColor = PlaceholderColor;
            }

            if(!entry.IsFocused)
            {
                if (ShowHelperOnlyOnFocus)  
                {
                    helper.HeightRequest = 0;
                    helper.Opacity = 0;
                }
            }
            

            if (startObject != null && !string.IsNullOrEmpty(Text) && !_wasFocused)
            {
                if (placeholder.TranslationY == placeholderEndY)
                {
                    return;
                }
                entry.Opacity = 0;

                Device.BeginInvokeOnMainThread(() =>
                {
                    var anim = new Animation();

                    if (FloatingPlaceholderEnabled)
                    {
                        anim.Add(0.0, AnimationDuration, new Animation(v => placeholder.FontSize = v, entry.FontSize, placeholderEndFont, _animationCurve));
                        anim.Add(0.0, AnimationDuration, new Animation(v => placeholder.TranslationY = v, placeholder.TranslationY, placeholderEndY, _animationCurve, () =>
                        {
                            placeholder.TextColor = HasError ? ErrorColor : FloatingPlaceholderColor;
                            entry.Opacity = 1;
                        }));
                    }

                    if (ShouldAnimateUnderline)
                    {
                        if(Choices?.Count > 0)
                            underline.Color = HasError ? ErrorColor : UnderlineColor;
                        else
                            underline.Color = HasError ? ErrorColor : TintColor;

                        underline.HeightRequest = 1;
                        anim.Add(0.0, AnimationDuration, new Animation(v => underline.WidthRequest = v, 0, entry.Width, _animationCurve, () => underline.HorizontalOptions = LayoutOptions.FillAndExpand));
                    }

                    anim.Commit(this, "Anim2", rate: 2, length: (uint)(AnimationDuration * 1000), easing: _animationCurve);
                });

                entry.Opacity = 1;

                return;
            }

            if (startObject != null && string.IsNullOrEmpty(Text) && placeholder.TranslationY == placeholderEndY)
            {
               if (entry.IsFocused)
                {
                    return;
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    var anim = new Animation();

                    if (FloatingPlaceholderEnabled)
                    {
                        anim.Add(0.0, AnimationDuration, new Animation(v => placeholder.FontSize = v, placeholderEndFont, entry.FontSize, _animationCurve));
                        anim.Add(0.0, AnimationDuration, new Animation(v => placeholder.TranslationY = v, placeholder.TranslationY, 0, _animationCurve, () =>
                        {
                            placeholder.TextColor = PlaceholderColor;
                            entry.Opacity = 1;
                        }));
                    }

                    if (ShouldAnimateUnderline)
                    {
                        anim.Add(0.0, AnimationDuration, new Animation(v => underline.WidthRequest = v, entry.Width, 0, _animationCurve, () => underline.HorizontalOptions = LayoutOptions.Center));
                    }

                    anim.Commit(this, "Anim2", rate: 2, length: (uint)(AnimationDuration * 1000), easing: _animationCurve);
                });
            }
        
            if(startObject != null && string.IsNullOrEmpty(Text) && placeholder.TranslationY != placeholderEndY)
            {
                placeholder.FontSize = placeholderEndFont;
            }
        }

        private void ChangeToErrorState()
        {
            const int animDuration = 250;
            placeholder.TextColor = (FloatingPlaceholderEnabled && entry.IsFocused) || (FloatingPlaceholderEnabled && !string.IsNullOrEmpty(Text)) ? ErrorColor : PlaceholderColor;
            counter.TextColor = ErrorColor;
            underline.Color = ShouldAnimateUnderline ? ErrorColor : Color.Transparent;
            persistentUnderline.Color = AlwaysShowUnderline ? ErrorColor : Color.Transparent;


            trailingIcon.IsVisible = true;
            //trailingIcon.Source = ErrorIcon;
            trailingIcon.Text = ErrorIcon;
            //trailingIcon.TintColor = ErrorColor;
            trailingIcon.TextColor = ErrorColor;

            if (string.IsNullOrEmpty(ErrorText))
            {
                helper.TextColor = ErrorColor;
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await helper.FadeTo(0, animDuration / 2, _animationCurve);
                    helper.TranslationY = -4;
                    helper.TextColor = ErrorColor;
                    helper.Text = ErrorText;
                    await Task.WhenAll(helper.FadeTo(1, animDuration / 2, _animationCurve), helper.TranslateTo(0, 0, animDuration / 2, _animationCurve));
                });
            }
        }

        private void ChangeToNormalState()
        {
            const double opactiy = 1;
            IsEnabled = true;
            entry.Opacity = opactiy;
            placeholder.Opacity = opactiy;
            helper.Opacity = opactiy;
            underline.Opacity = opactiy;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (InputType == MaterialTextFieldInputType.Choice)
                {
                    //trailingIcon.Source = "xf_arrow_dropdown";
                    trailingIcon.Text = "\uf150";

                    //trailingIcon.TintColor = TextColor;
                    trailingIcon.TextColor = TextColor;
                }
                else
                {
                    trailingIcon.IsVisible = false;
                }

                var accentColor = TintColor;
                placeholder.TextColor = accentColor;
                counter.TextColor = HelperTextColor;
                underline.Color = accentColor;
                persistentUnderline.Color = UnderlineColor;

                if (string.IsNullOrEmpty(ErrorText))
                {
                    helper.TextColor = HelperTextColor;
                    helper.Text = HelperText;
                }
                else
                {
                    await helper.FadeTo(0, 150, _animationCurve);
                    helper.TranslationY = -4;
                    helper.TextColor = HelperTextColor;
                    helper.Text = HelperText;
                    await Task.WhenAll(helper.FadeTo(1, 150, _animationCurve), helper.TranslateTo(0, 0, 150, _animationCurve));
                }
            });
        }

        private static void SelectedChoicePropertyChange(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as MaterialTextField;
            if (control == null)
            {
                return;
            }

            if (control.Choices?.Count > 0)
            {
                if (newValue != null)
                {
                    // 1. Get selected value index
                    // 1.1 Current selected index and get selected index should not same.
                    // 2. set control selected index

                    // List<object> data = control.Choices as List<object>;

                    var index = control.Choices.IndexOf(newValue);

                    var underlineColor = control.HasError ? control.ErrorColor : control.UnderlineColor;
                    control.underline.Color = underlineColor;

                    if (control._selectedIndex != index)
                    {
                        control._selectedIndex = index;
                        control.Text = control._choicesResults[index];
                        control.AnimateToInactiveOrFocusedStateOnStart(control);

                        control.UpdateCounter();
                        // control.OnSelectChoices();
                    }
                }
            }
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            if (e.DisplayInfo.Orientation != _lastDeviceDisplay.Orientation)
            {
                if (!string.IsNullOrEmpty(entry.Text) && ShouldAnimateUnderline)
                {
                    underline.WidthRequest = -1;
                    underline.HorizontalOptions = LayoutOptions.FillAndExpand;
                }

                _lastDeviceDisplay = e.DisplayInfo;
            }
        }

        #region ENTRY
        private void Entry_Completed(object sender, EventArgs e) => Completed?.Invoke(this, EventArgs.Empty);

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            _wasFocused = true;

            //IF HELPER TEXT IS NOT NULL THEN SHOW IT ON FOCUS
            //IF THERE IS AN ERROR THEN SHOW IT
            if (!HasError)
                helper.IsVisible = !string.IsNullOrEmpty(HelperText);
            else
                helper.IsVisible = true;

            FocusCommand?.Execute(entry.IsFocused);
            Focused?.Invoke(this, e);
            UpdateCounter();
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsFocused) when string.IsNullOrEmpty(entry.Text):
                    AnimateToInactiveOrFocusedState();
                    break;

                case nameof(IsFocused) when !string.IsNullOrEmpty(entry.Text):
                    AnimateToActivatedState();
                    break;

                case nameof(Entry.Text):
                    Text = entry.Text;
                    UpdateCounter();
                    break;
            }
        }

        private void Entry_SizeChanged(object sender, EventArgs e)
        {
            //var baseHeight = FloatingPlaceholderEnabled ? 56 : 40;
            var baseHeight = FloatingPlaceholderEnabled ? 30 : 30;
            var diff = entry.Height - 20;
            var rawRowHeight = baseHeight + diff;
            _autoSizingRow.Height = new GridLength(rawRowHeight);

            var iconVerticalMargin = (_autoSizingRow.Height.Value - 24) / 2;

            if (leadingIcon.IsVisible)
            {
                leadingIcon.Margin = new Thickness(HorizontalPadding.Left, iconVerticalMargin, 0, iconVerticalMargin);
                entry.Margin = new Thickness(12, entry.Margin.Top, HorizontalPadding.Right, entry.Margin.Bottom);
            }
            else
            {
                entry.Margin = new Thickness(HorizontalPadding.Left, entry.Margin.Top, HorizontalPadding.Right, entry.Margin.Bottom);
            }

            if (trailingIcon.IsVisible)
            {
                var entryPaddingLeft = leadingIcon.IsVisible ? 12 : HorizontalPadding;
                trailingIcon.Margin = new Thickness(12, iconVerticalMargin, HorizontalPadding.Right, iconVerticalMargin);
                entry.Margin = new Thickness(entryPaddingLeft.Left, entry.Margin.Top, 0, entry.Margin.Bottom);
            }

            helper.Margin = new Thickness(HorizontalPadding.Left, helper.Margin.Top, 12, 0);
            counter.Margin = new Thickness(0, counter.Margin.Top, HorizontalPadding.Right, 0);

            var placeholderLeftMargin = FloatingPlaceholderEnabled ? HorizontalPadding.Left : entry.Margin.Left;
            placeholder.Margin = new Thickness(placeholderLeftMargin, entry.Margin.Top, 0, entry.Margin.Bottom);

            underline.Margin = new Thickness(entry.Margin.Left, 0, entry.Margin.Left, -1);
            persistentUnderline.Margin = new Thickness(entry.Margin.Left, 0, entry.Margin.Left, -1);

            if (HasError)
            {
                underline.Color = ErrorColor;
            }

            if (!ShowHelperOnlyOnFocus || KeepErrorShown)
                helper.IsVisible = true;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangeCommand?.Execute(entry.Text);
            TextChanged?.Invoke(this, e);
        }

        //private void Helper_IsVisible(object sender, PropertyChangedEventArgs e)
        //{
        //    var anim = new Animation();
        //    //TextChangeCommand?.Execute(entry.Text);
        //    //TextChanged?.Invoke(this, e);
        //    var help = sender;
        //    var test = e;
        //    if (helper.IsVisible)
        //        helper.BackgroundColor = Color.Red;
        //    else
        //        helper.BackgroundColor = Color.Green;

            
        //    if(helper.IsVisible)
        //    {
        //        //var start = new GridLength(0);
        //        //var end = new GridLength(15);
        //        anim.Add(0.0, AnimationDuration, new Animation(v => helper.TranslationY = v, 1.5, 1, _animationCurve, () =>
        //        {
        //            //underline.Color = underlineColor;
        //            //helper.HeightRequest = 15;
        //        }));
        //    }
        //    else
        //    {
        //        anim.Add(0.0, AnimationDuration, new Animation(v => helper.TranslationY = v, 1.5, 1, _animationCurve, () =>
        //        {
        //            //underline.Color = underlineColor;
        //            //helper.HeightRequest = 0;
        //        }));
        //    }
            

        //    anim.Commit(this, "HelperAnimation", rate: 2, length: (uint)(Device.RuntimePlatform == Device.iOS? 500 : AnimationDuration* 1000), easing: _animationCurve);
        //}


        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            FocusCommand?.Execute(entry.IsFocused);

            //// HIDE HELPER TEXT WHEN THE FOCUS IS LOST ON THE TEXT BOX
            //if (ShowHelperOnlyOnFocus)
            //    if (!HasError)
            //        helper.IsVisible = false;

            //// HIDE HELPER TEXT WHEN THE FOCUS IS LOST ON THE TEXT BOX AND ISN'T REQUIRED TO BE SHOWN
            //// EVEN WHEN IT HAS AN ERROR
            //if (HasError && !KeepErrorShown)
            //    helper.IsVisible = false;

            Unfocused?.Invoke(this, e);
            UpdateCounter();
        }

        #endregion
        

        #region ON CHANGED
        private void OnAlwaysShowUnderlineChanged(bool isShown)
        {
            persistentUnderline.IsVisible = isShown;
            persistentUnderline.Color = UnderlineColor;
        }

        private void OnBackgroundColorChanged(Color backgroundColor)
        {
            backgroundCard.BackgroundColor = backgroundColor;
        }

        private void OnChoicesChanged(ICollection choices)
        {
            if (choices?.Count > 0)
            {
                _choices = GetChoices(out _choicesResults);

                //IF THE INPUT IS CHOICE AND THE HELPER IS NOT TO BE SHOWN THEN MAKE THE ROW HEIGHT 0
                if(ShowHelperOnlyOnFocus)
                    _autoHelperSizingRow.Height = new GridLength(0);
            }
            else
            {
                _choices = null;
                _choicesResults = null;
            }
        }

        private void OnEnabledChanged(bool isEnabled)
        {
            Opacity = isEnabled ? 1 : 0.33;
            helper.IsVisible = isEnabled && !string.IsNullOrEmpty(HelperText);
        }

        private void OnErrorColorChanged(Color errorColor)
        {
            //trailingIcon.TintColor = errorColor;
            trailingIcon.TextColor = errorColor;
        }

        private void OnErrorTextChanged()
        {
            if (HasError)
            {
                ChangeToErrorState();
            }

            if (!ShowHelperOnlyOnFocus)
                helper.IsVisible = !string.IsNullOrEmpty(ErrorText);
            else
                helper.IsVisible = false;

            if (HasError && KeepErrorShown)
                helper.IsVisible = true;

            if (HasError && !KeepErrorShown)
                 helper.IsVisible = false;
        }

        private void OnFloatingPlaceholderEnabledChanged(bool isEnabled)
        {
            double marginTopVariation = Device.RuntimePlatform == Device.iOS ? 18 : 20;
            entry.Margin = isEnabled ? new Thickness(entry.Margin.Left, 24, entry.Margin.Right, 0) : new Thickness(entry.Margin.Left, marginTopVariation - 9, entry.Margin.Right, 0);

            var iconMargin = leadingIcon.Margin;
            leadingIcon.Margin = isEnabled ? new Thickness(iconMargin.Left, 16, iconMargin.Right, 16) : new Thickness(iconMargin.Left, 8, iconMargin.Right, 8);

            var trailingIconMargin = trailingIcon.Margin;
            trailingIcon.Margin = isEnabled ? new Thickness(trailingIconMargin.Left, 16, trailingIconMargin.Right, 16) : new Thickness(trailingIconMargin.Left, 8, trailingIconMargin.Right, 8);
        }

        private void OnHasErrorChanged()
        {
            if (HasError)
            {
                ChangeToErrorState();
            }
            else
            {
                ChangeToNormalState();
            }
        }

        private void OnHelperTextChanged(string helperText)
        {
            helper.Text = helperText;
            
            if(!ShowHelperOnlyOnFocus)
                helper.IsVisible = !string.IsNullOrEmpty(helperText);
            else
                helper.IsVisible = false;

            if (HasError && KeepErrorShown)
                helper.IsVisible = true;

            if (HasError && !KeepErrorShown)
                helper.IsVisible = false;

        }

        private void OnHelperTextColorChanged(Color textColor)
        {
            helper.TextColor = counter.TextColor = textColor;
        }

        private void OnHelperTextFontFamilyChanged(string fontFamily)
        {
            helper.FontFamily = counter.FontFamily = fontFamily;
        }

        private void OnInputTypeChanged()
        {
            switch (InputType)
            {
                case MaterialTextFieldInputType.Chat:
                    entry.Keyboard = Keyboard.Chat;
                    break;

                case MaterialTextFieldInputType.Default:
                    entry.Keyboard = Keyboard.Default;
                    break;

                case MaterialTextFieldInputType.Email:
                    entry.Keyboard = Keyboard.Email;
                    break;

                case MaterialTextFieldInputType.Numeric:
                    entry.Keyboard = Keyboard.Numeric;
                    break;

                //Only when plain type of keyboard we need consider the keyboard flags
                //Same as Xamarin.Forms.Entry control
                case MaterialTextFieldInputType.Plain:
                    var flags = KeyboardFlags.None;
                    if (IsTextAllCaps)
                    {
                        flags |= KeyboardFlags.CapitalizeCharacter;
                    }

                    if (IsAutoCapitalizationEnabled && !IsTextAllCaps)
                    {
                        flags |= KeyboardFlags.CapitalizeWord;
                    }

                    if (IsSpellCheckEnabled)
                    {
                        flags |= KeyboardFlags.Spellcheck;
                    }

                    if (IsTextPredictionEnabled)
                    {
                        flags |= KeyboardFlags.Suggestions;
                    }

                    entry.Keyboard = Keyboard.Create(flags);
                    break;

                case MaterialTextFieldInputType.Telephone:
                    entry.Keyboard = Keyboard.Telephone;
                    break;

                case MaterialTextFieldInputType.Text:
                    entry.Keyboard = Keyboard.Text;
                    break;

                case MaterialTextFieldInputType.Url:
                    entry.Keyboard = Keyboard.Url;
                    break;

                case MaterialTextFieldInputType.NumericPassword:
                    entry.Keyboard = Keyboard.Numeric;
                    break;

                case MaterialTextFieldInputType.Password:
                    entry.Keyboard = Keyboard.Text;
                    break;

                case MaterialTextFieldInputType.Choice:

                    break;
            }

            // Hint: Will use this for MaterialTextArea
            // entry.AutoSize = inputType == MaterialTextFieldInputType.MultiLine ? EditorAutoSizeOption.TextChanges : EditorAutoSizeOption.Disabled;
            _gridContainer.InputTransparent = InputType == MaterialTextFieldInputType.Choice;
            trailingIcon.IsVisible = InputType == MaterialTextFieldInputType.Choice;

            entry.IsNumericKeyboard = InputType == MaterialTextFieldInputType.Telephone || InputType == MaterialTextFieldInputType.Numeric;
            entry.IsPassword = InputType == MaterialTextFieldInputType.Password || InputType == MaterialTextFieldInputType.NumericPassword;
        }

        private void OnLeadingIconChanged(string imageSource)
        {
            //leadingIcon.Source = imageSource;
            leadingIcon.Text = imageSource;  // string.Format("{0}{1}", '\', imageSource);
            OnLeadingIconTintColorChanged(LeadingIconTintColor);
        }

        private void OnLeadingIconTintColorChanged(Color tintColor)
        {
            //leadingIcon.TintColor = tintColor;
            leadingIcon.TextColor = tintColor;
        }

        private void OnMaxLengthChanged(int maxLength, bool isMaxLengthCounterVisible)
        {
            _counterEnabled = maxLength > 0 && isMaxLengthCounterVisible;
            entry.MaxLength = maxLength > 0 ? maxLength : (int)InputView.MaxLengthProperty.DefaultValue;
        }

        private void OnPlaceholderChanged(string placeholderText)
        {
            placeholder.Text = placeholderText;
        }

        private void OnPlaceholderColorChanged(Color placeholderColor)
        {
            placeholder.TextColor = placeholderColor;
        }

        private void OnPlaceholderFontFamilyChanged(string fontFamily)
        {
            placeholder.FontFamily = fontFamily;
        }

        private void OnReturnCommandChanged(ICommand returnCommand)
        {
            entry.ReturnCommand = returnCommand;
        }

        private void OnReturnCommandParameterChanged(object parameter)
        {
            entry.ReturnCommandParameter = parameter;
        }

        private void OnReturnTypeChanged(ReturnType returnType)
        {
            entry.ReturnType = returnType;
        }

        private async Task OnSelectChoices()
        {
            if (Choices == null || Choices?.Count <= 0)
            {
                //throw new InvalidOperationException("The property `Choices` is null or empty");
                return;
            }
            _choices = GetChoices(out _choicesResults);

            var title = MaterialConfirmationDialog.GetDialogTitle(this);
            var confirmingText = MaterialConfirmationDialog.GetDialogConfirmingText(this);
            var dismissiveText = MaterialConfirmationDialog.GetDialogDismissiveText(this);
            var configuration = MaterialConfirmationDialog.GetDialogConfiguration(this);
            int result;

            if (_selectedIndex >= 0)
            {
                result = await MaterialDialog.Instance.SelectChoiceAsync(title, _choices, _selectedIndex, confirmingText, dismissiveText, configuration);
            }
            else
            {
                result = await MaterialDialog.Instance.SelectChoiceAsync(title, _choices, confirmingText, dismissiveText, configuration);
            }

            if (result >= 0)
            {
                _selectedIndex = result;
                Text = _choicesResults[result];
                // entry.Text = Text;
            }
        }

        private void OnTextChanged(string text)
        {
            if (InputType == MaterialTextFieldInputType.Choice && !string.IsNullOrEmpty(text) && _choicesResults?.Contains(text) == false)
            {
                Debug.WriteLine($"The `Text` property value `{Text}` does not match any item in the collection `Choices`.");
                Text = null;
                return;
            }

            if (InputType == MaterialTextFieldInputType.Choice && !string.IsNullOrEmpty(text))
            {
                var selectedChoice = GetSelectedChoice(_selectedIndex);
                SelectedChoice = selectedChoice;
                ChoiceSelected?.Invoke(this, new SelectedItemChangedEventArgs(selectedChoice, _selectedIndex));
                ChoiceSelectedCommand?.Execute(selectedChoice);
            }
            else if (InputType == MaterialTextFieldInputType.Choice && string.IsNullOrEmpty(text))
            {
                _selectedIndex = -1;
            }

            entry.Text = text;


            AnimateToInactiveOrFocusedStateOnStart(this);
            UpdateCounter();
        }

        private void OnTextColorChanged(Color textColor)
        {
            //entry.TextColor = trailingIcon.TintColor = textColor;
            entry.TextColor = trailingIcon.TextColor = textColor;
        }

        private void OnTextFontFamilyChanged(string fontFamily)
        {
            entry.FontFamily = fontFamily;
        }

        private void OnTextFontSizeChanged(double fontSize)
        {
            placeholder.FontSize = entry.FontSize = fontSize;
        }

        private void OnTintColorChanged(Color tintColor)
        {
            entry.TintColor = tintColor;
        }

        private void OnUnderlineColorChanged(Color underlineColor)
        {
            if (AlwaysShowUnderline)
            {
                persistentUnderline.Color = underlineColor;
            }
        }

        private void SetPropertyChangeHandler(ref Dictionary<string, Action> propertyChangeActions)
        {
            propertyChangeActions = new Dictionary<string, Action>
            {
                { nameof(Text), () => OnTextChanged(Text) },
                { nameof(TextColor), () => OnTextColorChanged(TextColor) },
                { nameof(TextFontFamily), () => OnTextFontFamilyChanged(TextFontFamily) },
                { nameof(TintColor), () => OnTintColorChanged(TintColor) },
                { nameof(Placeholder), () => OnPlaceholderChanged(Placeholder) },
                { nameof(PlaceholderColor), () => OnPlaceholderColorChanged(PlaceholderColor) },
                { nameof(PlaceholderFontFamily), () => OnPlaceholderFontFamilyChanged(PlaceholderFontFamily) },
                { nameof(HelperText), () => OnHelperTextChanged(HelperText) },
                { nameof(HelperTextFontFamily), () => OnHelperTextFontFamilyChanged(HelperTextFontFamily) },
                { nameof(HelperTextColor), () => OnHelperTextColorChanged(HelperTextColor) },
                { nameof(IsEnabled), () => OnEnabledChanged(IsEnabled) },
                { nameof(BackgroundColor), () => OnBackgroundColorChanged(BackgroundColor) },
                { nameof(AlwaysShowUnderline), () => OnAlwaysShowUnderlineChanged(AlwaysShowUnderline) },
                { nameof(MaxLength), () => OnMaxLengthChanged(MaxLength, IsMaxLengthCounterVisible) },
                { nameof(ReturnCommand), () => OnReturnCommandChanged(ReturnCommand) },
                { nameof(ReturnCommandParameter), () => OnReturnCommandParameterChanged(ReturnCommandParameter) },
                { nameof(ReturnType), () => OnReturnTypeChanged(ReturnType) },
                { nameof(ErrorColor), () => OnErrorColorChanged(ErrorColor) },
                { nameof(UnderlineColor), () => OnUnderlineColorChanged(UnderlineColor) },
                { nameof(HasError), () => OnHasErrorChanged() },
                { nameof(FloatingPlaceholderEnabled), () => OnFloatingPlaceholderEnabledChanged(FloatingPlaceholderEnabled) },
                { nameof(Choices), () => OnChoicesChanged(Choices) },
                { nameof(LeadingIcon), () => OnLeadingIconChanged(LeadingIcon) },
                { nameof(LeadingIconTintColor), () => OnLeadingIconTintColorChanged(LeadingIconTintColor) },
                { nameof(InputType), () => OnInputTypeChanged() },
                { nameof(IsSpellCheckEnabled), () => OnInputTypeChanged() },
                { nameof(IsTextPredictionEnabled), () => OnInputTypeChanged() },
                { nameof(IsAutoCapitalizationEnabled), () => OnInputTypeChanged() },
                { nameof(IsTextAllCaps), () => OnInputTypeChanged() },
                { nameof(TextFontSize), () => OnTextFontSizeChanged(TextFontSize) },
                { nameof(ErrorText), () => OnErrorTextChanged() }
            };
        }
        #endregion

        private void SetControl()
        {
            //trailingIcon.TintColor = TextColor;
            trailingIcon.TextColor = TextColor;
            persistentUnderline.Color = UnderlineColor;
            tapGesture.Command = new Command(() =>
            {
                if (!entry.IsFocused)
                {
                    entry.Focus();
                }
            });

            mainTapGesture.Command = new Command(async () => await OnSelectChoices());
        }

        

        private void UpdateCounter()
        {
            if (!_counterEnabled)
            {
                return;
            }

            var count = entry.Text?.Length ?? 0;
            counter.Text = entry.IsFocused ? $"{count}/{MaxLength}" : string.Empty;
        }
    }
}
