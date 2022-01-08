﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DevNcore.UI.Design.Controls.Primitives
{
    public class ColorSlider : Slider
    {
        #region DefaultStyleKey

        static ColorSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSlider), new FrameworkPropertyMetadata(typeof(ColorSlider)));
        }
        #endregion

        #region Constructor

        public ColorSlider()
        {
            Loaded += ColorSlider_Loaded;
        }
        #endregion

        #region ColorSlider_Loaded

        private void ColorSlider_Loaded(object sender, RoutedEventArgs e)
        {
            Thumb thumb = (this.Template.FindName("PART_Track", this) as Track).Thumb;
            thumb.MouseEnter += new MouseEventHandler(Thumb_MouseEnter);
        }
        #endregion

        #region Thumb_MouseEnter

        private void Thumb_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed
                && e.MouseDevice.Captured == null)
            {
                MouseButtonEventArgs args = new(e.MouseDevice, e.Timestamp, MouseButton.Left);
                args.RoutedEvent = MouseLeftButtonDownEvent;
                (sender as Thumb).RaiseEvent(args);
            }
        }
        #endregion
    }
}
