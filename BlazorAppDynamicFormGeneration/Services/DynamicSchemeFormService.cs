using BlazorAppDynamicFormGeneration.Data;
using BlazorAppDynamicFormGeneration.Models;
using Dapper;
using System.Data;

namespace BlazorAppDynamicFormGeneration.Services;

public interface IDynamicSchemeFormService
{
    Task<int> InsertAsync(DynamicSchemeForm obj);
    Task<int> UpdateAsync(DynamicSchemeForm obj);
    Task<DynamicSchemeForm> GetByIdAsync(int id);
    Task<List<DynamicSchemeForm>> GetAllAsync();
    Task<List<DynamicSchemeForm>> GetSchemeWiseFormAsync(int schemeId);
    Task<int> DeleteAsync(int id);
}
public class DynamicSchemeFormService(DapperDbContext _context) : IDynamicSchemeFormService
{


    public async Task<int> InsertAsync(DynamicSchemeForm obj)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "INSERT");
            parameters.Add("p_Id", 0);
            parameters.Add("p_SchemeId", obj.SchemeId);
            parameters.Add("p_FieldName", obj.FieldName);
            parameters.Add("p_DataType", obj.DataType);
            parameters.Add("p_TabName", obj.TabName);
            parameters.Add("p_GroupName", obj.GroupName);
            parameters.Add("p_PositionOnTab", obj.PositionOnTab);
            parameters.Add("p_Options", obj.Options);
            parameters.Add("p_PlaceHolder", obj.PlaceHolder);
            parameters.Add("p_DefaultValue", obj.DefaultValue);
            parameters.Add("p_MaxLength", obj.MaxLength);
            parameters.Add("p_IsRequired", obj.IsRequired);
            parameters.Add("p_IsActive", obj.IsActive);


            return await db.ExecuteAsync("sp_CrudDynamicSchemeForm", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<int> UpdateAsync(DynamicSchemeForm obj)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "UPDATE");
            parameters.Add("p_Id", obj.Id);
            parameters.Add("p_SchemeId", obj.SchemeId);
            parameters.Add("p_FieldName", obj.FieldName);
            parameters.Add("p_DataType", obj.DataType);
            parameters.Add("p_TabName", obj.TabName);
            parameters.Add("p_GroupName", obj.GroupName);
            parameters.Add("p_PositionOnTab", obj.PositionOnTab);
            parameters.Add("p_Options", obj.Options);
            parameters.Add("p_PlaceHolder", obj.PlaceHolder);
            parameters.Add("p_DefaultValue", obj.DefaultValue);
            parameters.Add("p_MaxLength", obj.MaxLength);
            parameters.Add("p_IsRequired", obj.IsRequired);
            parameters.Add("p_IsActive", obj.IsActive);
            return await db.ExecuteAsync("sp_CrudDynamicSchemeForm", parameters, commandType: CommandType.StoredProcedure);
        }
    }


    public async Task<List<DynamicSchemeForm>> GetAllAsync()
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "GETALL");
            parameters.Add("p_Id",0);
            parameters.Add("p_SchemeId", 0);
            parameters.Add("p_FieldName", string.Empty);
            parameters.Add("p_DataType", string.Empty);
            parameters.Add("p_TabName", string.Empty);
            parameters.Add("p_GroupName", string.Empty);
            parameters.Add("p_PositionOnTab", 0);
            parameters.Add("p_Options", string.Empty);
            parameters.Add("p_PlaceHolder", string.Empty);
            parameters.Add("p_DefaultValue", string.Empty);
            parameters.Add("p_MaxLength", 0);
            parameters.Add("p_IsRequired", false);
            parameters.Add("p_IsActive", false);
            var data = await db.QueryAsync<DynamicSchemeForm>("sp_CrudDynamicSchemeForm", parameters, commandType: CommandType.StoredProcedure);
            return data.AsList();
        }
    }

    public Task<DynamicSchemeForm> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DynamicSchemeForm>> GetSchemeWiseFormAsync(int schemeId)
    {
        using (IDbConnection db = _context.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_ActionType", "GETBY_SCHEME_ID");
            parameters.Add("p_Id", 0);
            parameters.Add("p_SchemeId", schemeId);
            parameters.Add("p_FieldName", string.Empty);
            parameters.Add("p_DataType", string.Empty);
            parameters.Add("p_TabName", string.Empty);
            parameters.Add("p_GroupName", string.Empty);
            parameters.Add("p_PositionOnTab", 0);
            parameters.Add("p_Options", string.Empty);
            parameters.Add("p_PlaceHolder", string.Empty);
            parameters.Add("p_DefaultValue", string.Empty);
            parameters.Add("p_MaxLength", 0);
            parameters.Add("p_IsRequired", false);
            parameters.Add("p_IsActive", false);
            var data = await db.QueryAsync<DynamicSchemeForm>("sp_CrudDynamicSchemeForm", parameters, commandType: CommandType.StoredProcedure);
            return data.AsList();
        }
    }
}