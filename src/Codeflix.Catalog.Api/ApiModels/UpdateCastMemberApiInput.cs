﻿using Codeflix.Catalog.Domain.Enum;

namespace Codeflix.Catalog.Api.ApiModels;

public class UpdateCastMemberApiInput
{
    public string Name { get; set; }
    public CastMemberType Type { get; set; }

    public UpdateCastMemberApiInput(string name, CastMemberType type)
    {
        Name = name;
        Type = type;
    }
}
