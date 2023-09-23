using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Students;

namespace OTP.Repositories.Configurations
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasMany(s => s.Subjects)
				.WithMany(s => s.Students)
				.UsingEntity<StudentSubject>();
		}
	}
}
