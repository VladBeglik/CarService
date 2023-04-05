using System.Data;
using System.Data.SqlClient;
using CarService.App.Cars.Queries;
using CarService.App.Infrastructure;
using CarService.Domain;
using Dapper;

namespace CarService.Persistance;

public class ServiceDbContext : IServiceDbContext
{
    private readonly string _connString;
    
    public ServiceDbContext(string connString)
    {
        _connString = connString;   
    }
    
    public async Task AddCar(Car car)
    {
        await using var conn = new SqlConnection(_connString);
        await conn.OpenAsync();
        const string insertSql = "INSERT INTO public.lobbies (lobby_id, data, end_date_time) VALUES ($1, $2, $3)";
        
        var parameters = new DynamicParameters();
        parameters.Add("Color", car.Color, DbType.String);
        parameters.Add("Brand", car.Brand, DbType.String);
        parameters.Add("Price", car.Price, DbType.Decimal);
        parameters.Add("Model", car.Model, DbType.String);
        parameters.Add("DateOfManufacture", car.DateOfManufacture.ToDateTimeUnspecified(), DbType.Date);
        
        await conn.ExecuteAsync(insertSql, parameters);
        await conn.CloseAsync();
    }

    public Task<IEnumerable<Car>> GetCars(GetCarsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCar(int id)
    {
        await using var conn = new SqlConnection(_connString);
        await conn.OpenAsync();
        const string insertSql = "DELETE from public.lobbies WHERE \"lobby_id\" = @id";
        
        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.String);

        await conn.ExecuteAsync(insertSql, parameters);
        await conn.CloseAsync();
    }

    public async Task UpdateCar(Car car)
    {
        await using var conn = new SqlConnection(_connString);
        await conn.OpenAsync();
        const string insertSql = "UPDATE MyTable SET Name = @Name, StartDateTime = @StartDateTime WHERE Id = @Id";
        
        var parameters = new DynamicParameters();
        parameters.Add("Color", car.Color, DbType.String);
        parameters.Add("Brand", car.Brand, DbType.String);
        parameters.Add("Price", car.Price, DbType.Decimal);
        parameters.Add("Model", car.Model, DbType.String);
        parameters.Add("DateOfManufacture", car.DateOfManufacture.ToDateTimeUnspecified(), DbType.Date);
        
        await conn.ExecuteAsync(insertSql, parameters);
        await conn.CloseAsync();
    }

    public Task<Car> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task Init()
    {
        await InitDataBase();
        await InitTables();
    }

    private async Task InitDataBase()
    {
        throw new NotImplementedException();
    }

    private async Task InitTables()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCar(string id)
    {
        await using var conn = new SqlConnection(_connString);
        await conn.OpenAsync();
        const string _getSql = "SELECT \"data\" FROM public.lobbies WHERE \"lobby_id\" = @id";
        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.String);

        await conn.ExecuteAsync(_getSql, parameters);

    }
}
