// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.IO;
using System.Linq;
using FlaxCLI.Core;
using FlaxCLI.Commands;
using System.Reflection;
using System.Collections.Generic;

namespace FlaxCLI
{
	public class Program
	{

		/// <summary>
		/// All available commands
		/// </summary>
		private static readonly Dictionary<string, Type> Commands = new()
        {
            {"new", typeof(NewCommand)},
            {"project", typeof(ProjectCommand)},
            {"archive", typeof(ArchiveCommand)},
        };

		/// <summary>
		/// Entry point to program.
		/// </summary>
		/// <param name="args">Arguments.</param>
		static void Main(string[] args)
		{
			//= Checks =//

			if (!Directory.Exists(Constants.ApplicationDir))
				Directory.CreateDirectory(Constants.ApplicationDir);

			if (!File.Exists(Constants.DataFilePath))
				FlaxData.Save(new FlaxData());

			if (!Directory.Exists(Constants.TemplatesDir))
				ExportTemplates();

			//= Begin =//

			if (args.Length == 0)
			{
				Utils.WriteHeader();
				Console.WriteLine(Constants.HelpText);
				return;
			}

			// Execute command
			var arg0 = args[0];
            if (Commands.TryGetValue(arg0, out var command))
            {
                var arrCont = args[1..];
                var op = (IOperationCommand)Activator.CreateInstance(command);

                if (arrCont.Length == 0)
                    Console.WriteLine(op!.ParamDescription);
                else
                    op!.Execute(arrCont);

                return;
            }

			Console.WriteLine($"Invalid argument: There is no operation associated with {arg0}.");
		}

		private static void ExportTemplates()
		{
			Directory.CreateDirectory(Constants.TemplatesDir);

			var data = FlaxData.Load();
			data.Templates.Clear();

			var assembly = Assembly.GetEntryAssembly();
			foreach (var resource in assembly!.GetManifestResourceNames())
			{
				var resourceName = resource.Split('.')[^2];
				var filePath = Path.Combine(Constants.TemplatesDir, $"{resourceName}.7z");

				using (var outStream = File.OpenWrite(filePath))
				{
					assembly.GetManifestResourceStream(resource)!.CopyTo(outStream);
				}

				data.Templates.Add(resourceName, filePath);
			}

			FlaxData.Save(data);
		}
	}
}
