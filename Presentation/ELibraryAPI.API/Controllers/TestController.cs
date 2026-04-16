using ELibraryAPI.Application.Abstractions.Repositories.Entities;
using ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IAuthorReadRepository _authorReadRepository;
        private IAuthorWriteRepository _authorWriteRepository;

        public TestController(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            this._authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var result=await _authorReadRepository.GetByIdAsync(Guid.Parse(id),false);
            return Ok(result);  
        }
        [HttpPost]
        public async Task Create()
        {
           await  _authorWriteRepository.AddAsync(new Author() {FullName="Azer",Country="azerbaycan", Biography = "Tanınmış yazıçı...", ImagePath = "default.jpg"});
          await  _authorWriteRepository.SaveAsync();
        }
    }
}
