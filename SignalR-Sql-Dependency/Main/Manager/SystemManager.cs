using Library.Model.Entities;
using Library.Constants;
using Library.Context;
using Library.Infrastructer.Interface;
using Library.Infrastructer.Options;
using Main.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Main.Manager
{
    public class SystemManager : ISystemManager
    {
       
        private ApplicationDbContext _dbContext;
    
        private readonly IDapperContext _dapper;
        private readonly AppOptions _appOptions;
        public SystemManager(ApplicationDbContext dbContext,IDapperContext dapper,IOptions<AppOptions> appOptions)
        {
            _dbContext = dbContext;         
            _dapper = dapper;
            _appOptions = appOptions.Value;
        }
       
        public async Task<dynamic> StoredProcedure()
        {
            
            var executionResult = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
           var rs = assembly.GetManifestResourceNames();
            var sqlFiles = assembly.GetManifestResourceNames().
                        Where(file => file.EndsWith(".sql"));
            foreach (var sqlFile in sqlFiles)
            {
                using (Stream stream = assembly.GetManifestResourceStream(sqlFile))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var sqlScript = reader.ReadToEnd();
                    var queryString = $"{sqlScript}";

                    try
                    {

                        var pluginSP = await _dapper.QueryAsync<string>(queryString);
                        executionResult = "Success";
                    }
                    catch (Exception exception)
                    {
                        executionResult = executionResult + "\n" + exception.Message;
                    }
                }
            }
            return executionResult;
        }
    }
}
