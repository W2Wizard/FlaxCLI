// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System.IO;
using System.Linq;
using System.IO.Compression;
using System;

namespace FlaxCLI.Commands
{
	/// <summary>
	/// Command associated with archiving projects.
	/// </summary>
	public class ArchiveCommand : IOperationCommand
	{
		/// <inheritdoc/>
		public string ParamDescription => @"
Packages a project in a '.7z' file, only packages what is necessary to run and compile
the project. Things like logs will not get archived.

Usage:

	Either option can be chosen:

	[<path/name> <path>]	The directory/name of the project, followed by a target directory, leaving empty uses current directory.
";

		/// <summary>
		/// Execution results in the creation of a project in either the specified
		/// directory or current one.
		/// </summary>
		/// <param name="args">[0] can be either name or path.</param>
		public void Execute(string[] args)
		{
			// TODO: use current directory instead of arg ??
			var value = args[0];

			// TODO: Improve validility
			if (Directory.Exists(value) && Directory.GetFiles(value).Any(file => Path.GetExtension(file) == ".flaxproj"))
			{
				ZipFile.CreateFromDirectory(value, Path.Combine(value, $"{Path.GetDirectoryName(value)}.7z"));
				return;
			}

			Console.WriteLine($"Could not find a project associated with: {value}.");
		}
	}
}