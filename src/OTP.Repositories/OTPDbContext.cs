using System.Reflection;

using Microsoft.EntityFrameworkCore;

using OTP.Domains.Models.CodedLists;
using OTP.Domains.Models.Common;
using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Students;
using OTP.Domains.Models.Subjects;
using OTP.Domains.Models.Tutors;

namespace OTP.Repositories
{
	public class OTPDbContext : DbContext
	{
		public OTPDbContext(DbContextOptions<OTPDbContext> options) : base(options)
		{

		}

		public DbSet<DocumentType> DocumentTypes { get; set; }

		public DbSet<EducationLevel> EducationLevels { get; set; }

		public DbSet<Gender> Genders { get; set; }

		public DbSet<Subject> Subjects { get; set; }

		public DbSet<TeachingPreference> TeachingPreferences { get; set; }

		public DbSet<TimeRange> TimeRanges { get; set; }

		public DbSet<WeekDay> WeekDays { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<StudentSubject> StudentSubjects { get; set; }

		public DbSet<Tutor> Tutors { get; set; }

		public DbSet<TutorAvailibility> TutorAvailibilities { get; set; }

		public DbSet<TutorDocument> TutorDocuments { get; set; }

		public DbSet<TutorSubject> TutorSubjects { get; set; }

		public DbSet<TutorTeachingPreference> TutorTeachingPreferences { get; set; }

		public DbSet<UserDocument> UserDocuments { get; set; }

		public DbSet<UserImage> UserImages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DocumentType>().ToTable(nameof(DocumentType));

			modelBuilder.Entity<DocumentType>().HasData(
				new DocumentType { Id = 1, Name = "Proof Of Address", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new DocumentType { Id = 2, Name = "Proof Of Id", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new DocumentType { Id = 3, Name = "Proof Of DBS", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new DocumentType { Id = 4, Name = "Proof Of Eligibility To Work", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<EducationLevel>().ToTable(nameof(EducationLevel));

			modelBuilder.Entity<EducationLevel>().HasData(
				new EducationLevel { Id = 1, Name = "Primary", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new EducationLevel { Id = 2, Name = "Secondary", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new EducationLevel { Id = 3, Name = "GCSE", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new EducationLevel { Id = 4, Name = "A Level", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new EducationLevel { Id = 5, Name = "University", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new EducationLevel { Id = 6, Name = "Masters", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<Gender>().ToTable(nameof(Gender));

			modelBuilder.Entity<Gender>().HasData(
				new Gender { Id = 1, Name = "Female", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new Gender { Id = 2, Name = "Male", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<Subject>().ToTable(nameof(Subject));

			modelBuilder.Entity<Subject>().HasData(
				new Subject { Id = 1, Name = "English", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new Subject { Id = 2, Name = "Maths", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new Subject { Id = 3, Name = "Physics", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new Subject { Id = 4, Name = "Chemistry", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new Subject { Id = 5, Name = "Biology", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<TeachingPreference>().ToTable(nameof(TeachingPreference));

			modelBuilder.Entity<TeachingPreference>().HasData(
				new TeachingPreference { Id = 1, Name = "Online", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new TeachingPreference { Id = 2, Name = "Student's Home", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new TeachingPreference { Id = 3, Name = "Tutor's Home", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<TimeRange>().ToTable(nameof(TimeRange));

			modelBuilder.Entity<TimeRange>().HasData(
				new TimeRange { Id = 1, Name = "Before 12", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new TimeRange { Id = 2, Name = "12 - 5 pm", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new TimeRange { Id = 3, Name = "After 5 pm", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<WeekDay>().ToTable(nameof(WeekDay));

			modelBuilder.Entity<WeekDay>().HasData(
				new WeekDay { Id = 1, Name = "Sunday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 2, Name = "Monday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 3, Name = "Tuesday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 4, Name = "Wednesday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 5, Name = "Thursday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 6, Name = "Friday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow },
				new WeekDay { Id = 7, Name = "Saturday", CreatedDate = DateTime.UtcNow, IsDeleted = false, ModifiedDate = DateTime.UtcNow });

			modelBuilder.Entity<Student>().ToTable(nameof(Student));

			modelBuilder.Entity<StudentSubject>().ToTable(nameof(StudentSubject));

			modelBuilder.Entity<Tutor>().ToTable(nameof(Tutor));

			modelBuilder.Entity<TutorAvailibility>().ToTable(nameof(TutorAvailibility));

			modelBuilder.Entity<TutorDocument>().ToTable(nameof(TutorDocument));

			modelBuilder.Entity<TutorSubject>().ToTable(nameof(TutorSubject));

			modelBuilder.Entity<TutorTeachingPreference>().ToTable(nameof(TutorTeachingPreference));

			modelBuilder.Entity<UserDocument>().ToTable(nameof(UserDocument));

			modelBuilder.Entity<UserImage>().ToTable(nameof(UserImage));

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
