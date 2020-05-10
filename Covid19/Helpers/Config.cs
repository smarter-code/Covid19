using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Helpers
{
    public static class RolesConfig
    {
        public static readonly string Admin = nameof(Admin);
        public static readonly string SMOHEpidemiology = "SMOH Epidemiology";
        public static readonly string LabTeam = "Lab Team";
        public static readonly string AmbulanceTeam = "Ambulance Team";
        public static readonly string CallCenter = "Call Center";

        public static readonly Dictionary<string, string> PatientStatusSecurityMatrix = new Dictionary<string, string>()
        {
            {Admin,
$"({PatientStatusConfig.Normal}) ({PatientStatusConfig.Suspect}) ({PatientStatusConfig.HighlySuspect}) ({PatientStatusConfig.WaitingForTesting}) ({PatientStatusConfig.Tested}) ({PatientStatusConfig.QuarantinedAtHome}) ({PatientStatusConfig.QuarantinedAtCenter}) ({PatientStatusConfig.IsolatedAtHome}) ({PatientStatusConfig.IsolatedAtCenter}) ({PatientStatusConfig.Recovered}) ({PatientStatusConfig.Died})"},
            {SMOHEpidemiology,
            $"({PatientStatusConfig.Normal}) ({PatientStatusConfig.Suspect}) ({PatientStatusConfig.HighlySuspect}) ({PatientStatusConfig.WaitingForTesting}) ({PatientStatusConfig.Tested}) ({PatientStatusConfig.QuarantinedAtHome}) ({PatientStatusConfig.QuarantinedAtCenter}) ({PatientStatusConfig.IsolatedAtHome}) ({PatientStatusConfig.IsolatedAtCenter}) ({PatientStatusConfig.Recovered}) ({PatientStatusConfig.Died})"},
            {LabTeam,
$"({PatientStatusConfig.HighlySuspect}) ({PatientStatusConfig.WaitingForTesting}) ({PatientStatusConfig.Tested}) ({PatientStatusConfig.QuarantinedAtCenter}) ({PatientStatusConfig.IsolatedAtHome}) ({PatientStatusConfig.IsolatedAtCenter}) ({PatientStatusConfig.Died})"},
            {AmbulanceTeam,
$"({PatientStatusConfig.Normal}) ({PatientStatusConfig.Suspect}) ({PatientStatusConfig.HighlySuspect}) ({PatientStatusConfig.WaitingForTesting}) ({PatientStatusConfig.Tested}) ({PatientStatusConfig.QuarantinedAtHome}) ({PatientStatusConfig.QuarantinedAtCenter}) ({PatientStatusConfig.IsolatedAtHome}) ({PatientStatusConfig.IsolatedAtCenter})"},
            {CallCenter,
            $"({PatientStatusConfig.Normal}) ({PatientStatusConfig.Suspect}) ({PatientStatusConfig.HighlySuspect}) ({PatientStatusConfig.WaitingForTesting}) ({PatientStatusConfig.Tested}) ({PatientStatusConfig.QuarantinedAtHome}) ({PatientStatusConfig.QuarantinedAtCenter}) ({PatientStatusConfig.IsolatedAtHome}) ({PatientStatusConfig.IsolatedAtCenter}) ({PatientStatusConfig.Recovered}) ({PatientStatusConfig.Died})"},
        };
    }

    public static class PatientStatusConfig
    {
        public static readonly string Normal = nameof(Normal);
        public static readonly string Suspect = nameof(Suspect);
        public static readonly string HighlySuspect = "Highly Suspect";
        public static readonly string WaitingForTesting = "Waiting for Testing";
        public static readonly string Tested = nameof(Tested);
        public static readonly string QuarantinedAtHome = "Quarantined at Home";
        public static readonly string QuarantinedAtCenter = "Quarantined at Center";
        public static readonly string IsolatedAtHome = "Isolated at Home";
        public static readonly string IsolatedAtCenter = "Isolated at Center";
        public static readonly string Recovered = nameof(Recovered);
        public static readonly string Died = nameof(Died);


    }
}
