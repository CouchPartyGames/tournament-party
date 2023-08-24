using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Match;

namespace Infrastructure.Configurations;

internal sealed class MatchConfiguration : IEntityTypeConfiguration<Match> {
    public void Configure(EntityTypeBuilder<Match> entityTypeBuilder) {

    }
}