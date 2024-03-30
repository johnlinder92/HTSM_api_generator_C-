using Microsoft.AspNetCore.Mvc;

namespace HTSM_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerateCoverageController : ControllerBase
    {
        private static readonly string[] QualityCriterias = new[]
        {
            "Capability", "Reliability", "Usability", "Charisma", "Security", "Scalability", "Compatibility", "Performance", "Installability", "Development"
        };

        private static readonly string[] ProductElements = new[]
      {
            "Structure", "Function", "Data", "Interfaces", "Platform", "Operations", "Time"
        };

        private readonly ILogger<GenerateCoverageController> _logger;

        public GenerateCoverageController(ILogger<GenerateCoverageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCoverageIdea")]
        public IEnumerable<CoverageIdea> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new CoverageIdea
            {
                ProductElement = ProductElements[Random.Shared.Next(ProductElements.Length)],
                QualityCriteria = QualityCriterias[Random.Shared.Next(QualityCriterias.Length)]
            })
            .ToArray();
        }
    }
}
