// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System.IO;
using System.Linq;
using System.IO.Compression;
using FlaxCLI.Core;
using System;

namespace FlaxCLI.Commands
{
	/// <summary>
	/// 
	/// </summary>
	public class ProjectCommand : IOperationCommand
	{
		/// <inheritdoc/>
		public string ParamDescription => @"
The project command takes care of everything regarding project handling,
such as addition, deletion and renaming of projects. 

Usage:
	
	Either option can be chosen:
	
	[-a <path>]				Adds a given project, leaving empty will use current directory.
	[-d	<name/path>]		Deletes a project via name or path.
";

		/// <summary>
		/// Execution results in the creation of a project in either the specified
		/// directory or current one.
		/// </summary>
		/// <param name="args">[0] can be either name or path.</param>
		public void Execute(string[] args)
		{
			/*
			var cmd = args[0];
			FlaxData data = FlaxData.LoadData();
			
			switch (cmd)
			{
				//= Add =//
				case "-a":
				{
					var dir = args.Length >= 2 ? args[1] : Environment.CurrentDirectory;
					var file = Directory.GetFiles(dir).FirstOrDefault(file => Path.GetExtension(file) == ".flaxproj");

					if (file is null)
					{
						Console.WriteLine("There is no project in the current directory.");
						return;
					}

					var name = Path.GetFileNameWithoutExtension(file);
					if (data.ContainsProject(name))
					{
						Console.WriteLine($"Project {name} is already referenced.");
						return;
					}

					data.AddProject(name, file);
					break;
				}

				//= Delete =//
				case "-d":
				{
					var obj = args.Length >= 2 ? args[1] : Environment.CurrentDirectory;

					// Assume directory
					if (Directory.Exists(obj))
					{
						var file = Directory.GetFiles(obj).FirstOrDefault(file => Path.GetExtension(file) == ".flaxproj");
						if (file is null)
						{
							Console.WriteLine("There is no project in the current directory.");
							return;
						}

						Directory.Delete(obj, true);
						Console.WriteLine("Project was deleted successfully.");

						var name = Path.GetFileNameWithoutExtension(file);
						if (data.Projects.ContainsKey(name))
						{
							data.Projects.Remove(name);
							return;
						}
					}

					// Assume name
					else if (data.Projects.TryGetValue(obj, out string dir))
					{
						data.Projects.Remove(obj);

						if (Directory.Exists(dir))
							Directory.Delete(Path.GetDirectoryName(dir), true);
							
						Console.WriteLine("Project was deleted successfully.");
						break;
					}
					Console.WriteLine($"Project '{obj}' is not referenced.");
					break;
				}

				default: 
				{
					Console.WriteLine($"Invalid operation: No action associated with {cmd}.");
					return;
				}
			}
			FlaxData.SaveData(data);
			*/
		}
	}
}