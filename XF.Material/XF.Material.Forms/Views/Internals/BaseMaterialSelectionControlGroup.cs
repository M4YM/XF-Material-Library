﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XF.Material.Forms.Resources;

namespace XF.Material.Forms.Views.Internals
{
    /// <summary>
    /// Base class of selection control groups. Used by <see cref="MaterialRadioButtonGroup"/> and <see cref="MaterialCheckboxGroup"/>.
    /// </summary>
    public abstract class BaseMaterialSelectionControlGroup : ContentView
    {
        public static readonly BindableProperty ChoicesProperty = BindableProperty.Create(nameof(Choices), typeof(IList<string>), typeof(BaseMaterialSelectionControlGroup), default(IList<string>));

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialSelectionControlGroup), Material.FontFamily.Body1);

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialSelectionControlGroup), Material.GetResource<double>(MaterialConstants.MATERIAL_FONTSIZE_BODY1));

        public static readonly BindableProperty HorizontalSpacingProperty = BindableProperty.Create(nameof(HorizontalSpacing), typeof(double), typeof(BaseMaterialSelectionControlGroup), 0.0);

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(BaseMaterialSelectionControlGroup), Material.Color.Secondary);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialSelectionControlGroup), Color.FromHex("#DE000000"));

        public static readonly BindableProperty UnselectedColorProperty = BindableProperty.Create(nameof(UnselectedColor), typeof(Color), typeof(BaseMaterialSelectionControlGroup), Color.FromHex("#84000000"));

        public static readonly BindableProperty VerticalSpacingProperty = BindableProperty.Create(nameof(VerticalSpacing), typeof(double), typeof(BaseMaterialSelectionControlGroup), 0.0);


        /// <summary>
        /// Gets or sets the list of string which the user will choose from.
        /// </summary>
        public IList<string> Choices
        {
            get => (IList<string>)this.GetValue(ChoicesProperty);
            set => this.SetValue(ChoicesProperty, value);
        }

        /// <summary>
        /// Gets or sets the font family of the text of each radio buttons.
        /// </summary>
        public string FontFamily
        {
            get => (string)this.GetValue(FontFamilyProperty);
            set => this.SetValue(FontFamilyProperty, value);
        }

        /// <summary>
        /// Gets or sets the font size of the text of each radio buttons.
        /// </summary>
        public double FontSize
        {
            get => (double)this.GetValue(FontSizeProperty);
            set => this.SetValue(FontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the spacing between the radio button and its text.
        /// </summary>
        public double HorizontalSpacing
        {
            get => (double)this.GetValue(HorizontalSpacingProperty);
            set => this.SetValue(HorizontalSpacingProperty, value);
        }

        /// <summary>
        /// Gets or sets the color that will be used to tint this control when it is selected.
        /// </summary>
        public Color SelectedColor
        {
            get => (Color)this.GetValue(SelectedColorProperty);
            set => this.SetValue(SelectedColorProperty, value);
        }


        public Color TextColor
        {
            get => (Color)this.GetValue(TextColorProperty);
            set => this.SetValue(TextColorProperty, value);
        }

        public Color UnselectedColor
        {
            get => (Color)this.GetValue(UnselectedColorProperty);
            set => this.SetValue(UnselectedColorProperty, value);
        }
        public double VerticalSpacing
        {
            get => (double)this.GetValue(VerticalSpacingProperty);
            set => this.SetValue(VerticalSpacingProperty, value);
        }

        protected virtual void CreateChoices() { }

        internal abstract ObservableCollection<MaterialSelectionControlModel> Models { get; }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(this.Choices) && this.Choices != null && this.Choices.Any())
            {
                this.CreateChoices();
            }

            else if (propertyName == nameof(this.IsEnabled))
            {
                this.Opacity = this.IsEnabled ? 1.0 : 0.38;
            }
        }
    }
}