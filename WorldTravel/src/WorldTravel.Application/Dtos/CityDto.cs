﻿namespace WorldTravel.Application.Dtos;

public class CityDto
{
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}