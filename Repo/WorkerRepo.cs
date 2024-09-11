using Microsoft.EntityFrameworkCore;

namespace VisitorManagemment;

public class WorkerRepo:IWorkerRepo
{
    private readonly DBContext _context;

    public WorkerRepo(DBContext context)
    {
        _context = context;
    }

public async Task<IEnumerable<Worker>>GetAllWorker(){
    var Technical = await _context.Technical.Where(w => w.Role == "Worker").ToListAsync();
    var worker = Technical.Select(w => new Worker{
        VisitorId=w.VisitorId,
        Date = w.Date,
           InTime = w.InTime,
             Name = w.Name,
            Phone = w.Phone,
            Place = w.Place,
            Aadhar = w.Aadhar,
            Role = w.Role,
             Purpose = w.Purpose,
             OutTime = w.OutTime,
             Signature = w.Signature


    });
    return worker;
}

public async Task CreateWorker(WorkerDTO workerDTO){

    var worker = new Technical{

        Date = workerDTO.Date,
            InTime = workerDTO.InTime,
            Name = workerDTO.Name,
            Phone = workerDTO.Phone,
            Place = workerDTO.Place,
            Aadhar = workerDTO.Aadhar,
            Role = workerDTO.Role,
            Purpose = workerDTO.Purpose,


    };
    await _context.Technical.AddAsync(worker);
    await _context.SaveChangesAsync();

}


}


