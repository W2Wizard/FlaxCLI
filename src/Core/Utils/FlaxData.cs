// Copyright (c) W2.Wizard 2021. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FlaxCLI.Engine;

namespace FlaxCLI.Core
{
	/// <summary>
	/// JSON File containing flax related information.
	/// </summary>
	[Serializable]
	public sealed class FlaxData
	{
		/// <summary>
		/// Key = Name
		/// Value = Filepath
		/// </summary>
		public Dictionary<string, string> Projects { get; init; }

		/// <summary>
		/// Key = Name
		/// Value = Filepath
		/// </summary>
		public Dictionary<string, string> Templates { get; init; }

		public FlaxData()
		{
			Projects = new();
			Templates = new();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ProjectInfo GetProject(string name)
		{
			if (Projects.TryGetValue(name, out string path))
			{
				return ProjectInfo.Load(path);
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public string GetTemplate(string name = "Blank")
		{	
			Templates.TryGetValue(name, out string path);
			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void Save(FlaxData data)
		{
			File.WriteAllText(Constants.DataFilePath, JsonSerializer.Serialize(data, new JsonSerializerOptions {WriteIndented = true}));
		}

		/// <summary>
		/// Loads the 
		/// </summary>
		/// <returns></returns>
		public static FlaxData Load()
		{	
			if (!File.Exists(Constants.DataFilePath))
				throw new FileNotFoundException($"Missing file \"{Path.GetFileNameWithoutExtension(Constants.DataFilePath)}\"");
			
			return JsonSerializer.Deserialize<FlaxData>(File.ReadAllText(Constants.DataFilePath));
		}
	}
}
























/*

		/// <summary>
		/// Contains all currently registered projects.
		/// </summary>
		/// <remarks>
		/// Key = Project Name | Value = Directory
		/// </remarks>
		public Dictionary<string, string> Projects { get; init; }

		/// <summary>
		/// Contains all currently registered templates.
		/// </summary>
		/// <remarks>
		/// Key = Template Name | Value = Directory
		/// </remarks>
		public Dictionary<string, string> Templates { get; init; }

		

		public ProjectInfo GetProject(string name)
		{
			Projects.TryGetValue(name, out string dir);
			return ProjectInfo.Load(dir);
		}

		public string GetTemplate(string name)
		{
			Templates.TryGetValue(name, out string dir);
			return dir;
		}

		public bool AddProject(string name, string projectDirectory) => Projects.TryAdd(name, projectDirectory);
		public bool RemoveProject(string name) => Projects.Remove(name);
		public bool ContainsTemplate(string name) => Templates.ContainsKey(name);
		public bool ContainsProject(string name) => Projects.ContainsKey(name);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static FlaxData LoadData()
		{
			string lol = File.ReadAllText(Constants.DataFilePath);
			return JsonSerializer.Deserialize<FlaxData>(lol);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public static void SaveData(FlaxData data)
		{
			File.WriteAllText(Constants.DataFilePath, JsonSerializer.Serialize(data, new JsonSerializerOptions {WriteIndented = true}));
		}

*/