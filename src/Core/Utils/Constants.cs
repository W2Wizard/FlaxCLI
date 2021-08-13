// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.IO;

namespace FlaxCLI.Core
{
	public static class Constants
	{
		/// <summary>
		/// Help text displayed when no command is entered.
		/// </summary>
		public const string HelpText = @"
Usage:

	new          Initilizes a new project.
	archive      Archives a project into a .zip file.
	project      Lets you add, remove or define project directories.
";

		/// <summary>
		/// The directory of the FlaxCLI's application data
		/// </summary>
		public static readonly string ApplicationDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FlaxCLI");

		/// <summary>
		/// The directory of the FlaxCLI version file which includes all registered engine directories and projects.
		/// </summary>
		public static readonly string DataFilePath = Path.Combine(ApplicationDir, "Data.json");

		/// <summary>
		/// The directory where all templates are stored.
		/// </summary>
		public static readonly string TemplatesDir = Path.Combine(ApplicationDir, "Templates");
	}
}