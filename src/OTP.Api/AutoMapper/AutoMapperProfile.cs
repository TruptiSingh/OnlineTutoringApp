﻿using AutoMapper;

using OTP.Domains.Models.CodedLists;
using OTP.Domains.Models.ManyToMany;
using OTP.Domains.Models.Subjects;
using OTP.Domains.Models.Tutors;
using OTP.Dtos.EducationLevels;
using OTP.Dtos.Subjects;
using OTP.Dtos.TeachingPreferences;
using OTP.Dtos.Tutors;
using OTP.Dtos.TutorSubjects;

namespace OTP.Api.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<EducationLevel, EducationLevelDTO>();
			CreateMap<Subject, SubjectDTO>();
			CreateMap<TutorSubject, TutorSubjectDTO>();
			CreateMap<TutorAvailibility, TutorAvailibilityDTO>();
			CreateMap<TeachingPreference, TeachingPreferenceDTO>();
			//CreateMap<TutorTeachingPreference, TutorTeachingPreferenceDTO>();
			CreateMap<Tutor, TutorDTO>();

			CreateMap<EducationLevelDTO, EducationLevel>()
				.ForMember(el => el.CreatedDate, opt => opt.Ignore())
				.ForMember(el => el.Id, opt => opt.Ignore())
				.ForMember(el => el.IsDeleted, opt => opt.Ignore())
				.ForMember(el => el.ModifiedDate, opt => opt.Ignore())
				.ForMember(el => el.Tutors, opt => opt.Ignore());

			CreateMap<SubjectDTO, Subject>()
				.ForMember(s => s.CreatedDate, opt => opt.Ignore())
				.ForMember(s => s.Id, opt => opt.Ignore())
				.ForMember(s => s.IsDeleted, opt => opt.Ignore())
				.ForMember(s => s.ModifiedDate, opt => opt.Ignore())
				.ForMember(s => s.Students, opt => opt.Ignore())
				.ForMember(s => s.Tutors, opt => opt.Ignore());

			CreateMap<TutorSubjectDTO, TutorSubject>()
				.ForMember(ts => ts.CreatedDate, opt => opt.Ignore())
				.ForMember(ts => ts.Id, opt => opt.Ignore())
				.ForMember(ts => ts.IsDeleted, opt => opt.Ignore())
				.ForMember(ts => ts.ModifiedDate, opt => opt.Ignore());

			CreateMap<TutorAvailibilityDTO, TutorAvailibility>()
				.ForMember(ta => ta.CreatedDate, opt => opt.Ignore())
				.ForMember(ta => ta.Id, opt => opt.Ignore())
				.ForMember(ta => ta.IsDeleted, opt => opt.Ignore())
				.ForMember(ta => ta.ModifiedDate, opt => opt.Ignore())
				.ForMember(ta => ta.TimeRange, opt => opt.Ignore())
				.ForMember(ta => ta.Tutor, opt => opt.Ignore())
				.ForMember(ta => ta.WeekDay, opt => opt.Ignore());

			CreateMap<TeachingPreferenceDTO, TeachingPreference>()
				.ForMember(tp => tp.CreatedDate, opt => opt.Ignore())
				.ForMember(tp => tp.Id, opt => opt.Ignore())
				.ForMember(tp => tp.IsDeleted, opt => opt.Ignore())
				.ForMember(tp => tp.ModifiedDate, opt => opt.Ignore())
				.ForMember(tp => tp.Tutors, opt => opt.Ignore());

			//CreateMap<TutorTeachingPreferenceDTO, TutorTeachingPreference>()
			//	.ForMember(ttp => ttp.CreatedDate, opt => opt.Ignore())
			//	.ForMember(ttp => ttp.Id, opt => opt.Ignore())
			//	.ForMember(ttp => ttp.IsDeleted, opt => opt.Ignore())
			//	.ForMember(ttp => ttp.ModifiedDate, opt => opt.Ignore());

			//CreateMap<TutorDTO, Tutor>()
			//	.ForMember(t => t.CreatedDate, opt => opt.Ignore())
			//	.ForMember(t => t.Id, opt => opt.Ignore())
			//	.ForMember(t => t.IsDeleted, opt => opt.Ignore())
			//	.ForMember(t => t.ModifiedDate, opt => opt.Ignore())
			//	.ForMember(t => t.TutorDocuments, opt => opt.Ignore());
		}
	}
}
