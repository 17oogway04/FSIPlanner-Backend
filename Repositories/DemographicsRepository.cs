using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class DemographicsRepository : IDemographicsRepository
{
    private readonly FSIPlannerDbContext _context;
    public DemographicsRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }
    public Demographics CreateDemographics(Demographics newDemographic)
    {
        _context.Demographics.Add(newDemographic);
        _context.SaveChanges();
        return newDemographic;
    }

    public void DeleteDemographic(int demographicId)
    {
        var demographic = _context.Demographics.Find(demographicId);
        if(demographic != null)
        {
            _context.Demographics.Remove(demographic);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Demographics> GetAllDemographics()
    {
        return _context.Demographics.ToList();
    }

    public Demographics GetDemographic(int demographicId)
    {
        return _context.Demographics.SingleOrDefault(c => c.DemographicsId == demographicId)!;
    }

    public async Task<IEnumerable<Demographics>> GetDemographicsByUserId(string userId)
    {
        return await _context.Demographics
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Demographics>> GetDemographicsByUsername(string username)
    {
        return await _context.Demographics
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public Demographics UpdateDemographic(Demographics newDemographic)
    {
        var originalDemo = _context.Demographics.Find(newDemographic.DemographicsId);
        if(originalDemo != null)
        {
            originalDemo.Spouse = newDemographic.Spouse;
            originalDemo.SpouseEmail = newDemographic.SpouseEmail;
            originalDemo.C1 = newDemographic.C1;
            originalDemo.C2 = newDemographic.C2;
            originalDemo.C3 = newDemographic.C3;
            originalDemo.C4 = newDemographic.C4;
            originalDemo.SocialSecurity = newDemographic.SocialSecurity;
            originalDemo.DriversLicense = newDemographic.DriversLicense;
            originalDemo.IssueDate = newDemographic.IssueDate;
            originalDemo.ExpirationDate = newDemographic.ExpirationDate;
            originalDemo.Gender = newDemographic.Gender;
            originalDemo.MaritalStatus = newDemographic.MaritalStatus;
            originalDemo.Employer = newDemographic.Employer;
            originalDemo.Occupation = newDemographic.Occupation;
            originalDemo.WorkPhone = newDemographic.WorkPhone;
            originalDemo.Address = newDemographic.Address;
            originalDemo.PhoneNumber = newDemographic.PhoneNumber;
            originalDemo.Email = newDemographic.Email;
            originalDemo.Birthday = newDemographic.Birthday;
            _context.SaveChanges();
        }
        return originalDemo!;
    }
}