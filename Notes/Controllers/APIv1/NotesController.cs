namespace Notes.Controllers.APIv1
{
    using System.Net;
    using System.Threading.Tasks;
    using DataAccess;
    using DataAccess.Repositories;
    using Dtos;
    using Microsoft.AspNetCore.Mvc;

    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        [HttpPut]
        [Route(CustomerRoutes.Note)]
        public async Task<IActionResult> PutNote(int noteId, NoteDetailDto noteDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (noteId != noteDetailDto.Id)
            {
                return BadRequest();
            }

            await _notesRepository.UpdateNote(noteDetailDto.ToModel());

            return NoContent();
        }

        [HttpPost]
        [Route(CustomerRoutes.Notes)]
        public async Task<ActionResult<NoteDetailDto>> PostNote(NewNoteDto newNoteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newNote = await _notesRepository.AddNote(newNoteDto.ToModel());

            return CreatedAtRoute("DefaultApi", new { id = newNote.Id }, newNote.ToDto());
        }
    }
}