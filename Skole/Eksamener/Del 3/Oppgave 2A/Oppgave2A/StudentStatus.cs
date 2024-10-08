namespace StudentSøknad
{
    public class StudentStatus
    {
        private String status;
        private readonly List<string> previousStatuses = new List<string>();

        public StudentStatus()
        {
            status = "Har Søkt";
            previousStatuses.Add(status);
        }

        public string Status
        {
            get { return status; }
        }

        public bool ChangeStatus(string newStatus)
        {
            var legalTransitions = new Dictionary<string, List<string>>
            {
                {"Har Søkt", new List<string> {"Levert dokumentasjon", "Ikke levert dokumentasjon"}},
                {"Ikke levert dokumentasjon", new List<string> {"ikke startet"}},
                {"Levert dokumentasjon", new List<string> {"Fått Tilbud", "Fått Avslag"}},
                {"Fått avslag", new List<string> {"ikke startet"}},
                {"Fått Tilbud", new List<string> {"Signert kontrakt", "Takket nei"}},
                {"Takket nei", new List<string> {"ikke startet"}},
                {"Signert kontrakt", new List<string> {"Startet", "Angret/ikke møtt"}},
                {"Angret/ikke møtt", new List<string> {"ikke startet"}},
                {"Startet", new List<string> {"Brutt", "Fullført, ikke bestått", "Fullført og Bestått"}},
                {"Fullført, ikke bestått", new List<string> {"Fullført og bestått", "ikke bestått - ikke flere forsøk igjen"}},
            };

            if (legalTransitions[status].Contains(newStatus))
            {
                status = newStatus;
                previousStatuses.Add(status);
                return true;
            }

            return false;
        }

        public bool HadStatus(string status)
        {
            return previousStatuses.Contains(status);
        }
    }
}