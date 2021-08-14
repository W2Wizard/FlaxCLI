// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.IO;
using System.Linq;
using FlaxCLI.Core;
using System.IO.Compression;
using System.Text.RegularExpressions;
using FlaxCLI.Engine;

namespace FlaxCLI.Commands
{
	public class NewCommand : IOperationCommand
	{
		/// <inheritdoc/>
		public string ParamDescription => @"
Initilizes a new flax project in the current directory from a list of available templates.
If the template is not specified, it will use the default 'Blank' template.

Usage:

	Either option can be chosen:

	[<name>]					The name of the project, will use current directory.
	[<name> -t <template>]		The name of the project and specified template, will use current directory.
";

		/// <summary>
		/// Execution results in the creation of a project in either the specified
		/// directory or current one.
		/// </summary>
		/// <param name="args">[0] can be either name or path.</param>
		public void Execute(string[] args)
		{
			var name = args[0];
			var data = FlaxData.Load();
			var dirInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, name));

			if (!Regex.IsMatch(name, "^[a-zA-Z0-9_ ]+$"))
			{
				Console.WriteLine("Error: Name contains invalid characters.");
				return;
			}
			if (dirInfo.Exists && dirInfo.GetFiles().Any(file => file.Extension == ".flaxproj"))
			{
				Console.WriteLine("Error: Current directory already contains a project.");
				return;
			}
			if (dirInfo.Exists && data.Projects.ContainsKey(name))
			{
				Console.WriteLine("Error: Specified project already exists.");
				return;
			}

			var template = data.GetTemplate();

			// Arguments
			if (args.Length >= 3)
			{
				var cmd = args[1];
				switch (cmd)
				{
					case "-t":
					{
						var templateName = args[2];
						string tempalteDir = data.GetTemplate(templateName);
						if (data.Templates.ContainsKey(templateName) && File.Exists(tempalteDir))
						{
							template = tempalteDir;
							break;
						}
						Console.WriteLine("Error: Specified template does not exist!.");
						return;
					}

					default:
					{
						Console.WriteLine("Error: Unknown command!");
						return;
					}
				}
			}

			if (!dirInfo.Exists)
				dirInfo.Create();

			ZipFile.ExtractToDirectory(template, dirInfo.FullName);
			var projectFile = dirInfo.GetFiles().FirstOrDefault(file => file.Extension == ".flaxproj");

			var newPath = Path.Combine(dirInfo.FullName, $"{name}.flaxproj");
			File.Move(projectFile.FullName, newPath);

			var project = ProjectInfo.Load(newPath);
			project.Name = name;
			project.Save(newPath);

			if (data.Projects.ContainsKey(name))
			{
				data.Projects[name] = newPath;
			}
			else
			{
				data.Projects.Add(name, newPath);
			}
			
			FlaxData.Save(data);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Project {name} was sucessfully created!");
			Console.ResetColor();
		}
	}
}
