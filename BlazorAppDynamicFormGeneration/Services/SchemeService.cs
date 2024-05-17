using BlazorAppDynamicFormGeneration.Data;
using BlazorAppDynamicFormGeneration.Models;
using Dapper;
using System.Data;

namespace BlazorAppDynamicFormGeneration.Services;

public interface ISchemeService
{
    Task<int> InsertAsync(SchemeMaster obj);
    Task<int> UpdateAsync(SchemeMaster obj);
    Task<SchemeMaster> GetByIdAsync(int id);
    Task<List<SchemeMaster>> GetAllAsync();
    Task<int> DeleteAsync(int id);
}

public class SchemeService(DapperDbContext _context) : ISchemeService
{
    public async Task<int> InsertAsync(SchemeMaster obj)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "INSERT");
            parameters.Add("p_Id", 0);
            parameters.Add("p_Name", obj.Name);
            parameters.Add("p_IsActive", true);
            return await db.ExecuteAsync("sp_CrudMasterScheme", parameters, commandType: CommandType.StoredProcedure);
        }
    }
   
    public async Task<int> UpdateAsync(SchemeMaster obj)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "UPDATE");
            parameters.Add("p_Id", obj.Id);
            parameters.Add("p_Name", obj.Name);
            parameters.Add("p_IsActive", obj.IsActive);
            return await db.ExecuteAsync("sp_CrudMasterScheme", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<SchemeMaster> GetByIdAsync(int id)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "GETBYID");
            parameters.Add("p_Id", id);
            parameters.Add("p_Name", "");
            parameters.Add("p_IsActive", true);
            return await db.QueryFirstOrDefaultAsync<SchemeMaster>("sp_CrudMasterScheme", parameters, commandType: CommandType.StoredProcedure);
        }
    }
    public async Task<List<SchemeMaster>> GetAllAsync()
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "GETALL");
            parameters.Add("p_Id", 0);
            parameters.Add("p_Name", "");
            parameters.Add("p_IsActive", true);
            var data = await db.QueryAsync<SchemeMaster>("sp_CrudMasterScheme", parameters, commandType: CommandType.StoredProcedure);
            return data.AsList();
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "DELETE");
            parameters.Add("p_Id", id);
            parameters.Add("p_Name", "");
            parameters.Add("p_IsActive", true);
            return await db.ExecuteAsync("sp_CrudMasterScheme", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
