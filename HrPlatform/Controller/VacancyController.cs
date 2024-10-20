using HrPlatform.Data;
using HrPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Controller
{
        [ApiController]
        [Route("api/[controller]")]
        public class VacancyController : ControllerBase
        {
            private readonly DataContext dataContext;

            public VacancyController(DataContext dbContext)
            {
                dataContext = dbContext;
            }

            // Получение всех вакансий с кандидатами, отделами и HR специалистами
            [HttpGet]
            public IActionResult GetVacancies()
            {
                var vacancies = dataContext.Vacancies
                    .Include(v => v.HrSpecialist)
                    .Include(v => v.Department)
                    .Include(v => v.Candidates)
                    .ToList();

                return Ok(vacancies);
            }

            // Создание вакансии
            [HttpPost("create")]
            public IActionResult CreateVacancy([FromBody] Vacancy vacancy)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                dataContext.Vacancies.Add(vacancy);
                dataContext.SaveChanges();
                return Ok(vacancy);
            }

            // Удаление вакансии
            [HttpDelete("{id}")]
            public IActionResult DeleteVacancy(int id)
            {
                var vacancy = dataContext.Vacancies
                    .Include(v => v.Candidates)
                    .FirstOrDefault(v => v.Id == id);

                if (vacancy == null)
                {
                    return NotFound("Vacancy not found");
                }

                dataContext.Vacancies.Remove(vacancy);
                dataContext.SaveChanges();
                return Ok($"Vacancy {id} deleted");
            }
        }
}
