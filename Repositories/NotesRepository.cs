using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly FSIPlannerDbContext _context;
    public Notes CreateNote(Notes newNote)
    {
        _context.Notes.Add(newNote);
        _context.SaveChanges();
        return newNote;
    }

    public void DeleteNote(int noteId)
    {
        var note = _context.Notes.Find(noteId);
        if(note != null)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Notes> GetAllNotes()
    {
        return _context.Notes.ToList();
    }

    public Notes? GetNote(int noteId)
    {
        return _context.Notes.SingleOrDefault(c => c.NotesId == noteId);
    }

    public async Task<IEnumerable<Notes>> GetNotesByUsername(string username)
    {
        return await _context.Notes
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public Notes UpdateComment(Notes newNote)
    {
        var originalNote = _context.Notes.Find(newNote.NotesId);

        if(originalNote != null)
        {
            originalNote.Description = newNote.Description;
            originalNote.Subject = newNote.Subject;
            originalNote.CreatedAt = newNote.CreatedAt;
            _context.SaveChanges();
        }

        return originalNote;
    }
}