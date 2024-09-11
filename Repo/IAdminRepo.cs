using VisitorManagemment;

public interface IAdminRepo{

    Task<IEnumerable<Technical>>GetAllData();

    Task <Technical> GetAllDataByID(int VisitorId);
    Task <Technical> DeleteDataById(int VisitorId);

    Task UpdateData(Technical Technical);
    Task CreateData(Technical technical);


}
