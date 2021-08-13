// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Reflection;

namespace FlaxCLI.Core
{
	public static class Utils
	{
		/// <summary>
		/// Displays program header.
		/// </summary>
		internal static void WriteHeader()
		{
			var versionString = Assembly.GetEntryAssembly()!
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
				?.InformationalVersion;

			var header = $"FlaxCLI v{versionString}";
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(header);
			Console.ResetColor();

			StringBuilder sb = new(header.Length);
			Console.WriteLine(sb.Append('=', header.Length).ToString());
		}
	}
}