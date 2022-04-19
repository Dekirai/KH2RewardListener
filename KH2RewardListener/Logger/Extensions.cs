using System;
using System.Collections.Generic;
using System.Globalization;

namespace KH2RewardListener.Logger
{
  public static class Extensions
  {
    public static string ToFormattedString(this DateTime @this) => @this.@ToString("dd.MM.yyyy HH:mm");

    public static string ToTimeString(this DateTime @this) => @this.@ToString("HH:mm:ss");

    public static string ToFormattedString(this int @this) => @this.@ToString("N0", (IFormatProvider) new CultureInfo("de-DE"));

    public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
    {
      T obj = list[oldIndex];
      list.RemoveAt(oldIndex);
      list.Insert(newIndex, obj);
    }
  }
}
