using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("启动中……");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    //基本配置
    builder.AddSimpleConfigure();

    // API
    builder.Services.AddControllers()
    .AddDataValidation() //模型参数校验
    .AddAppResult();


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    // Swagger
    builder.Services.AddSimpleSwagger(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "IMchat接口文档v1", Version = "v1" });
    });

    // 仓储层
    builder.Services.AddRepository(configuration["ConnectionStrings:Mysql"]!);


    // 服务层：自动添加 Service 层以 Service 结尾的服务
    builder.Services.AddAutoServices();

    // JWT 认证
    builder.Services.AddJwtAuthentication();

    // 授权
    //  builder.Services.AddSimpleAuthorization();


    // 跨域
    builder.Services.AddSimpleCros();



    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //https
    app.UseHttpsRedirection();


    app.UseCors("default");

    //app.UseStaticFiles(new StaticFileOptions
    //{
    //    FileProvider = new PhysicalFileProvider(
    //       Path.Combine(builder.Environment.ContentRootPath, "staticfiles")),
    //    RequestPath = "/staticfiles"
    //});



    app.UseAuthentication();

    app.UseAuthorization();


    app.MapControllers();
    
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "由于发生异常，导致程序中止！");
    throw;
}
finally
{
    LogManager.Shutdown();
}