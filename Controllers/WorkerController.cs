
using Microsoft.AspNetCore.Mvc;
using VisitorManagemment;

[Route("api/[controller]")]
[ApiController]

public class WorkerController:ControllerBase{

    private  readonly IWorkerRepo _workerRepo;
    public WorkerController(IWorkerRepo workerRepo)
    {
        _workerRepo = workerRepo;
    }

[HttpGet]

public async Task<ActionResult<IEnumerable<WorkerDTO>>>GetAllWorker(){

    var workerDTO = await _workerRepo.GetAllWorker();

    return Ok(workerDTO);
}

[HttpPost]

public async Task<ActionResult<WorkerDTO>>CreateWorker([FromBody]WorkerDTO workerDTO){

    if(workerDTO == null){
        return  BadRequest("Worker Data is Not Found");
    }
    await _workerRepo.CreateWorker(workerDTO);
    return CreatedAtAction(nameof(GetAllWorker),new{id=workerDTO.Aadhar},workerDTO);


}


}


 