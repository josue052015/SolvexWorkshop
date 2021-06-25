using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLuau
{
	
	public class Speaker
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? YearsExperience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }
		public int RegistrationFee { get; set; }
		public List<Session> Sessions { get; set; }

		
		public RegisterResponse Register(IRepository repository)
		{
            var error = ValidateRegistration();
            if (error != null) return new RegisterResponse(error);

			int? speakerId = repository.SaveSpeaker(this);
               
            return new RegisterResponse((int)speakerId);
		}

        private RegisterError? ValidateRegistration()
        {
            var error = ValidateData();
            if (error != null) return error;

            bool IsSpeakerQualified = AppearsExceptional() || HasRedFlags();


            if (!IsSpeakerQualified)
            {
                return  RegisterError.SpeakerDoesNotMeetStandards;
            }
            bool atLeastOneSessionApproved = ApproveSessions();
            if(!atLeastOneSessionApproved) return RegisterError.NoSessionsApproved;

            //TODO: reparar esto
            return RegisterError.NoSessionsApproved;
        }
        private bool ApproveSessions()
        {
            foreach (var session in Sessions)
            {
                session.Approved = !IsSessionAboutOldTech(session);
            }
            return Sessions.Any(x => x.Approved);
        }
        private bool IsSessionAboutOldTech(Session session)
        {
            var oldTech = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
            foreach (var tech in oldTech)
            {
                if (session.Title.Contains(tech) || session.Description.Contains(tech))
                {
                    session.Approved = true;
                }
            }
                return false;
              
        }
        private bool HasRedFlags()
        {
            string emailDomain = Email.Split('@').Last();
            var OldEmailsDomains = new List<string>() { "aol.com", "prodigy.com", "compuserve.com" };

            if (OldEmailsDomains.Contains(emailDomain)) return true;
            if (Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9) return true;

            return false;
        }
        private bool AppearsExceptional()
        {
            if (YearsExperience > 10) return true;
            if (HasBlog) return true;
            if (Certifications.Count() > 3) return true;
            var preferredEmployers = new List<string>() { "Pluralsight", "Microsoft", "Google" };
            if (preferredEmployers.Contains(Employer)) return true;
            return false;
        }
        private RegisterError? ValidateData()
        {
    if (string.IsNullOrWhiteSpace(FirstName)) return RegisterError.FirstNameRequired;

    if (string.IsNullOrWhiteSpace(LastName)) return RegisterError.LastNameRequired;
        
    if (string.IsNullOrWhiteSpace(Email)) return RegisterError.EmailRequired;
        if(!Sessions.Any())  return  RegisterError.SpeakerDoesNotMeetStandards;

            return null;
        }
	}
}