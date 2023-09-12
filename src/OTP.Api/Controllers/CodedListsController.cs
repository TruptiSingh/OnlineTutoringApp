using Microsoft.AspNetCore.Mvc;

using OTP.Dtos.BasicObjects;
using OTP.Dtos.Enums;
using OTP.Services.Enums.Interfaces;

namespace OTP.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CodedListsController : ControllerBase
	{
		private readonly IConvertEnumsToIntStringPair _convertEnumsToIntStringPair;

		public CodedListsController(IConvertEnumsToIntStringPair convertEnumsToIntStringPair)
		{
			_convertEnumsToIntStringPair = convertEnumsToIntStringPair;
		}

		[HttpGet("EducationLevels")]
		public ActionResult<List<IntStringPair>> GetEducationLevels()
		{
			var educationLevels = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<EducationLevels>();

			return Ok(educationLevels);
		}

		[HttpGet("Genders")]
		public ActionResult<List<IntStringPair>> GetGenders()
		{
			var genders = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<Genders>();

			return Ok(genders);
		}

		[HttpGet("TeachingPreferences")]
		public ActionResult<List<IntStringPair>> GetTeachingPreferences()
		{
			var teachingPreferences = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<TeachingPreferences>();

			return Ok(teachingPreferences);
		}

		[HttpGet("TimeRanges")]
		public ActionResult<List<IntStringPair>> GetTimeRanges()
		{
			var timeRanges = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<TimeRanges>();

			return Ok(timeRanges);
		}

		[HttpGet("WeekDays")]
		public ActionResult<List<IntStringPair>> GetWeekDays()
		{
			var weekDays = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<DayOfWeek>();

			// DayOfWeek enum values starts with 0 but we cannot have 0 as a key in the database.
			// Hence add one to the 'Key' value
			weekDays.ForEach(weekDay => weekDay.Key += 1);

			return Ok(weekDays);
		}

		[HttpGet("DocumentTypes")]
		public ActionResult<List<IntStringPair>> GetDocumentTypes()
		{
			var documentTypes = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<DocumentTypes>();

			return Ok(documentTypes);
		}

		[HttpGet("DocumentTypesForStudent")]
		public ActionResult<List<IntStringPair>> GetDocumentTypesForStudent()
		{
			var documentTypes = _convertEnumsToIntStringPair.ConvertEnumToIntStringPair<DocumentTypes>();

			documentTypes = documentTypes.Where(dt => dt.Key != 3 || dt.Key != 4).ToList();

			return Ok(documentTypes);
		}
	}
}
