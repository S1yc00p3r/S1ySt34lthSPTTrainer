﻿using System;

#nullable enable

namespace S1ySt34lth.Trainer.Configuration;

[AttributeUsage(AttributeTargets.Property)]
public class ConfigurationPropertyAttribute : Attribute
{
	public bool Skip { get; set; } = false;
	public int Order { get; set; } = int.MaxValue;
	public string CommentResourceId { get; set; } = string.Empty;
	public bool Browsable { get; set; } = true;
}
