using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using d02_ex01;

if (args.Length!=4) {
	Console.WriteLine("Usage : d02_ex01 {jsonPath} {jsonPriority} {yamlPath} {yamlPriority}");
	return;
}

string jsonPath = args[0];
int jsonPriority;
string yamlPath = args[2];
int yamlPriority;

if (!File.Exists(jsonPath)
	|| !int.TryParse(args[1],out jsonPriority)
	|| !File.Exists(yamlPath)
	|| !int.TryParse(args[3],out yamlPriority)) {
	Console.WriteLine("Wrong arguments!");
	return;
}

var yamlSrc = new YamlSource(yamlPath, yamlPriority);
var jsonSrc = new JsonSource(jsonPath, jsonPriority);
var sources = new List<IConfigurationSource>();
sources.Add(yamlSrc);
sources.Add(jsonSrc);

var config = new Configuration(sources);

Console.WriteLine("Configuration");
foreach (DictionaryEntry d in config.Params)
	Console.WriteLine($"{d.Key} : {d.Value}");
