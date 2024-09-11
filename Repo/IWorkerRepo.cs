namespace VisitorManagemment;

public interface IWorkerRepo
{

Task<IEnumerable<Worker>>GetAllWorker();
Task CreateWorker(WorkerDTO workerDTO);


}
