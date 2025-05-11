using ClimFit.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimFit.Data.Configurations
{
    public class WeatherLogConfiguration : IEntityTypeConfiguration<WeatherLog>
    {
        public void Configure(EntityTypeBuilder<WeatherLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();
            
            // One WeatherLog can have many OutfitSuggestions
            builder.HasMany<OutfitSuggestion>()
                   .WithOne()
                   .HasForeignKey(x => x.WeatherLogId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class OutfitSuggestionConfiguration : IEntityTypeConfiguration<OutfitSuggestion>
    {
        public void Configure(EntityTypeBuilder<OutfitSuggestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            // One OutfitSuggestion belongs to one WeatherLog
            builder.HasOne<WeatherLog>()
                   .WithMany()
                   .HasForeignKey(x => x.WeatherLogId)
                   .OnDelete(DeleteBehavior.Restrict);

            // One OutfitSuggestion can have many OutfitItems
            builder.HasMany<OutfitItem>()
                   .WithOne()
                   .HasForeignKey(x => x.OutfitSuggestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class OutfitItemConfiguration : IEntityTypeConfiguration<OutfitItem>
    {
        public void Configure(EntityTypeBuilder<OutfitItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            // One OutfitItem belongs to one OutfitSuggestion
            builder.HasOne<OutfitSuggestion>()
                   .WithMany()
                   .HasForeignKey(x => x.OutfitSuggestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            // One OutfitItem references one ClothingItem
            builder.HasOne<ClothingItem>()
                   .WithMany()
                   .HasForeignKey(x => x.ClothingItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ClothingItemConfiguration : IEntityTypeConfiguration<ClothingItem>
    {
        public void Configure(EntityTypeBuilder<ClothingItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            // One ClothingItem can be used in many OutfitItems
            builder.HasMany<OutfitItem>()
                   .WithOne()
                   .HasForeignKey(x => x.ClothingItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 