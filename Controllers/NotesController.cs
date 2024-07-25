using System.Security.Claims;
using fsiplanner_backend.Models;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private readonly INotesRepository _notesRepository;
        public NotesController(ILogger<NotesController> logger, INotesRepository repository)
        {
            _logger = logger;
            _notesRepository = repository;
        }

        [HttpGet]
        //Add authorization statement
        public ActionResult<IEnumerable<Notes>> GetNotes()
        {
            return Ok(_notesRepository.GetAllNotes());
        }

        [HttpGet]
        [Route("{username}")]
        //Add authorization statment
        public async Task<ActionResult<IEnumerable<Notes>>> GetNotesByUsername(string username)
        {
            IEnumerable<Notes> note = (IEnumerable<Notes>) await _notesRepository.GetNotesByUsername(username);
            if(note == null || !note.Any())
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpGet]
        [Route("{notesId:int}")]
        //add authorization statement
        public ActionResult<Notes> GetNotesById(int notesId)
        {
            var note = _notesRepository.GetNote(notesId);
            if(note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        //add authorization statement
        public ActionResult<Notes> CreateNote(Notes note)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            note.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var newNote = _notesRepository.CreateNote(note);
            return Created(nameof(GetNotesById), newNote);
        }

        [HttpPut]
        [Route("{notesId:int}")]
        //add authorization statement
        public ActionResult<Notes> UpdateNote(Notes notes)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_notesRepository.UpdateNote(notes));
        }

        [HttpDelete]
        [Route("{notesId:int}")]
        //add authorization statement
        public ActionResult DeleteNote(int notesId)
        {
            _notesRepository.DeleteNote(notesId);
            return NoContent();
        }
   }
}

