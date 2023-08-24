using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Tournament;

namespace Infrastructure.Configurations;

internal sealed class TournamentConfiguration : IEntityTypeConfiguration<Tournament> {
    public void Configure(EntityTypeBuilder<Tournament> entityTypeBuilder) {

    }
}