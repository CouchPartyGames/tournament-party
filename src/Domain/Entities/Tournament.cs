﻿namespace Domain.Entities;

public sealed class Tournament
{
    Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    int MinParticipants { get; set; }

    int MaxParticipants { get; set; }



}

