using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VisitorManagemment;

public class AdminRepo:IAdminRepo {


    private readonly DBContext _context;

    public AdminRepo(DBContext context) {
        _context = context;
    }

public async Task CreateData(Technical technical)
    {
        _context.Technical.Add(technical);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Technical>>GetAllData(){

        var Technicals = await _context.Technical.ToListAsync();
        return Technicals;
    }



public async Task<Technical> GetAllDataByID(int VisitorId)
{
    var technicals = await _context.Technical.ToListAsync();
    var technical = technicals.FirstOrDefault(t => t.VisitorId == VisitorId);
    return technical;
}
public async Task<Technical> DeleteDataById(int VisitorId) {
    var technicals = await _context.Technical.FindAsync(VisitorId);
    if (technicals != null)
    {
        _context.Technical.Remove(technicals);
        await _context.SaveChangesAsync();

    }
    return null;
}


// public async Task UpdateData(Technical technical) {
//     var technicals = await _context.Technical.FindAsync(technical.VisitorId);

//     if(technicals == null)
//     {
//         throw new KeyNotFoundException("Data Not Found");
//     }
//     await _context.SaveChangesAsync();


public async Task UpdateData(Technical technical)
{
    _context.Technical.Update(technical);
    await _context.SaveChangesAsync();
}


}






