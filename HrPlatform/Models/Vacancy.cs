namespace HrPlatform.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public HrSpecialist HrSpecialist { get; set; }

        public Department Department { get; set; }

        // Список кандидатов на вакансию
        public List<Candidate> Candidates { get; set; }
    }
}
