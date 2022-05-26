private static string DecodeMessage(string[] lines)
{
	List<string> output = new List<string>();

	for (int i = 0; i < lines.Length-1; i++)
		foreach (string el in lines[i].Split(' '))
			if (lines[i] != "" && Char.IsUpper(el[0]))
				output.Add(el);

	output.Reverse();
	return String.Join(" ", output);
}
