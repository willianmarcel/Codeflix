﻿using Codeflix.Catalog.Domain.Entity;

namespace Codeflix.Catalog.Infra.Data.EF.Models;
public class VideosCastMembers
{
    public VideosCastMembers(
        Guid castMemberId,
        Guid videoId
    )
    {
        CastMemberId = castMemberId;
        VideoId = videoId;
    }

    public Guid CastMemberId { get; set; }
    public Guid VideoId { get; set; }
    public CastMember? CastMember { get; set; }
    public Video? Video { get; set; }
}
