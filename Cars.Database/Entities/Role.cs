﻿namespace Cars.Database.Entities;

public class Role
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public Role(string name) => Name = name;
}