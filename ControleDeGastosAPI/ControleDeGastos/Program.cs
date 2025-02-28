    using controleDeGastos.Service;
    using Microsoft.Win32;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("PermitirRequisicoes",
            policy =>
            {
                policy.WithOrigins("http://localhost:3000") // Permite requisições do front-end
                      .AllowAnyMethod() // Permite GET, POST, PUT, DELETE, etc.
                      .AllowAnyHeader(); // Permite qualquer cabeçalho
            });
    });



    // Add services to the container.
    //Registra o serviço ServicePessoa e ServiceTransacao com Scoped, ou seja,
    // uma nova instância será criada para cada requisição HTTP e descartada
    // ao final da requisição.
    builder.Services.AddScoped<ServicePessoa>();
    builder.Services.AddScoped<ServiceTransacao>();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("PermitirRequisicoes");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
