using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Tutors;

namespace OTP.Repositories.Configurations
{
	public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
	{
		public void Configure(EntityTypeBuilder<Tutor> builder)
		{
			builder.HasMany(t => t.Subjects)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorSubject>();

			builder.HasMany(t => t.TeachingPreferences)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorTeachingPreference>();

			builder.HasMany(t => t.EducationLevels)
				.WithMany(t => t.Tutors)
				.UsingEntity<TutorEducationLevel>();
		}
	}
}
