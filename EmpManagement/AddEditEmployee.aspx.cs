﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagement
{
    public partial class AddEditEmployee : System.Web.UI.Page
    {
        string PageMode = "Add";
        long EmpId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pagemode"] != null)
            {
                PageMode = Convert.ToString(Request.QueryString["pagemode"]);
            }

            if (Request.QueryString["id"] != null)
            {
                EmpId = string.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])) ? 0 : Convert.ToInt64(Request.QueryString["id"]);
            }

            if (!Page.IsPostBack)
            {
                if (PageMode.ToLower() == "edit")
                {
                    Page.Title = "Edit Employee | Rahul Sharma";
                    if (EmpId > 0)
                    {
                        SetControlsValue(EmpId);
                    }
                    EnableControls(false);
                    ShowSaveButtons(false);
                }
                else
                {
                    Page.Title = "Add Employee | Rahul Sharma";
                    EnableControls(true);
                    ShowSaveButtons(true);
                }

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Entity.Employee emp = new Entity.Employee();
            emp.EmpID = Convert.ToInt64(hdnEmpID.Value);
            emp.FirstName = FirstName.Text;
            emp.LastName = LastName.Text;
            emp.Email = Email.Text;
            emp.Phone = Phone.Text;
            emp.HireDate = Convert.ToDateTime("1753-01-01");
            if (!string.IsNullOrEmpty(HireDate.Text))
            {
                emp.HireDate = Convert.ToDateTime(HireDate.Text);
            }
            emp.Position = Position.Text;
            emp.Salary = string.IsNullOrEmpty(Salary.Text) ? 0 : Convert.ToDecimal(Salary.Text);

            //Dummy1000UserDataSavetoDB(emp, PageMode);

            int result = new BAL.EmployeeMGNT().AddEditEmployee(emp, PageMode);
            if (result == 1)
            {

            }
            else if (result == 2)
            {

            }
            SetControlsValue(emp.EmpID);
            EnableControls(false);
            ShowSaveButtons(false);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (!string.IsNullOrEmpty(hdnEmpID.Value))
            {
                SetControlsValue(Convert.ToInt64(hdnEmpID.Value));
            }
            EnableControls(false);
            ShowSaveButtons(false);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            EnableControls(true);
            ShowSaveButtons(true);
        }

        private void EnableControls(bool flag)
        {
            FirstName.Enabled = flag;
            LastName.Enabled = flag;
            Email.Enabled = flag;
            Phone.Enabled = flag;
            HireDate.Enabled = flag;
            Position.Enabled = flag;
            Salary.Enabled = flag;
        }

        private void ShowSaveButtons(bool IsEdit)
        {
            BtnEdit.Visible = !IsEdit;
            BtnSave.Visible = IsEdit;
            BtnCancel.Visible = IsEdit;
        }

        private void ResetControls()
        {
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            Email.Text = string.Empty;
            Phone.Text = string.Empty;
            HireDate.Text = string.Empty;
            Position.Text = string.Empty;
            Salary.Text = string.Empty;
        }

        private void SetControlsValue(long EmpId = 0)
        {
            if (EmpId > 0)
            {
                Entity.Employee emp = new BAL.EmployeeMGNT().GetEmployeeDetailsByID(EmpId);
                if (emp.EmpID > 0)
                {
                    hdnEmpID.Value = Convert.ToString(emp.EmpID);
                    FirstName.Text = emp.FirstName;
                    LastName.Text = emp.LastName;
                    Email.Text = emp.Email;
                    Phone.Text = emp.Phone;
                    HireDate.Text = emp.HireDate.ToString("yyyy-MM-dd");
                    Position.Text = emp.Position;
                    Salary.Text = Convert.ToString(emp.Salary);
                }
            }
        }

        private void Dummy1000UserDataSavetoDB()
        {
            Random random = new Random();
            List<string> positions = new List<string>
           {
    "Software Developer",
    "Accountant",
    "Marketing Manager",
    "Sales Representative",
    "Teacher",
    "Nurse",
    "Engineer",
    "Administrative Assistant",
    "Executive Assistant",
    "Human Resources Manager",
    "Customer Service Representative",
    "Project Manager",
    "Financial Analyst",
    "Operations Manager",
    "Graphic Designer",
    "Data Analyst",
    "Business Analyst",
    "Lawyer",
    "Medical Doctor",
    "Pharmacist",
    "Dentist",
    "Real Estate Agent",
    "Chef",
    "Mechanic",
    "Electrician",
    "Plumber",
    "Architect",
    "Interior Designer",
    "Artist",
    "Photographer",
    "Writer",
    "Editor",
    "Journalist",
    "Social Worker",
    "Psychologist",
    "Counselor",
    "Athlete",
    "Coach",
    "Veterinarian",
    "Biologist",
    "Chemist",
    "Physicist",
    "Geologist",
    "Meteorologist",
    "Astronomer",
    "Marine Biologist",
    "Zoologist",
    "Historian",
    "Archaeologist",
    "Anthropologist",
    "Sociologist",
    "Economist",
    "Political Scientist",
    "Urban Planner",
    "Surveyor",
    "Pilot",
    "Flight Attendant",
    "Air Traffic Controller",
    "Aircraft Mechanic",
    "Naval Officer",
    "Soldier",
    "Police Officer",
    "Firefighter",
    "Paramedic",
    "Emergency Medical Technician",
    "Security Guard",
    "Private Investigator",
    "Law Enforcement Officer",
    "Detective",
    "Law Clerk",
    "Paralegal",
    "Court Reporter",
    "Judge",
    "Bailiff",
    "Court Clerk",
    "Legal Secretary",
    "Librarian",
    "Curator",
    "Conservator",
    "Museum Technician",
    "Event Planner",
    "Wedding Planner",
    "Travel Agent",
    "Tour Guide",
    "Hotel Manager",
    "Restaurant Manager",
    "Barista",
    "Bartender",
    "Waiter/Waitress",
    "Sommelier",
    "Fashion Designer",
    "Model",
    "Actor",
    "Director",
    "Producer",
    "Cinematographer",
    "Film Editor",
    "Sound Engineer",
    "Musician",
    "Composer",
    "Conductor",
    "Singer",
    "Dancer",
    "Choreographer",
    "Stage Manager",
    "Costume Designer",
    "Makeup Artist",
    "Hair Stylist",
    "Esthetician",
    "Fitness Trainer",
    "Nutritionist",
    "Physical Therapist",
    "Occupational Therapist",
    "Speech Therapist",
    "Chiropractor",
    "Massage Therapist",
    "Acupuncturist",
    "Dietitian",
    "Personal Trainer",
    "Coach",
    "Sports Therapist",
    "Veterinary Technician",
    "Animal Trainer",
    "Dog Groomer",
    "Pet Sitter",
    "Gardener",
    "Landscaper",
    "Forester",
    "Park Ranger",
    "Environmental Scientist",
    "Conservation Scientist",
    "Wildlife Biologist",
    "Farm Manager",
    "Agricultural Engineer",
    "Agronomist",
    "Crop Consultant",
    "Livestock Farmer",
    "Poultry Farmer",
    "Fisherman",
    "Merchant Marine",
    "Dock Worker",
    "Longshoreman",
    "Freight Forwarder",
    "Truck Driver",
    "Bus Driver",
    "Taxi Driver",
    "Chauffeur",
    "Courier",
    "Mail Carrier",
    "Postal Worker",
    "Package Handler",
    "Flight Dispatcher",
    "Airline Pilot",
    "Aircraft Dispatcher",
    "Flight Engineer",
    "Aircraft Loadmaster",
    "Aviation Safety Inspector",
    "Quality Control Inspector",
    "Quality Assurance Manager",
    "Manufacturing Engineer",
    "Production Supervisor",
    "Assembler",
    "Machinist",
    "Welder",
    "Electrician",
    "Maintenance Technician",
    "Tool and Die Maker",
    "CNC Operator",
    "Quality Assurance Technician",
    "Safety Coordinator",
    "Operations Technician",
    "Process Engineer",
    "Chemical Engineer",
    "Biomedical Engineer",
    "Materials Engineer",
    "Civil Engineer",
    "Structural Engineer",
    "Geotechnical Engineer",
    "Transportation Engineer",
    "Environmental Engineer",
    "Water Resources Engineer",
    "Mechanical Engineer",
    "Aerospace Engineer",
    "Robotics Engineer",
    "Systems Engineer",
    "Network Engineer",
    "Software Engineer",
    "Computer Scientist",
    "Information Security Analyst",
    "Database Administrator",
    "Systems Administrator",
    "Network Administrator",
    "IT Support Specialist",
    "Web Developer",
    "Mobile App Developer",
    "Game Developer",
    "UI/UX Designer",
    "Digital Marketing Specialist",
    "SEO Specialist",
    "Social Media Manager",
    "Content Creator",
    "Content Strategist",
    "Copywriter",
    "Public Relations Specialist",
    "Advertising Manager",
    "Market Research Analyst",
    "Brand Manager",
    "Media Buyer",
    "Media Planner",
    "Event Coordinator",
    "Event Manager",
    "Fundraiser",
    "Nonprofit Administrator",
    "Grant Writer",
    "Community Outreach Coordinator",
    "Social Worker",
    "Counselor",
    "Therapist",
    "Psychologist",
    "Psychiatrist",
    "Behavioral Analyst",
    "Substance Abuse Counselor",
    "Family Therapist",
    "School Counselor",
    "Career Counselor",
    "Art Therapist",
    "Music Therapist",
    "Speech Therapist",
    "Occupational Therapist",
    "Physical Therapist",
    "Nurse Practitioner",
    "Physician Assistant",
    "Medical Technologist",
    "Radiologic Technologist",
    "Ultrasound Technologist",
    "Respiratory Therapist",
    "Surgical Technologist",
    "Phlebotomist",
    "Medical Assistant",
    "Medical Billing Specialist",
    "Medical Transcriptionist",
    "Healthcare Administrator",
    "Hospital Administrator",
    "Health Information Manager",
    "Health Educator",
    "Epidemiologist",
    "Public Health Specialist",
    "Biostatistician",
    "Clinical Research Coordinator",
    "Clinical Data Manager",
    "Clinical Trial Manager",
    "Pharmaceutical Sales Representative",
    "Pharmacy Technician",
    "Pharmaceutical Scientist",
    "Clinical Pharmacist",
    "Industrial Pharmacist",
    "Research Scientist",
    "Laboratory Technician",
    "Forensic Scientist",
    "Crime Scene Investigator",
    "Computer Forensics Investigator",
    "Fire Investigator",
    "Environmental Scientist",
    "Conservation Scientist",
    "Ecologist",
    "Forester",
    "Wildlife Biologist",
    "Park Ranger",
    "Marine Biologist",
    "Zoologist",
    "Aquarist",
    "Botanist",
    "Geologist",
    "Meteorologist",
    "Astronomer",
    "Oceanographer",
    "Cartographer",
    "GIS Specialist",
    "Surveyor",
    "Anthropologist",
    "Archaeologist",
    "Historian",
    "Curator",
    "Librarian",
    "Archivist",
    "Research Librarian",
    "Museum Technician",
    "Preservationist",
    "Archeological Technician",
    "Art Conservator",
    "Legal Secretary",
    "Paralegal",
    "Court Reporter",
    "Legal Assistant",
    "Law Clerk",
    "Court Clerk",
    "Judge",
    "Lawyer",
    "Attorney",
    "Solicitor",
    "Barrister",
    "Corporate Counsel",
    "Public Defender",
    "Prosecutor",
    "Magistrate",
    "Legal Consultant",
    "Legal Advisor",
    "Legal Analyst",
    "Law Enforcement Officer",
    "Police Officer",
    "Detective",
    "Sheriff",
    "Deputy Sheriff",
    "State Trooper",
    "Highway Patrol Officer",
    "Federal Agent",
    "FBI Agent",
    "Secret Service Agent",
    "DEA Agent",
    "ATF Agent",
    "Customs Officer",
    "Border Patrol Agent",
    "Correctional Officer",
    "Prison Guard",
    "Probation Officer",
    "Parole Officer",
    "Security Officer",
    "Loss Prevention Specialist",
    "Bodyguard",
    "Private Investigator",
    "Security Consultant",
    "Security Manager",
    "Security Director",
    "Cyber Security Analyst",
    "Information Security Analyst",
    "Network Security Engineer",
    "Security Architect",
    "Chief Information Security Officer",
    "Security Specialist",
    "Penetration Tester",
    "Ethical Hacker",
    "Information Assurance Analyst",
    "Risk Manager",
    "Compliance Officer",
    "Internal Auditor",
    "External Auditor",
    "Financial Analyst",
    "Investment Analyst",
    "Portfolio Manager",
    "Financial Planner",
    "Financial Advisor",
    "Wealth Manager",
    "Investment Banker",
    "Stockbroker",
    "Trader",
    "Quantitative Analyst",
    "Risk Analyst",
    "Credit Analyst",
    "Underwriter",
    "Actuary",
    "Insurance Agent",
    "Insurance Broker",
    "Claims Adjuster",
    "Loss Adjuster",
    "Appraiser",
    "Real Estate Agent",
    "Real Estate Broker",
    "Property Manager",
    "Leasing Consultant",
    "Real Estate Appraiser",
    "Title Examiner",
    "Escrow Officer",
    "Home Inspector",
    "Construction Manager",
    "Project Manager",
    "General Contractor",
    "Civil Engineer",
    "Structural Engineer",
    "Electrical Engineer",
    "Mechanical Engineer",
    "Architect",
    "Interior Designer",
    "Landscape Architect",
    "Urban Planner",
    "Surveyor",
    "Estimator",
    "Building Inspector",
    "Construction Worker",
    "Carpenter",
    "Electrician",
    "Plumber",
    "HVAC Technician",
    "Mason",
    "Painter",
    "Roofing Contractor",
    "Flooring Installer",
    "Tile Setter",
    "Drywaller",
    "Scaffolder",
    "Glazier",
    "Insulation Installer",
    "Demolition Worker",
    "Heavy Equipment Operator",
    "Welder",
    "Pipefitter",
    "Steamfitter",
    "Ironworker",
    "Laborer",
    "Foreman",
    "Site Manager",
    "Quality Control Inspector",
    "Safety Officer",
    "Environmental Engineer",
    "Environmental Scientist",
    "Ecologist",
    "Conservationist",
    "Environmental Health Specialist",
    "Waste Management Specialist",
    "Air Quality Specialist",
    "Water Quality Specialist",
    "Soil Scientist",
    "Geologist",
    "Hydrologist",
    "Meteorologist",
    "GIS Specialist",
    "Cartographer",
    "Urban Planner",
    "Sustainability Specialist",
    "Renewable Energy Specialist",
    "Environmental Consultant",
    "Environmental Policy Analyst",
    "Environmental Educator",
    "Park Ranger",
    "Forest Ranger",
    "Wildlife Biologist",
    "Fisheries Biologist",
    "Marine Biologist",
    "Zoologist",
    "Animal Scientist",
    "Veterinarian",
    "Veterinary Technician",
    "Animal Trainer",
    "Pet Groomer",
    "Dog Walker",
    "Kennel Attendant",
    "Equine Specialist",
    "Livestock Farmer",
    "Poultry Farmer",
    "Dairy Farmer",
    "Cattle Rancher",
    "Sheep Farmer",
    "Pig Farmer",
    "Fish Farmer",
    "Beekeeper",
    "Agronomist",
    "Horticulturalist",
    "Crop Consultant",
    "Farm Manager",
    "Seed Analyst",
    "Soil Conservationist",
    "Agricultural Engineer",
    "Food Scientist",
    "Food Technologist",
    "Brewmaster",
    "Wine Maker",
    "Chef",
    "Sommelier",
    "Baker",
    "Butcher",
    "Fishmonger",
    "Nutritionist",
    "Dietitian",
    "Fitness Trainer",
    "Physical Therapist",
    "Occupational Therapist",
    "Speech Therapist",
    "Massage Therapist",
    "Chiropractor",
    "Acupuncturist",
    "Yoga Instructor",
    "Pilates Instructor",
    "Tai Chi Instructor",
    "Zumba Instructor",
    "Personal Trainer",
    "Coach",
    "Sports Psychologist",
    "Athletic Trainer",
    "Sports Agent",
    "Referee",
    "Umpire",
    "Scout",
    "Sports Broadcaster",
    "Sports Journalist",
    "Sports Photographer",
    "Athlete",
    "Professional Athlete",
    "Olympian",
    "Coach",
    "Sports Instructor",
    "Sports Coordinator",
    "Sports Manager",
    "Sports Administrator",
    "Team Manager",
    "Player Development Specialist",
    "Player Personnel Director",
    "Talent Scout",
    "Talent Manager",
    "Talent Agent",
    "Artist",
    "Painter",
    "Sculptor",
    "Illustrator",
    "Cartoonist",
    "Animator",
    "Graphic Designer",
    "Industrial Designer",
    "Fashion Designer",
    "Textile Designer",
    "Interior Designer",
    "Set Designer",
    "Exhibit Designer",
    "Jewelry Designer",
    "Product Designer",
    "User Experience Designer",
    "User Interface Designer",
    "Web Designer",
    "Creative Director",
    "Art Director",
    "Advertising Manager",
    "Brand Manager",
    "Marketing Manager",
    "Digital Marketing Specialist",
    "SEO Specialist",
    "Social Media Manager",
    "Content Creator",
    "Copywriter",
    "Public Relations Specialist",
    "Media Planner",
    "Media Buyer",
    "Event Planner",
    "Wedding Planner",
    "Meeting Planner",
    "Conference Planner",
    "Exhibition Organizer",
    "Fundraiser",
    "Grant Writer",
    "Nonprofit Administrator",
    "Community Development Manager",
    "Community Outreach Coordinator",
    "Social Worker",
    "Counselor",
    "Therapist",
    "Psychologist",
    "Behavior Analyst",
    "Addiction Counselor",
    "Mental Health Counselor",
    "Substance Abuse Counselor",
    "Family Therapist",
    "School Counselor",
    "Career Counselor",
    "Art Therapist",
    "Music Therapist",
    "Dance Therapist",
    "Occupational Therapist",
    "Physical Therapist",
    "Speech Therapist",
    "Recreational Therapist",
    "Behavioral Therapist",
    "Case Manager",
    "Housing Counselor",
    "Employment Counselor",
    "Marriage Counselor",
    "Financial Counselor",
    "Legal Counselor",
    "Peer Counselor",
    "Youth Counselor",
    "Elderly Counselor",
    "Veterans Counselor",
    "Crisis Counselor",
    "Hotline Counselor",
    "Disaster Relief Counselor",
    "Group Counselor",
    "Family Support Worker",
    "Advocate",
    "Activist",
    "Community Organizer",
    "Public Policy Analyst",
    "Lobbyist",
    "Campaign Manager",
    "Political Consultant",
    "Legislative Assistant",
    "Government Affairs Director",
    "Diplomat",
    "Ambassador",
    "Foreign Service Officer",
    "International Relations Specialist",
    "International Aid Worker",
    "Humanitarian Worker",
    "Global Health Specialist",
    "Peace Corps Volunteer",
    "Immigration Officer",
    "Customs Officer",
    "Border Patrol Agent",
    "Intelligence Analyst",
    "Cryptanalyst",
    "Signals Intelligence Analyst",
    "Counterintelligence Officer",
    "Security Analyst",
    "Security Specialist",
    "Risk Analyst",
    "Fraud Analyst",
    "Intelligence Officer",
    "Cyber Intelligence Analyst",
    "Espionage Agent",
    "Cryptographer",
    "Special Agent",
    "Undercover Agent",
    "Criminal Investigator",
    "Detective",
    "Private Investigator",
    "Investigative Journalist",
    "Forensic Accountant",
    "Forensic Scientist",
    "Crime Scene Investigator",
    "CSI Agent",
    "FBI Agent",
    "Secret Service Agent",
    "DEA Agent",
    "ATF Agent",
    "US Marshal",
    "CIA Agent",
    "NSA Agent",
    "Homeland Security Officer",
    "Airport Security Officer",
    "Border Security Officer",
    "Customs Officer",
    "Immigration Officer",
    "Coast Guard",
    "Navy Officer",
    "Army Officer",
    "Marine Officer",
    "Air Force Officer",
    "Special Forces Officer",
    "Commanding Officer",
    "Operations Officer",
    "Logistics Officer",
    "Intelligence Officer",
    "Combat Medic",
    "Combat Engineer",
    "Military Police Officer",
    "Flight Officer",
    "Pilot",
    "Aircraft Engineer",
    "Air Traffic Controller",
    "Aviation Maintenance Technician",
    "Airline Captain",
    "Flight Attendant",
    "Navigator",
    "Astronaut",
    "Astrophysicist",
    "Planetary Scientist",
    "Space Mission Specialist",
    "Rocket Engineer",
    "Satellite Engineer",
    "Ground Control Officer",
    "Mission Control Specialist",
    "Flight Director",
    "Spacecraft Systems Engineer",
    "Payload Specialist",
    "Space Tourist Guide",
    "Space Tourist",
    "Space Lawyer",
    "Space Policy Analyst",
    "Space Economist",
    "Space Ethicist",
    "Space Journalist",
    "Space Historian",
    "Space Artist",
    "Space Poet",
    "Space Photographer",
    "Space Videographer",
    "Space Influencer",
    "Space Marketing Manager",
    "Space Travel Agent",
    "Space Chef",
    "Space Psychologist",
    "Space Tour Coordinator",
    "Space Entertainer",
    "Space Adventure Guide",
    "Space Adventure Photographer",
    "Space Adventure Filmmaker",
    "Space Adventure Writer",
    "Space Adventure Poet",
    "Space Adventure Artist",
    "Space Adventure Musician",
    "Space Adventure Chef",
    "Space Adventure Athlete",
    "Space Adventure Scientist",
    "Space Adventure Engineer",
    "Space Adventure Entrepreneur",
    "Space Adventure Teacher",
    "Space Adventure Historian",
    "Space Adventure Philosopher",
    "Space Adventure Biologist",
    "Space Adventure Archaeologist",
    "Space Adventure Sociologist",
    "Space Adventure Psychologist"
            };
            List<string> emailProviders = new List<string>
{
    "gmail.com",
    "yahoo.com",
    "hotmail.com",
    "outlook.com",
    "aol.com",
    "icloud.com",
    "protonmail.com",
    "zoho.com",
    "mail.com",
    "yandex.com",
    "inbox.com",
    "gmx.com",
    "fastmail.com",
    "live.com",
    "rocketmail.com",
    "mail.ru",
    "shaw.ca",
    "cox.net",
    "earthlink.net",
    "optonline.net",
    "att.net",
    "verizon.net",
    "comcast.net",
    "sbcglobal.net",
    "charter.net",
    "bellsouth.net",
    "juno.com",
    "windstream.net",
    "centurylink.net",
    "aim.com",
    "me.com",
    "blueyonder.co.uk",
    "ntlworld.com",
    "talktalk.net",
    "t-online.de",
    "web.de",
    "orange.fr",
    "wanadoo.fr",
    "laposte.net",
    "libero.it",
    "tiscali.it",
    "alice.it",
    "virgilio.it",
    "mail.bg",
    "abv.bg",
    "gmx.de",
    "yandex.ru",
    "rambler.ru",
    "bigpond.com",
    "live.co.uk",
    "ntlworld.com",
    "shaw.ca",
    "rogers.com",
    "telus.net",
    "sympatico.ca",
    "videotron.ca",
    "eastlink.ca",
    "mts.net",
    "sasktel.net"
};
            List<string> firstNames = new List<string>
{
    "John", "Jane", "Michael", "Emily", "Chris", "Amanda", "Matthew", "Sarah", "David", "Laura", "James",
                    "Jennifer", "Robert", "Patricia", "Daniel", "Linda", "Joseph", "Elizabeth", "Mark", "Barbara",
                    "Charles", "Susan", "Steven", "Jessica", "Paul", "Karen", "Andrew", "Nancy", "Joshua", "Sandra",
                    "Kevin", "Betty", "Brian", "Dorothy", "Jason", "Margaret", "Jeffrey", "Rebecca", "Ryan", "Sharon",
                    "Jacob", "Carol", "Gary", "Ruth", "Timothy", "Kimberly", "Adam", "Michelle", "Justin", "Deborah",
                    "Eric", "Brenda", "Larry", "Helen", "Scott", "Kathleen", "Brandon", "Pamela", "Gregory", "Martha",
                    "Frank", "Debra", "Patrick", "Janet", "Stephen", "Maria", "Dennis", "Donna", "Jonathan", "Carolyn",
                    "Raymond", "Christine", "Benjamin", "Rachel", "Nicholas", "Julie", "Jack", "Evelyn", "Jeremy",
                    "Katherine", "Aaron", "Amy", "Bruce", "Lori", "Ethan", "Ann", "Peter", "Angela", "Dylan", "Jean",
                    "Arthur", "Alice", "Zachary", "Megan", "Carl", "Kathryn", "Walter", "Rose", "Randy", "Diane",
                    "Philip", "Frances"
};
            List<string> lastNames = new List<string>
{
    "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor",
                   "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez",
                   "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez",
                   "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter",
                   "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards",
                   "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy",
                   "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray",
                   "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett", "Wood", "Barnes",
                   "Ross", "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores",
                   "Washington", "Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander", "Russell", "Griffin",
                   "Diaz", "Hayes"
};

            Entity.Employee emp = new Entity.Employee();

            for (int i = 17; i <= 500; i++)
            {
                emp.FirstName = $"{firstNames[random.Next(firstNames.Count)]}";
                emp.LastName = $"{lastNames[random.Next(lastNames.Count)]}";
                emp.Email = $"{emp.FirstName}{emp.LastName.Substring(0, 3)}{random.Next(0001, 99999)}@{emailProviders[random.Next(emailProviders.Count)]}";
                emp.Phone = $"9{random.Next(01, 99):D2}{random.Next(1000000, 9999999):D7}";
                emp.HireDate = DateTime.Now.AddDays(-random.Next(0, 3650));
                emp.Salary = random.Next(15000, 120000);
                emp.Position = positions[random.Next(positions.Count)];

                new BAL.EmployeeMGNT().AddEditEmployee(emp, "Add");
            }
        }
    }
}