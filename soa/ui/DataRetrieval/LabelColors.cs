using System.Collections.Generic;

namespace smart.charger.webui.DataRetrieval
{
	public static class LabelColors
	{
		public static string GetColor(string label)
		{
			label = label.ToLowerInvariant();
			if (Colors.ContainsKey(label))
			{
				return Colors[label];
			}
			else
			{
				return "#1ca8dd";
			}
		}

		internal static Dictionary<string, string> Colors = new Dictionary<string, string>()
		{
			{ "bug", "#cf3257"},
			{ "feature", "#2e7d32"},
			{ "enhancement", "#00c853"},
			{ "low", "#ff9800"},
			{ "medium", "#ff5d2a"},
			{ "high", "#d50000"}
		};
	}
}
