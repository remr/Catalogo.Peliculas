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
    [Route("peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ILogger<PeliculasController> _logger;
        private readonly IPeliculaRepository _repo;
        private readonly IMapper _mapper;

        public PeliculasController(ILogger<PeliculasController> logger, IPeliculaRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Pelicula> GetAll()
        {
            var result = _repo.FindAll();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetDetails(int id)
        {
            var item = _repo.FindById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<PeliculaDTO>> Create(PeliculaDTO model)
        {
            var peliculaModel = _mapper.Map<Pelicula>(model);

            var isSuccess = _repo.Create(peliculaModel);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetDetails), new {id = peliculaModel.PeliculaID}, peliculaModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PeliculaDTO model)
        {
            var peliculaModel = _mapper.Map<Pelicula>(model);

            var result = _repo.IsExists(id);

            if (!result)
            {
                return NotFound();
            }

            peliculaModel.PeliculaID = id;

            var isSuccess = _repo.Update(peliculaModel);

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