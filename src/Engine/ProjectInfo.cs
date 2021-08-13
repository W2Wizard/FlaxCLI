// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;

namespace FlaxCLI.Engine
{
	public sealed class ProjectInfo
	{
		/// <summary>
		/// The project reference.
		/// </summary>
		public class Reference
		{
			/// <summary>
			/// The referenced project name.
			/// </summary>
			public string Name;

			/// <summary>
			/// The referenced project.
			/// </summary>
			[NonSerialized]
			public ProjectInfo Project;

			/// <inheritdoc />
			public override string ToString()
			{
				return Name;
			}
		}

		/// <summary>
		/// The project name.
		/// </summary>
		public string Name;

		/// <summary>
		/// The project file path.
		/// </summary>
		[NonSerialized]
		public string ProjectPath;

		/// <summary>
		/// The project root folder path.
		/// </summary>
		[NonSerialized]
		public string ProjectFolderPath;

		/// <summary>
		/// The project version.
		/// </summary>
		public Version Version;

		/// <summary>
		/// The project publisher company.
		/// </summary>
		public string Company = string.Empty;

		/// <summary>
		/// The project copyright note.
		/// </summary>
		public string Copyright = string.Empty;

		/// <summary>
		/// The name of the build target to use for the game building.
		/// </summary>
		public string GameTarget;

		/// <summary>
		/// The name of the build target to use for the game in editor building.
		/// </summary>
		public string EditorTarget;

		/// <summary>
		/// The project references.
		/// </summary>
		public Reference[] References = new Reference[0];

		/// <summary>
		/// The minimum version supported by this project.
		/// </summary>
		public Version MinEngineVersion;

		/// <summary>
		/// The user-friendly nickname of the engine installation to use when opening the project.
		/// </summary>
		public string EngineNickname;

		public static ProjectInfo Load(string path)
		{
			ProjectInfo projectInfo = JsonConvert.DeserializeObject<ProjectInfo>(File.ReadAllText(path));
			projectInfo.ProjectPath = path;
			projectInfo.ProjectFolderPath = Path.GetDirectoryName(path);
			if (string.IsNullOrEmpty(projectInfo.Name))
			{
				throw new Exception("Missing project name.");
			}
			return projectInfo;
		}

		public void Save(string path)
		{
			File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
		}
	}
}
