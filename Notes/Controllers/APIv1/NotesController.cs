namespace Notes.Controllers.APIv1
{
    using System.Net;
    using System.Threading.Tasks;
    using DataAccess;
    using DataAccess.Repositories;
    using Dtos;
    using Microsoft.AspNetCore.Mvc;

    public class NotesController : ApiController
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        [HttpPut]
        [Route(CustomerRoutes.Note)]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNote(int noteId, NoteDetailDto noteDetailDto)
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route(CustomerRoutes.Notes)]
        [ResponseType(typeof(NoteDetailDto))]
        public async Task<IHttpActionResult> PostNote(NewNoteDto newNoteDto)
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