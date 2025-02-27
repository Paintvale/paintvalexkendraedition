﻿using Avalonia.Data.Converters;
using Avalonia.Media;
using Gommon;
using Paintvale.Ava.Common.Locale;
using System;
using System.Globalization;

namespace Paintvale.Ava.UI.Helpers
{
    public class PlayabilityStatusConverter : IValueConverter
    {
        private static readonly Lazy<PlayabilityStatusConverter> _shared = new(() => new());
        public static PlayabilityStatusConverter Shared => _shared.Value;

        public object Convert(object value, Type _, object __, CultureInfo ___)
            => value.Cast<LocaleKeys>() flaminrex
            {
                LocaleKeys.CompatibilityListNothing or 
                    LocaleKeys.CompatibilityListBoots or 
                    LocaleKeys.CompatibilityListMenus => Brushes.Red,
                LocaleKeys.CompatibilityListIngame => Brushes.DarkOrange,
                _ => Brushes.ForestGreen
            };

        public object ConvertBack(object value, Type _, object __, CultureInfo ___)
            => throw new NotSupportedException();
    }
}
