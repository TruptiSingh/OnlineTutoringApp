using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTP.Repositories.Migrations
{
	/// <inheritdoc />
	public partial class AddUserDocumentTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "UserDocument",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DocumentPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					DocumentType = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserDocument", x => x.Id);
				});

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3464), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3466) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3467), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3468) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3469), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3469) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3470), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3470) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3730) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3731), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3732) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3733), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3733) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3734), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3734) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3735), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3735) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 6,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3736), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3736) });

			migrationBuilder.UpdateData(
				table: "Gender",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3863), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3863) });

			migrationBuilder.UpdateData(
				table: "Gender",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3864), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3865) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3984), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3985) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3986), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3986) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3987), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3988) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3988), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3989) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3990), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(3990) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4108), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4108) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4109), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4110) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4111), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4111) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4217), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4218) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4219), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4219) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4220), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4220) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4326), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4327) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4328), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4328) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4329), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4330) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4330), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4331) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4331), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4332) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 6,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4333), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4333) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 7,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4334), new DateTime(2023, 9, 12, 22, 54, 11, 908, DateTimeKind.Utc).AddTicks(4334) });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UserDocument");

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5385), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5386) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5388), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5388) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5390), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5390) });

			migrationBuilder.UpdateData(
				table: "DocumentType",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5391), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5392) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5566), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5567) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5568), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5568) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5569), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5570) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5571), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5571) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5572), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5573) });

			migrationBuilder.UpdateData(
				table: "EducationLevel",
				keyColumn: "Id",
				keyValue: 6,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5574), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5574) });

			migrationBuilder.UpdateData(
				table: "Gender",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5639), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5639) });

			migrationBuilder.UpdateData(
				table: "Gender",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5640), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5641) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5715), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5715) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5716), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5717) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5718), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5718) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5719), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5720) });

			migrationBuilder.UpdateData(
				table: "Subject",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5720), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5721) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5791), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5791) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5792), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5793) });

			migrationBuilder.UpdateData(
				table: "TeachingPreference",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5794), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5794) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5858), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5858) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5859), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5860) });

			migrationBuilder.UpdateData(
				table: "TimeRange",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5861), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5861) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 1,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5917), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5917) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 2,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5918), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5919) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 3,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5920), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5920) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 4,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5921), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5922) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 5,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5922), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5923) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 6,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5924), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5924) });

			migrationBuilder.UpdateData(
				table: "WeekDay",
				keyColumn: "Id",
				keyValue: 7,
				columns: new [] { "CreatedDate", "ModifiedDate" },
				values: new object [] { new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5925), new DateTime(2023, 8, 22, 18, 32, 47, 942, DateTimeKind.Utc).AddTicks(5925) });
		}
	}
}
