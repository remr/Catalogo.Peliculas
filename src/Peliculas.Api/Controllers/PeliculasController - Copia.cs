using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peliculas.Domain;
using Peliculas.Repository.Contracts;
using Peliculas.Repository.Models;

namespace Peliculas.Api.Controllers
{
    [ApiController]
    [Route("genero")]
    public class TipoGeneroController : ControllerBase
    {
        private readonly ILogger<TipoGeneroController> _logger;
        private readonly ITipoGeneroRepository _repo;
        private readonly IMapper _mapper;

        public TipoGeneroController(ILogger<TipoGeneroController> logger, ITipoGeneroRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TipoGenero> GetAll()
        {
            var result = _repo.FindAll();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoGenero>> GetDetails(int id)
        {
            var item = _repo.FindById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<TipoGeneroDTO>> Create(PeliculaDTO model)
        {
            var generoModel = _mapper.Map<TipoGenero>(model);
            var isSuccess = _repo.Create(generoModel);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetDetails), new {id = generoModel.TipoGeneroID}, generoModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TipoGeneroDTO model)
        {
            var generoModel = _mapper.Map<TipoGenero>(model);

            var result = _repo.IsExists(id);

            if (!result)
            {
                return NotFound();
            }

            generoModel.TipoGeneroID = id;

            var isSuccess = _repo.Update(generoModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _repo.FindById(id);

            if (model == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(model);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}